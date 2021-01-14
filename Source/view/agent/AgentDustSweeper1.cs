/* 

	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	|																			|
	|	PROJECT: THE MIND														|
	|	 AUTHOR: HENRIQUE FANTINI												|
	|   CONTACT: contact@henriquefantini.com									|
	|																			|
	|  = PROJECT DESCRIPTION =													|
	|																			|
	|   This project is a practical study about artificial intelligence.		|
	|																			|
	+ - - - - - - - - - - - - + ===  FILE DETAILS === - - - - - - - - - - - - - |
	|																			|
	|	  ARQUIVO: AgentDustSweeper.cs		   									|
	| 	DATE/TIME: 2018-05-03 (YYYY-MM-DD) / 15:49   (HH:MM 24H)				|
	|																			|
	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	
*/

//  == IMPORTS
//  =========================================================================

using System.Drawing;
using System.Threading;
using System.Windows.Forms;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind.view.agent
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// The main class of the application.
    ///<summary>
    public partial class AgentDustSweeper1 : PictureBox
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        private const int SCAN_SPEED = 100;
        private const int MOVE_SPEED = 3;

        //  == VAR

        private ViewIADustSweeper1 environment;
        private Scanner scanner;
        private AgentDustSweeper1State state = AgentDustSweeper1State.STATE_SCAN;
        private Floor nextDirtyFloor = null;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="environment">The environment.</param>
        public AgentDustSweeper1(ViewIADustSweeper1 environment) : base()
        {
            this.environment = environment;

            this.Size = new System.Drawing.Size(60, 60);
            this.Image = Properties.Resources.agent_dustsweeper;
            this.BackColor = Color.Transparent;

            scanner = new Scanner();
        }

        // == METHODS
        // ======================================================================

        /// <summary>
        /// Agent function.
        /// </summary>
        public void updateAgent()
        {
            Floor currentFloor = environment.getFloorByPosition(this.Location);

            if ( state == AgentDustSweeper1State.STATE_IDLE )
            {

            }
            else if (state == AgentDustSweeper1State.STATE_MOVE)
            {
                bool moveXComplete = false;
                bool moveYComplete = false;
                Point currentPos = this.Location;
                Point targetPos = nextDirtyFloor.Location;

                environment.viewMain.viewConsole.writeMessage("[STATE: MOVE] : MOVING TO [" + targetPos.X + "," + targetPos.Y + "]");

                // == X
                if (currentPos.X < targetPos.X)
                {
                    currentPos.X += MOVE_SPEED;

                    if(currentPos.X > targetPos.X)
                    {
                        currentPos.X = targetPos.X;
                    }
                }
                else if(currentPos.X == targetPos.X)
                {
                    moveXComplete = true;
                }
                else //currentPos.X > targetPos.X
                {
                    currentPos.X -= MOVE_SPEED;

                    if (currentPos.X < targetPos.X)
                    {
                        currentPos.X = targetPos.X;
                    }
                }

                // == Y
                if (currentPos.Y < targetPos.Y)
                {
                    currentPos.Y += MOVE_SPEED;

                    if (currentPos.Y > targetPos.Y)
                    {
                        currentPos.Y = targetPos.Y;
                    }
                }
                else if (currentPos.Y == targetPos.Y)
                {
                    moveYComplete = true;
                }
                else //currentPos.Y > targetPos.Y
                {
                    currentPos.Y -= MOVE_SPEED;

                    if (currentPos.Y < targetPos.Y)
                    {
                        currentPos.Y = targetPos.Y;
                    }
                }

                // UPDATE LOCATION
                this.Location = currentPos;

                // CHECK POSITION TARGET
                if(moveXComplete == true && moveYComplete == true)
                {
                    environment.viewMain.viewConsole.writeMessage("[STATE: MOVE] : TARGET REACHED, CHANGING MODE TO STATE_SCAN");
                    this.state = AgentDustSweeper1State.STATE_SCAN;
                }
            }
            else if (state == AgentDustSweeper1State.STATE_SCAN)
            {
                if( environment.hasDirty() == true )
                {
                    environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY DETECTED ON ROOM.");

                    if(currentFloor != null)
                    {
                        if(currentFloor.dirty == true)
                        {
                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY DETECTED ON MY SQUARE! CHANGING MODE TO STATE_SWEEP.");

                            // CLEAN THE ACTUAL FLOOR
                            state = AgentDustSweeper1State.STATE_SWEEP;
                        }
                        else
                        {
                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : THERE'S NO DIRTY IN MY SQUARE, STARTING SCAN SEQUENCE.");
                            bool dirtyFound = false;
                            int scanOffset = 0;

                            showScanner();

                            // SCAN FOR THE CLOSEST DIRTY FLOOR

                            int currentSquareX = this.Location.X / 60;
                            int currentSquareY = this.Location.Y / 60;

                            do
                            {
                                scanOffset++;

                                environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : SCAN OFFSET DEFINED AS: " + scanOffset);

                                // UP
                                if (dirtyFound == false && (currentSquareY - scanOffset) >= 0)
                                {
                                    for (int count = -scanOffset; count <= +scanOffset; count++)
                                    {
                                        Point scanPosition = new Point(currentSquareX + count, currentSquareY - scanOffset);
                                        Floor currentScanFloor = environment.getFloorBySquare(scanPosition);

                                        if (currentScanFloor != null)
                                        {
                                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : LOOKING AT SQUARE [" + scanPosition.X + "," + scanPosition.Y + "]");
                                            setScannerPosition(currentScanFloor.Location);

                                            Thread.Sleep(SCAN_SPEED);

                                            if (currentScanFloor.dirty == true)
                                            {
                                                environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY FOUND. CHANGING MODE TO STATE_MOVE. ");
                                                dirtyFound = true;
                                                nextDirtyFloor = currentScanFloor;
                                                state = AgentDustSweeper1State.STATE_MOVE;
                                                break;
                                            }
                                        }
                                    }
                                }

                                // LEFT
                                if (dirtyFound == false && (currentSquareX - scanOffset) >= 0)
                                {
                                    for (int count = -scanOffset + 1; count <= +scanOffset - 1; count++)
                                    {
                                        Point scanPosition = new Point(currentSquareX - scanOffset, currentSquareY + count);
                                        Floor currentScanFloor = environment.getFloorBySquare(scanPosition);

                                        if (currentScanFloor != null)
                                        {
                                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : LOOKING AT SQUARE [" + scanPosition.X + "," + scanPosition.Y + "]");
                                            setScannerPosition(currentScanFloor.Location);

                                            Thread.Sleep(SCAN_SPEED);

                                            if (currentScanFloor.dirty == true)
                                            {
                                                environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY FOUND. CHANGING MODE TO STATE_MOVE. ");
                                                dirtyFound = true;
                                                nextDirtyFloor = currentScanFloor;
                                                state = AgentDustSweeper1State.STATE_MOVE;
                                                break;
                                            }
                                        }
                                    }
                                }

                                // RIGHT
                                if (dirtyFound == false && (currentSquareX + scanOffset) < environment.roomSize.x)
                                {
                                    for (int count = -scanOffset + 1; count <= +scanOffset - 1; count++)
                                    {
                                        Point scanPosition = new Point(currentSquareX + scanOffset, currentSquareY + count);
                                        Floor currentScanFloor = environment.getFloorBySquare(scanPosition);

                                        if (currentScanFloor != null)
                                        {
                                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : LOOKING AT SQUARE [" + scanPosition.X + "," + scanPosition.Y + "]");
                                            setScannerPosition(currentScanFloor.Location);

                                            Thread.Sleep(SCAN_SPEED);

                                            if (currentScanFloor.dirty == true)
                                            {
                                                environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY FOUND. CHANGING MODE TO STATE_MOVE. ");
                                                dirtyFound = true;
                                                nextDirtyFloor = currentScanFloor;
                                                state = AgentDustSweeper1State.STATE_MOVE;
                                                break;
                                            }
                                        }
                                    }
                                }

                                // DOWN
                                if (dirtyFound == false && (currentSquareY + scanOffset) < environment.roomSize.y)
                                {
                                    for (int count = -scanOffset; count <= +scanOffset; count++)
                                    {
                                        Point scanPosition = new Point(currentSquareX + count, currentSquareY + scanOffset);
                                        Floor currentScanFloor = environment.getFloorBySquare(scanPosition);
                                    
                                        if (currentScanFloor != null)
                                        {
                                            environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : LOOKING AT SQUARE [" + scanPosition.X + "," + scanPosition.Y + "]");
                                            setScannerPosition(currentScanFloor.Location);

                                            Thread.Sleep(SCAN_SPEED);

                                            if (currentScanFloor.dirty == true)
                                            {
                                                environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : DIRTY FOUND. CHANGING MODE TO STATE_MOVE. ");
                                                dirtyFound = true;
                                                nextDirtyFloor = currentScanFloor;
                                                state = AgentDustSweeper1State.STATE_MOVE;
                                                break;
                                            }
                                        }
                                    }
                                }

                            } while (dirtyFound == false);

                            hideScanner();
                        }
                    }
                }
                else
                {
                    environment.viewMain.viewConsole.writeMessage("[STATE: SCAN] : THE ROOM IS CLEAN, CHANGING MODE TO STATE_IDLE.");
                    this.state = AgentDustSweeper1State.STATE_IDLE;
                }
            }
            else if (state == AgentDustSweeper1State.STATE_SWEEP)
            {
                environment.viewMain.viewConsole.writeMessage("[STATE: SWEEP] : CLEARING THE CURRENT SQUARE");
                Thread.Sleep(SCAN_SPEED * 5);

                environment.Invoke(new MethodInvoker(delegate ()
                {
                    environment.cleanFloor(currentFloor);
                }));

                nextDirtyFloor = null;

                environment.viewMain.viewConsole.writeMessage("[STATE: SWEEP] : SQUARE CLEANED. CHANGING MODE TO STATE_SCAN.");

                Thread.Sleep(SCAN_SPEED * 5);
                state = AgentDustSweeper1State.STATE_SCAN;
            }
        }

        private void showScanner()
        {
            if( environment.Controls.Contains(scanner) == false )
            {
                environment.Controls.Add(scanner);
                scanner.BringToFront();
            }
        }

        private void hideScanner()
        {
            if (environment.Controls.Contains(scanner) == true)
            {
                environment.Controls.Remove(scanner);
            }
        }

        private void setScannerPosition(Point point)
        {
            scanner.Location = point;
            environment.Update();
        }

        // == EVENTS
        // ======================================================================

        // USED TO DRAW A TRANSPARENT BACKGROUND IMAGE.
        // SOLUTION FROM: https://stackoverflow.com/questions/5522337/c-sharp-picturebox-transparent-background-doesnt-seem-to-work

        protected override void OnPaintBackground(PaintEventArgs e)
        // Paint background with underlying graphics from other controls
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                // Take each control in turn
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];

                    // Check it's visible and overlaps this control
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        // Load appearance of underlying control and redraw it on this background
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }

        // == GETTERS AND SETTERS
        // ======================================================================
    }
}
