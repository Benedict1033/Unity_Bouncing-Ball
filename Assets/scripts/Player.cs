using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody RB;
    public float bouceForce = 6;

    AudioManager audioManager;

    private void Start ( )
    {
        audioManager=FindObjectOfType<AudioManager> ( );
    }

    private void OnCollisionEnter ( Collision col)
    {
        audioManager. Play ( "bounce" );

        RB. velocity=new Vector3 ( RB. velocity. x, bouceForce, RB. velocity. z );

        string materialName = col.transform.GetComponent<MeshRenderer>().material.name;

        if ( materialName=="safe(Instance)" )
        {

        }
        else if(materialName=="unsafe (Instance)" )
        {
            //the ball hits the unsafe area
            GameManager. gameOver=true;
            audioManager. Play ( "game over" );
        }
        else if(materialName=="Complete (Instance)"&&!GameManager.levelCompleted )
        {
            //We Complete the Level
            GameManager.levelCompleted=true;
            audioManager. Play ( "win" );

        }
    }
}
