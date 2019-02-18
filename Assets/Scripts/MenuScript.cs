using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject Player;

	void Update ()
    {
        Vector3 playerPosition = this.Player.transform.position;
        Vector3 playerPositionZeroY = new Vector3(playerPosition.x, this.transform.position.y, playerPosition.z);

        this.transform.LookAt(playerPositionZeroY);
        this.transform.Rotate(Vector3.up, 180.0f);
    }
}
