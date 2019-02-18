using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTeleportationBehaviour : MonoBehaviour
{
    public GameObject GVRPointer;
    public GameObject Player;

    public void Teleportation()
    {
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(GVRPointer.transform.position, GVRPointer.transform.TransformVector(Vector3.forward), out raycastHit))
        {
            if (raycastHit.collider.gameObject.name == "Terrain")
            {
                Player.transform.position = new Vector3(raycastHit.point.x, Player.transform.position.y, raycastHit.point.z);
            }
           
        }
    }
}
