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
	|	  ARQUIVO: DoubleVector.cs    											|
	| 	DATE/TIME: 2018-05-03 (YYYY-MM-DD) / 13:20   (HH:MM 24H)				|
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

namespace The_Mind.math
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// The main class of the application.
    ///<summary>
    public partial class DoubleVector
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        //  == VAR

        private double _x = 0;
        private double _y = 0;

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        ///<summary>
        /// Class constructor
        ///<summary>
        public DoubleVector()
        {

        }

        public DoubleVector(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        // == METHODS
        // ======================================================================

        // == EVENTS
        // ======================================================================

        // == GETTERS AND SETTERS
        // ======================================================================

        public double x
        {
            get { return this._x; }
            set { this._x = value; }
        }

        public double y
        {
            get { return this._y; }
            set { this._y = value; }
        }

    }
}
