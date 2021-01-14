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
	|	  ARQUIVO: Console.cs		    									    |
	| 	DATE/TIME: 2018-04-30 (YYYY-MM-DD) / 14:09   (HH:MM 24H)				|
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
using The_Mind;
using The_Mind.enumeration;
using The_Mind.util;

//  == NAMESPACE
//  =========================================================================

namespace The_Mind.view.console
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// This class represents the console of the application.
    ///<summary>
    public partial class ViewConsole : Form
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST
        private const int DEFAULT_HEIGHT = 200;
        private const int DEFAULT_MARGIN = 5;

        //  == VAR
        private ViewMain viewMain;
        private String lastAddedMessage = null;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public ViewConsole(ViewMain main)
        {
            this.viewMain = main;

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
            
        }

        ///<summary>
        /// Writes a message in the console.
        ///<summary>
        ///<param name="message">Message to be written.</param>
        public void writeMessage(String message)
        {
            writeMessage(message, ConsoleMessageType.NORMAL, false);
        }

        ///<summary>
        /// Writes a message in the console.
        ///<summary>
        ///<param name="message">Message to be written.</param>
        ///<param name="type">Type of message.</param>
        public void writeMessage(String message, ConsoleMessageType type)
        {
            writeMessage(message, type, false);
        }

        ///<summary>
        /// Writes a message in the console.
        ///<summary>
        ///<param name="message">Message to be written.</param>
        ///<param name="type">Type of message.</param>
        ///<param name="displayMessageOnly">If true, the message will not display date/time information.</param>
        public void writeMessage(String message, ConsoleMessageType type, bool displayMessageOnly)
        {
            String completeMessage;

            if (displayMessageOnly == false)
            {
                if (type != ConsoleMessageType.NORMAL)
                {
                    completeMessage = DateTimeUtil.getStandardSystemDate() + " - " + DateTimeUtil.getStandardSystemTime() + " : [" + type.ToString() + "] " + message + Environment.NewLine;
                }
                else
                {
                    completeMessage = DateTimeUtil.getStandardSystemDate() + " - " + DateTimeUtil.getStandardSystemTime() + " : " + message + Environment.NewLine;
                }
            }
            else
            {
                completeMessage = message + Environment.NewLine;
            }

            if (completeMessage != lastAddedMessage)
            {
                txtConsole.Text += completeMessage;
                txtConsole.SelectionStart = txtConsole.Text.Length;
                txtConsole.ScrollToCaret();

                lastAddedMessage = completeMessage;
            }
        }

        ///<summary>
        /// Resets console dimension to fit the main window width and [DEFAULT_HEIGHT] height;
        ///<summary>
        private void resetDimension()
        {
            this.Width = viewMain.Width;
            this.Height = DEFAULT_HEIGHT;
        }

        ///<summary>
        /// Resets console position to the below the main window.
        ///<summary>
        private void resetPosition()
        {
            this.Left = viewMain.Left;
            this.Top = viewMain.Top + viewMain.Height + DEFAULT_MARGIN;
        }

        // == EVENTS
        // ======================================================================

        private void ViewConsole_Shown(object sender, EventArgs e)
        {
            resetDimension();
            resetPosition();
        }

        private void ViewConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // == GETTERS AND SETTERS
        // ======================================================================
    }
}
