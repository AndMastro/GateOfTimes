using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMovementType
{
    LEVITATE, RUN
}

public class InputMovement
{
    public static InputMovementType CurrentInputMovementType;
}

public class ScreenTapScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject GvrReticle;

    public void Update()
    {
        RaycastHit raycastHit = new RaycastHit();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(this.GvrReticle.transform.position, this.GvrReticle.transform.TransformVector(Vector3.forward), out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "Terrain")
                {
                    Vector3 newPosition = new Vector3(raycastHit.point.x,
                        raycastHit.point.y + this.Player.GetComponent<CapsuleCollider>().height / 2.0f, raycastHit.point.z);

                    this.Player.transform.position = newPosition; return;
                }

                switch (InputMovement.CurrentInputMovementType)
                {
                    case InputMovementType.LEVITATE:
                    { InputMovement.CurrentInputMovementType = InputMovementType.RUN; }
                    break;
                    case InputMovementType.RUN:
                    { InputMovement.CurrentInputMovementType = InputMovementType.LEVITATE; }
                    break;
                }
            }
            else
            {
                switch (InputMovement.CurrentInputMovementType)
                {
                    case InputMovementType.LEVITATE:
                        {
                            InputMovement.CurrentInputMovementType = InputMovementType.RUN;
                        }
                        break;
                    case InputMovementType.RUN:
                        {
                            InputMovement.CurrentInputMovementType = InputMovementType.LEVITATE;
                        }
                        break;
                }
            }
        }
    }
}
