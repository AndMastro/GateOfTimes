using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GvrReticalLoadScript : MonoBehaviour
{
    public GameObject MenuLoad;

    public void Update()
    {
        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out raycastHit))
        {
            MenuLoad.transform.position = raycastHit.point - 0.1f * this.transform.TransformDirection(Vector3.forward);
        }
    }
}
