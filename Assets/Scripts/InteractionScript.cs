using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour, ITimedEventHandler
{
    public GameObject Menu;

    public void HandleTimedInput()
    {
        this.Menu.SetActive(!this.Menu.activeSelf);
    }
}
