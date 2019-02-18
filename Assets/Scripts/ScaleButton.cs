using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleButton : MonoBehaviour, ITimedEventHandler
{
    public GameObject animationObject;
    private bool scaleActive = false;
    private float startGazeTime = -1f;

    public void Update()
    {
        if (scaleActive)
        {
            float currentTime = Time.time;
            if (startGazeTime > 0 && currentTime - startGazeTime > 3f)
            {
                Vector3 currentScale = animationObject.transform.localScale;
                Debug.Log(this.gameObject.name);
                string name = this.gameObject.name;
                switch (name)
                {
                    case "IncreaseZ":
                        animationObject.transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z + 0.25f);
                        break;
                    case "DecreaseZ":
                        animationObject.transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z - 0.25f);
                        break;
                    case "IncreaseX":
                        animationObject.transform.localScale = new Vector3(currentScale.x + 0.25f, currentScale.y, currentScale.z);
                        break;
                    case "DecreaseX":
                        animationObject.transform.localScale = new Vector3(currentScale.x - 0.25f, currentScale.y, currentScale.z);
                        break;

                }
                startGazeTime = currentTime;
            }
        }
    }
    public void OnTriggerEnter()
    {

    }

    public void OnTriggerExit()
    {
        scaleActive = false;
        startGazeTime = -1f;
    }

    public void OnTriggerClick()
    {

    }

    public void HandleTimedInput()
    {
        Vector3 currentScale = animationObject.transform.localScale;
        Debug.Log(this.gameObject.name);
        string name = this.gameObject.name;
        switch (name)
        {
            case "IncreaseZ":
                animationObject.transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z + 2f);
                break;
            case "DecreaseZ":
                animationObject.transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z - 2f);
                break;
            case "IncreaseX":
                animationObject.transform.localScale = new Vector3(currentScale.x + 2f, currentScale.y, currentScale.z);
                break;
            case "DecreaseX":
                animationObject.transform.localScale = new Vector3(currentScale.x - 2f, currentScale.y, currentScale.z);
                break;

        }
        scaleActive = true;
        startGazeTime = Time.time;
    }
}
