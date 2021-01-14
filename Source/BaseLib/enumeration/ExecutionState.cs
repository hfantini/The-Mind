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
	|	  ARQUIVO: ExecutionState.cs		    								|
	| 	DATE/TIME: 2018-04-19 (AAAA-MM-DD) / 13:46AM (HH:MM 24H)				|
	|																			|
	+ - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - +
	
*/

//  == IMPORTS
//  =========================================================================

//  == NAMESPACE
//  =========================================================================

namespace The_Mind.enumeration
{

    //  == ENUM
    //  =========================================================================

    ///<summary>
    /// Defines a set of execution states.
    ///<summary>
    ///<remarks>
    ///STATE_NONE = Not initialized.
    ///STATE_IDLE = Application is idle, waiting for the next processment.
    ///STATE_PROCESSING = Application is processing data.
    ///STATE_PAUSED = Application is paused.
    ///STATE_FINISHED = Application finishes your processing.
    ///</remarks>
    public enum ExecutionState
    {
        STATE_NONE,
        STATE_IDLE,
        STATE_RUNNING,
        STATE_PAUSED,
        STATE_FINISHED
    }
}
