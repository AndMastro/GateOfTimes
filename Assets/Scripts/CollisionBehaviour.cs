using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("COLLIDED");
    }

    void OnCollisionStay(Collision collisionInfo)
    {

    }

    void OnCollisionExit(Collision collisionInfo)
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided with something");
        if (collider.gameObject.name.Equals("FallingPlane"))
        {
            this.transform.position = new Vector3(15.4f, -39.06782f, -114.8f);
            this.transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, -8.115001f, 0));
        }
    }
}
