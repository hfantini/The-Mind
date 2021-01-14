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
	|	  ARQUIVO: Floor.cs		    											|
	| 	DATE/TIME: 2018-05-03 (YYYY-MM-DD) / 14:33   (HH:MM 24H)				|
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

//  == NAMESPACE
//  =========================================================================

namespace The_Mind
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// Defines the floor for the example DustSweeper.
    ///<summary>
    public partial class Floor : PictureBox
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        //  == VAR

        Boolean _even = false;
        Boolean _dirty = false;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public Floor(Boolean even, Boolean dirty) : base()
        {
            this._even = even;
            this._dirty = dirty;
            this.Size = new Size(60, 60);
            this.BackColor = Color.Transparent;

            updateFloor();
        }

        // == METHODS
        // ======================================================================

        /// <summary>
        /// Updates the state of the floor based in "even" and "dirty" values.
        /// </summary>
        public void updateFloor()
        {
            if (this._even == true)
            {
                if (_dirty == true)
                {
                    setCurrentImage( Properties.Resources.floor_even_dirty );
                }
                else
                {
                    setCurrentImage( Properties.Resources.floor_even_clean );
                }
            }
            else
            {
                if (_dirty == true)
                {
                    setCurrentImage( Properties.Resources.floor_odd_dirty );
                }
                else
                {
                    setCurrentImage ( Properties.Resources.floor_odd_clean );
                }
            }
        }

        /// <summary>
        /// Dirty the floor.
        /// </summary>
        public async void dirtyFloor()
        {
            this._dirty = true;
            updateFloor();
        }

        /// <summary>
        /// Clean the floor.
        /// </summary>
        public void cleanFloor()
        {
            this._dirty = false;
            updateFloor();
        }

        private void setCurrentImage(Image image)
        {
            if(this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.Image = image;
                }));
            }
            else
            {
                this.Image = image;
            }
        }

        // == EVENTS
        // ======================================================================

        // == GETTERS AND SETTERS
        // ======================================================================

        public Boolean dirty
        {
            get { return this._dirty; }
        }
    }
}
