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
	|	  ARQUIVO: BaseActivityView.cs     										|
	| 	DATE/TIME: 2018-04-19 (AAAA-MM-DD) / 16:07   (HH:MM 24H)				|
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
using System.Timers;
using System.Windows.Forms;
using The_Mind.enumeration;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// Base class of any activity of the system.
    ///<summary>
    public partial class BaseActivityView : UserControl
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        //  == VAR
        protected String _activityName = "Generic Activity";
        private System.Windows.Forms.Timer timerExecutor;
        protected ExecutionState _lastState = ExecutionState.STATE_NONE;
        protected ExecutionState _currentState = ExecutionState.STATE_NONE;
        protected object _viewMain;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public BaseActivityView(object viewMain)
        {
            this._viewMain = viewMain;

            InitializeComponent();
            initializeResources();
        }

        // == METHODS
        // ======================================================================

        /// <summary>
        /// Initialize the class resources.
        /// </summary>
        private void initializeResources()
        {
            timerExecutor = new System.Windows.Forms.Timer();
            timerExecutor.Interval = 16;
            timerExecutor.Enabled = false;
            timerExecutor.Tick += new EventHandler( onTick );
        }


        /// <summary>
        /// Starts the activity setting the current state to STATE_RUNNING.
        /// </summary>
        /// <remarks>
        /// This method has no effect with the current state is already on STATE_RUNNING.
        /// </remarks>
        public void start()
        {
            if (currentState != ExecutionState.STATE_RUNNING)
            {
                changeState(ExecutionState.STATE_RUNNING);
                this.onStartSimulation( this.CreateGraphics() );
                timerExecutor.Start();
            }
        }

        /// <summary>
        /// Stops the activity setting the current state to STATE_FINISHED.
        /// </summary>
        /// <remarks>
        /// This method has no effect with the current state is already on STATE_NONE, STATE_IDLE AND STATE_FINISHED.
        /// </remarks>
        public void stop()
        {
            if (currentState == ExecutionState.STATE_RUNNING || currentState == ExecutionState.STATE_PAUSED)
            {
                changeState(ExecutionState.STATE_FINISHED);
                this.onStopSimulation(this.CreateGraphics());
                timerExecutor.Stop();
            }
        }

        /// <summary>
        /// Pauses the activity setting the current state to STATE_PAUSED.
        /// </summary>
        /// <remarks>
        /// This method has no effect with the current state is already on STATE_NONE, STATE_IDLE AND STATE_FINISHED.
        /// </remarks>
        public void pause()
        {
            if (currentState == ExecutionState.STATE_RUNNING)
            {
                changeState(ExecutionState.STATE_PAUSED);
                this.onPauseSimulation(this.CreateGraphics());
            }
        }

        /// <summary>
        /// Changes the state of activity.
        /// </summary>
        /// <param name="state">The next state.</param>
        protected void changeState(ExecutionState state)
        {
            this._lastState = this._currentState;
            this._currentState = state;
        }

        // == EVENTS
        // ======================================================================

        private void onTick(object sender, EventArgs e)
        {
            onUpdateSimulation(this.CreateGraphics());
        }

        /// <summary>
        /// Called when the simulation starts;
        /// </summary>
        public virtual void onStartSimulation(Graphics graphics)
        {
 
        }

        /// <summary>
        /// Called in recursion while simulation is running.
        /// </summary>
        public virtual void onUpdateSimulation(Graphics graphics)
        {

        }

        /// <summary>
        /// Called when simulation is paused.
        /// </summary>
        public virtual void onPauseSimulation(Graphics graphics)
        {

        }

        /// <summary>
        /// Called when simulation is stopped.
        /// </summary>
        public virtual void onStopSimulation(Graphics graphics)
        {
        }

        // == GETTERS AND SETTERS
        // ======================================================================

        /// <summary>
        /// Returns the last state of the activity.
        /// </summary>
        /// <returns>ExectionState enum</returns>
        public ExecutionState lastState
        {
            get { return _lastState; }
        }

        /// <summary>
        /// Returns the current state of the activity.
        /// </summary>
        /// <returns>ExectionState enum</returns>
        public ExecutionState currentState
        {
            get { return _currentState; }
        }

        private void BaseActivityView_Load(object sender, EventArgs e)
        {
            this.Size = Parent.Size;
        }

        /// <summary>
        /// Gets the name of the activity.
        /// </summary>
        public String activityName
        {
            get { return this._activityName; }
        }
    }
}
