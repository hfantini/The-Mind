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
	|	  ARQUIVO: ViewAIDustSweeper.cs 										|
	| 	DATE/TIME: 2018-05-03 (YYYY-MM-DD) / 11:20   (HH:MM 24H)				|
	|																			|
	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	
*/

//  == IMPORTS
//  =========================================================================

using System;
using System.Drawing;
using System.Windows.Forms;
using The_Mind.math;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind.view.agent
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// The main class of the application.
    ///<summary>
    public partial class ViewIADustSweeper1 : BaseActivityView
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        //  == VAR
        private int count = 0;
        private DoubleVector _roomSize = new DoubleVector();
        private DoubleVector _roomMargin = new DoubleVector();
        private DoubleVector _blockSize = new DoubleVector(60, 60);
        private Floor[,] _floorArray;
        private AgentDustSweeper1 _agent;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public ViewIADustSweeper1(ViewMain viewMain) : base(viewMain)
        {
            InitializeComponent();
            this._activityName = "Dust Sweeper 1";
        }

        // == METHODS
        // ======================================================================

        /// <summary>
        /// Dirty the floor randomically
        /// </summary>
        protected void randomizeDirty()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            for (int countY = 0; countY < _roomSize.y; countY++)
            {
                for (int countX = 0; countX < _roomSize.x; countX++)
                {
                    int randomNumber = random.Next(0, 100);

                    Console.WriteLine(randomNumber);
                    if (randomNumber >= 50)
                    {
                        _floorArray[countX, countY].dirtyFloor();
                    }
                }
            }
        }

        /// <summary>
        /// Returns TRUE if any floor has dirty and FALSE if not.
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean hasDirty()
        {
            Boolean retValue = false;

            for (int countY = 0; countY < _roomSize.y; countY++)
            {
                for (int countX = 0; countX < _roomSize.x; countX++)
                {
                    if (_floorArray[countX, countY].dirty == true)
                    {
                        return true;
                    }
                }
            }

            return retValue;
        }

        /// <summary>
        /// Returns the floor by your position.
        /// </summary>
        /// <param name="point">The position</param>
        /// <returns>Object of type Floor or NULL if not exists.</returns>
        public Floor getFloorByPosition(Point point)
        {
            Floor retValue = null;

            int X = point.X / (int)_blockSize.x;
            int Y = point.Y / (int)_blockSize.y;

            retValue = _floorArray[X, Y];

            return retValue;
        }

        public Floor getFloorBySquare(Point point)
        {
            Floor retValue = null;

            if( (point.X >= 0 && point.X < _floorArray.GetLength(0) ) && (point.Y >= 0 && point.Y < _floorArray.GetLength(1) ) )
            {
                retValue = _floorArray[point.X, point.Y];
            }

            return retValue;
        }

        /// <summary>
        /// Cleans an specified floor by position.
        /// </summary>
        /// <param name="floor">Floor object</param>
        public void cleanFloor(Floor floor)
        {
            floor.cleanFloor();
            this.Invalidate();
        }

        // == EVENTS
        // ======================================================================

        public override void onStartSimulation(Graphics graphics)
        {
            base.onStartSimulation(graphics);
            ((ViewMain)_viewMain).viewConsole.writeMessage(this._activityName + " : STARTING SIMULATION.");

            // CALCULATING THE ROOM SIZE BASED IN THE BLOCK SIZE

            ((ViewMain)_viewMain).viewConsole.writeMessage(this._activityName + " : CREATING FLOOR.");

            double sizeX = Math.Floor(this.Size.Width / _blockSize.x);
            double sizeY = Math.Floor(this.Size.Height / _blockSize.y);

            this._roomSize = new DoubleVector(sizeX, sizeY);
            this._roomMargin = new DoubleVector((this.Size.Width - (_roomSize.x * _blockSize.x)) / 2, (this.Size.Height - (_roomSize.y * _blockSize.y)) / 2);

            _floorArray = new Floor[(int)_roomSize.x, (int)_roomSize.y];

            //CREATE FLOOR

            for (int countY = 0; countY < _roomSize.y; countY++)
            {
                for (int countX = 0; countX < _roomSize.x; countX++)
                {
                    Boolean even = false;

                    if (countY % 2 == 0)
                    {
                        if (countX % 2 == 0)
                        {
                            even = true;
                        }
                        else
                        {
                            even = false;
                        }
                    }
                    else
                    {
                        if (countX % 2 == 0)
                        {
                            even = false;
                        }
                        else
                        {
                            even = true;
                        }
                    }

                    int X = ((int)countX * (int)_blockSize.x) + (int)_roomMargin.x;
                    int Y = ((int)countY * (int)_blockSize.y) + (int)_roomMargin.y;
                    int W = (int)_blockSize.x;
                    int H = (int)_blockSize.y;

                    Floor floor = new Floor(even, false);
                    _floorArray[countX, countY] = floor;
                    floor.Location = new Point(X, Y);

                    this.Controls.Add(floor);
                }
            }

            ((ViewMain)viewMain).viewConsole.writeMessage(this._activityName + " : CREATING RANDOM DIRTY.");

            randomizeDirty();

            // CREATING AGENT
            _agent = new AgentDustSweeper1(this);

            Random random = new Random(DateTime.Now.Millisecond);
            int agentStartSquareX = random.Next(0, (int)_roomSize.x - 1);
            int agentStartSquareY = random.Next(0, (int)_roomSize.y - 1);

            _agent.Location = _floorArray[agentStartSquareX, agentStartSquareY].Location;

            this.Controls.Add(_agent);
            _agent.BringToFront();
        }

        public override void onUpdateSimulation(Graphics graphics)
        {
            _agent.updateAgent();
        }

        public override void onStopSimulation(Graphics graphics)
        {
            ((ViewMain)viewMain).viewConsole.writeMessage(this._activityName + " : STOPPING SIMULATION.");
            Controls.Clear();
        }

        // == GETTERS AND SETTERS
        // ======================================================================

        public DoubleVector roomSize
        {
            get { return this._roomSize; }
        }

        public ViewMain viewMain
        {
            get { return ((ViewMain) this._viewMain); }
        }
    }
}

