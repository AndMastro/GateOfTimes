using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour {

    public bool walk;
    private float oldY;
    private GameObject player;
    private GameObject mainCamera;
    private const float ACC_RATE = 5f;
    Vector3 accelerationDir;

    void Start ()
    {
        walk = true;
        player = this.gameObject;
        mainCamera = player.transform.GetChild(0).gameObject;
        oldY = Input.acceleration.y;
    }
	
	void Update () {
        float actualY = Input.acceleration.y;
        float deltaY = Mathf.Abs(oldY - actualY);

        Vector3 newPlayerRot = new Vector3(transform.localRotation.eulerAngles.x, mainCamera.transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        
        transform.rotation = Quaternion.Euler(newPlayerRot);
        
        Debug.Log("Player rot: " + transform.rotation);
        Debug.Log("Camera rot: " + mainCamera.transform.rotation);
        
        if (walk
        {
            Debug.Log("Walking mode");

            accelerationDir = Input.acceleration;
            
           if (accelerationDir.sqrMagnitude >= 4f){ //check if it is better or just checking y is enough (and better)
            //immplement movemement towards x dir of the camera BUT in players coordinates. so move of (0, 0, accelerationDir.sqrMagnitude / 2, Space.Self) in cam coord transformed in palyer coord
            transform.Translate(0, 0, accelerationDir.sqrMagnitude / 2, Space.Self);

            }
//in other script for camera. gtransform the (0,0,x) of the camera into world coord and let the parent (player) move with those coordinates.
        }
        else { //overboard code
            float xVel = Input.acceleration.x;
            float zVel = -Input.acceleration.z;
            Debug.Log("Overboard mode");
            Debug.Log("x: " + xVel, this.gameObject);
            Debug.Log("z: " + zVel, this.gameObject);

            transform.Translate(ACC_RATE * xVel, 0, ACC_RATE * zVel, Space.Self); 
        }
    }
}
