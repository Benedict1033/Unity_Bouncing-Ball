using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    private void Start ( )
    {
     
    }

    public void ToggleMute ( )
    {
        if ( GameManager. mute )
        {
            GameManager. mute=false;
        }
        else
        {
            GameManager. mute=true;
        }
    }

    public void QuitGame ( )
    {
        Application. Quit ( );
    }
}
