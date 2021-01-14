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
	|	  ARQUIVO: AgentDustSweeper1State.cs		    						|
	| 	DATE/TIME: 2018-05-04 (YYYY-MM-DD) / 10:19   (HH:MM 24H)				|
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

    //  == ENUM
    //  =========================================================================

    ///<summary>
    /// Possible states of the Agent DustSweeper 1.
    ///<summary>
    public enum AgentDustSweeper1State
    {
        //  == DECLARATION (GLOBAL)
        //  =====================================================================

        //  == CONST

        STATE_IDLE,
        STATE_SWEEP,
        STATE_SCAN,
        STATE_MOVE

        //  == VAR

        // == CLASS CONSTRUCTOR(S)
        // ======================================================================

        // == METHODS
        // ======================================================================

        // == EVENTS
        // ======================================================================

        // == GETTERS AND SETTERS
        // ======================================================================
    }
}
