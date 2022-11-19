using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject [] helixRings;
    public float ySpawn =0;
    public float ringsDistance =5;

    public int numberOfRings;

    private void Start ( )
    {
        numberOfRings=GameManager. currentLevelIndex+5;

        //Spawn helix rings
        for (int i =0; i<numberOfRings; i++ )
        {
            //spawn ring 0
            if ( i==0 )
            {
                SpawnRing ( 0 );
            }
            //spawn 1 to last 2 
            else
            {
                //Random.Range is ( >= , < ) 
                SpawnRing ( Random. Range ( 1, helixRings. Length-1 ) );
            }
        }
        //spwan the last ring
        SpawnRing ( helixRings. Length-1 );
    }

    public void SpawnRing (int ringIndex )
    {
        GameObject Go=(GameObject) Instantiate ( helixRings [ ringIndex ], transform. up*ySpawn, Quaternion. identity );
        Go. transform. parent=transform; 
        ySpawn-=ringsDistance;
    }

}
