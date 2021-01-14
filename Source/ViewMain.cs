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
	|	  ARQUIVO: ViewMain.cs		    										|
	| 	DATE/TIME: 2018-04-18 (AAAA-MM-DD) / 16:28AM (HH:MM 24H)				|
	|																			|
	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	
*/

//  == IMPORTS
//  =========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Mind.enumeration;
using The_Mind.view.agent;
using The_Mind.view.console;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// The main class of the application.
    ///<summary>
    public partial class ViewMain : Form
    {
        //  == DECLARATION (GLOBAL)
        //  =========================================================================

        //  == CONST

        //  == VAR
        private ViewConsole _viewConsole;
        private UserControl _lastControl;
        private UserControl _currentControl;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public ViewMain()
        {
            InitializeComponent();
            initializeResources();
        }

        // == METHODS
        // ======================================================================
       
        ///<summary>
        /// Initializes other resouces that aren't related with GUI.
        ///<summary>
        public void initializeResources()
        {
            _viewConsole = new ViewConsole(this);

            writeStartMessage();
            _viewConsole.writeMessage("SYSTEM INITIALIZED AND READY.");

            // UPDATES THE UI FOR THE FIRST TIME

            updateUI();

            // BRING UP THE APPLICATION CONSOLE.
            this._viewConsole.Show();
        }

        /// <summary>
        /// Updates the UI of the form.
        /// </summary>
        public void updateUI()
        {
            // MAIN COMPONENTS

            if (currentControl != null)
            {
                BaseActivityView currentActivity = ((BaseActivityView)currentControl);

                // HANDLES THE CONTAINER STATE
                if ( currentActivity.currentState == ExecutionState.STATE_NONE 
                    || currentActivity.currentState == ExecutionState.STATE_IDLE
                    || currentActivity.currentState == ExecutionState.STATE_FINISHED)
                {
                    tBtnPlaySimulation.Enabled = true;
                    tBtnPauseSimulation.Enabled = false;
                    tBtnStopSimulation.Enabled = false;
                }
                else if( currentActivity.currentState == ExecutionState.STATE_RUNNING)
                {
                    tBtnPlaySimulation.Enabled = false;
                    tBtnPauseSimulation.Enabled = true;
                    tBtnStopSimulation.Enabled = true;
                }
                else if (currentActivity.currentState == ExecutionState.STATE_PAUSED)
                {
                    tBtnPlaySimulation.Enabled = true;
                    tBtnPauseSimulation.Enabled = false;
                    tBtnStopSimulation.Enabled = true;
                }
            }
            else
            {
                tBtnPlaySimulation.Enabled = false;
                tBtnPauseSimulation.Enabled = false;
                tBtnStopSimulation.Enabled = false;
            }

        }

        /// <summary>
        /// Updates the status based on the current activity state.
        /// </summary>
        private void updateStatus()
        {
            // STATUS BAR
            if (currentControl != null)
            {
                switch (((BaseActivityView)currentControl).currentState)
                {
                    case ExecutionState.STATE_NONE:
                        break;

                    case ExecutionState.STATE_IDLE:
                        lblStatus.Text = "STATUS: IDLE";
                        //pBarMain.Style = ProgressBarStyle.Continuous;
                        break;

                    case ExecutionState.STATE_RUNNING:
                        lblStatus.Text = "STATUS: RUNNING";
                        //pBarMain.Style = ProgressBarStyle.Marquee;
                        break;

                    case ExecutionState.STATE_PAUSED:
                        lblStatus.Text = "STATUS: PAUSED";
                        //pBarMain.Style = ProgressBarStyle.Continuous;
                        break;

                    case ExecutionState.STATE_FINISHED:
                        lblStatus.Text = "STATUS: FINISHED";
                        //pBarMain.Style = ProgressBarStyle.Continuous;
                        break;
                }
            }
        }

        /// <summary>
        /// Writes the start message in the console.
        /// </summary>
        public void writeStartMessage()
        {
            // WRITE APP CONSOLE INFO
            _viewConsole.writeMessage("THE MIND: ARTIFICIAL INTELLIGENCE 0.1b", ConsoleMessageType.INFO, true);
            _viewConsole.writeMessage("By Henrique Fantini", ConsoleMessageType.INFO, true);
            _viewConsole.writeMessage("www.henriquefantini.com", ConsoleMessageType.INFO, true);
            _viewConsole.writeMessage("--------------------------------------------------------", ConsoleMessageType.INFO, true);
            _viewConsole.writeMessage("", ConsoleMessageType.INFO, true);
        }

        // == EVENTS
        // ======================================================================

        private void nEURALNETWORKHANDWRITTINGIDENTIFICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewIADustSweeper1 viewIADustSweeper = new ViewIADustSweeper1(this);
            currentControl = viewIADustSweeper;

            pnlMain.Controls.Add(currentControl);

            updateUI();
        }

        private void tBtnShowConsole_Click(object sender, EventArgs e)
        {
            this._viewConsole.Show();
        }

        private void tBtnPlaySimulation_Click(object sender, EventArgs e)
        {
            if (currentControl != null)
            {
                ((BaseActivityView)currentControl).start();
                updateUI();
                updateStatus();
            }
        }

        private void tBtnPauseSimulation_Click(object sender, EventArgs e)
        {
            if (currentControl != null)
            {
                ((BaseActivityView)currentControl).pause();
                updateUI();
                updateStatus();
            }
        }

        private void tBtnStopSimulation_Click(object sender, EventArgs e)
        {
            if (currentControl != null)
            {
                ((BaseActivityView)currentControl).stop();
                updateUI();
                updateStatus();
            }
        }

        // == GETTERS AND SETTERS
        // ======================================================================

        public UserControl lastControl
        {
            get { return this._lastControl; }
        }

        public UserControl currentControl
        {
            get { return this._currentControl; }
            set
            {
                this._lastControl = this._currentControl;
                this._currentControl = value;
                _viewConsole.writeMessage("CHANGING ACTIVITY TO: " + ((BaseActivityView)this._currentControl).activityName);
            }
        }

        public ViewConsole viewConsole
        {
            get { return this._viewConsole; }
        }
    }
}
