using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    Transform Player;

    private void Start ( )
    {
        Player=GameObject. FindGameObjectWithTag ( "Player" ).transform;
    }

    private void Update ( )
    {
        if(transform.position.y >Player. position. y )
        {
            GameManager. numOfPassedRing++;
            GameManager. score++;
            FindObjectOfType<AudioManager> ( ). Play ( "whoosh" );
            Destroy ( gameObject );
        }
    }
}
