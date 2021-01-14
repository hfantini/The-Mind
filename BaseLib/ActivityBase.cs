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
	|	  ARQUIVO: ActivityBase.cs												|
	| 	DATE/TIME: 2018-04-19 (AAAA-MM-DD) / 13:59   (HH:MM 24H)				|
	|																			|
	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	
*/

//  == IMPORTS
//  =========================================================================

using System.Windows.Forms;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// The main class of the application.
    ///<summary>
    public abstract partial class ActivityBase : UserControl
    {
        private Button button1;

        //  == DECLARATION (GLOBAL)
        //  =========================================================================

        //  == CONST

        //  == VAR
        private Form _parent;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public ActivityBase()
        {
            //this._parent = parent;
            InitializeComponent();
        }

        // == METHODS
        // ======================================================================

        private void InitializeComponent()
        {

        }

        /// <summary>
        /// Updates the UI of the form.
        /// </summary>
        public void updateUI()
        {

        }

        // == EVENTS
        // ======================================================================

        // == GETTERS AND SETTERS
        // ======================================================================

        public Form parent
        {
            get { return this._parent; }
        }
    }
}
