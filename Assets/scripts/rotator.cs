using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float rotationSpeed = 150;

    public void Start ( )
    {
      //  Cursor. lockState=CursorLockMode. Locked;
    }

    private void Update ( )
    {
        if ( !GameManager. isGameStarted )
        {
            return;
        }

        //mobile
        if ( Input. touchCount>0&&Input. GetTouch ( 0 ). phase==TouchPhase. Moved )
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform. Rotate ( 0, -xDelta*50*Time. deltaTime, 0 );
        }


        //pc
        if ( Input. GetMouseButton ( 0 ) )
        {
            float mouseX= Input.GetAxisRaw("Mouse X");
            transform. Rotate ( 0, mouseX*rotationSpeed*Time. deltaTime, 0 );
        }
    }
}
