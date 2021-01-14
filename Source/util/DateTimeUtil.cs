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
	|	  ARQUIVO: DateTimeUtil.cs		    									|
	| 	DATE/TIME: 2018-04-30 (YYYY-MM-DD) / 15:02   (HH:MM 24H)				|
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

namespace The_Mind.util
{

    //  == CLASS
    //  =========================================================================

    ///<summary>
    /// Provides methods related with date and time operations.
    ///<summary>
    public static class DateTimeUtil
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        //  == VAR

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        // == METHODS
        // ======================================================================

        ///<summary>
        /// Returns the current Date in format YYYY-MM-DD (as String).
        ///<summary> 
        ///<returns>
        ///String in format YYYY-MM-DD
        ///</returns>
        public static String getStandardSystemDate()
        {
            String retValue = "";

            DateTime currentDate = DateTime.Now;

            // YEAR
            retValue = currentDate.Year + "-";

            // MONTH
            if(currentDate.Month < 10)
            {
                retValue += "0" + currentDate.Month + "-";
            }
            else
            {
                retValue += currentDate.Month + "-";
            }

            // DAY
            if (currentDate.Day < 10)
            {
                retValue += "0" + currentDate.Day;
            }
            else
            {
                retValue += currentDate.Day;
            }

            return retValue;
        }

        ///<summary>
        /// Returns the current Time in format HH:MM:ss (as String).
        ///<summary> 
        ///<returns>
        ///String in format HH:MM:ss
        ///</returns>
        public static String getStandardSystemTime()
        {
            String retValue = "";

            DateTime currentDate = DateTime.Now;

            // HOUR
            if (currentDate.Hour < 10)
            {
                retValue += "0" + currentDate.Hour + ":";
            }
            else
            {
                retValue += currentDate.Hour + ":";
            }

            // MINUTES
            if (currentDate.Minute < 10)
            {
                retValue += "0" + currentDate.Minute + ":";
            }
            else
            {
                retValue += currentDate.Minute + ":";
            }

            // SECONDS

            if (currentDate.Second < 10)
            {
                retValue += "0" + currentDate.Second;
            }
            else
            {
                retValue += currentDate.Second;
            }

            return retValue;
        }

        // == EVENTS
        // ======================================================================

        // == GETTERS AND SETTERS
        // ======================================================================
    }
}
