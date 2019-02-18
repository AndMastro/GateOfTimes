using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour
{

    private static bool walk;
    public bool debugMode;
    private float oldY;
    private GameObject mainCam;
    private GameObject player;
    private const float ACC_RATE = 5f;
    Vector3 accelerationDir;
    Vector3 worldMovement;
    private static bool hasCollided = false;
    public float fixedX = 0.2f;
    public float fixedZ = 0.2f;

    void Start()
    {
        walk = true;
        debugMode = false;
        mainCam = this.gameObject;
        player = mainCam.transform.parent.gameObject;
        oldY = Input.acceleration.y;
        InputMovement.CurrentInputMovementType = InputMovementType.RUN;
    }

    void Update()
    {
        float actualY = Input.acceleration.y;
        float deltaY = Mathf.Abs(oldY - actualY);

        if (!hasCollided)
        {
            if (InputMovement.CurrentInputMovementType == InputMovementType.RUN)
            {
                Debug.Log("Running mode");

                accelerationDir = Input.acceleration;

                if (accelerationDir.sqrMagnitude >= 4f)
                { //check if it is better or just checking y is enough (and better)
                  //immplement movemement towards x dir of the camera BUT in players coordinates. so move of (0, 0, accelerationDir.sqrMagnitude / 2, Space.Self) in cam coord transformed in palyer coord
                    worldMovement = transform.TransformDirection(0, 0, accelerationDir.sqrMagnitude / 2);
                    player.transform.Translate(worldMovement.x, 0, worldMovement.z, Space.World);

                }
                //in other script for camera. gtransform the (0,0,x) of the camera into world coord and let the parent (player) move with those coordinates.
            }
            else
            { //overboard code
                Debug.Log("Levitation mode");
                float xVel = Input.acceleration.x;
                float zVel = -Input.acceleration.z;

                float xActive;
                float zActive;
                if (zVel >= 0.1f) zActive = 1f; else zActive = 0;
                if (xVel >= 0.1f || xVel <= -0.1f) xActive = 1f; else xActive = 0;
                
                worldMovement = transform.TransformDirection(xVel*xActive, 0, (0.4f + 1.1f*zVel)*(zActive));
                player.transform.Translate(worldMovement.x, 0, worldMovement.z, Space.World);
            }

            if (debugMode)
            {
                Vector3 debugMove = transform.TransformDirection(0, 0, fixedZ);
                player.transform.Translate(debugMove.x, 0, debugMove.z, Space.World);
            }
        }
    }

    public static bool GetWalk()
    {
        Debug.Log("Walk is: " + walk);
        return walk;
    }

    public static void SetWalk(bool value)
    {
        walk = value;
        Debug.Log("Walk set to: " + walk);
    }

    public static void SetCollision(bool value)
    {
        hasCollided = value;
    }
}
