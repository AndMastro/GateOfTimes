using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TranslationScriptTimedGaze : MonoBehaviour, ITimedEventHandler
{
    public GameObject Reticle;
    public GameObject animationObject;
    private bool activeTranslation = false;
    private Vector3 oldPos;
    private float startDropTime = -1f;

    void Start()
    {
        Debug.Log("STARTED");
        oldPos = animationObject.transform.position;
    }


    void Update()
    {
        if (activeTranslation)
        {
            Ray ray = new Ray(Reticle.transform.position, Reticle.transform.forward);
            animationObject.transform.position = ray.GetPoint(8);
            Vector3 currentPos = animationObject.transform.position;
            if (Vector3.Distance(oldPos, currentPos) <= 0.05f && startDropTime == -1f)
            {
                Debug.Log("OBJECT STOPPED");
                startDropTime = Time.time;
            }
            else if (Vector3.Distance(oldPos, currentPos) > 0.05f)
            {
                Debug.Log("OBJECT MOVING");
                startDropTime = -1f;
            }

            if (startDropTime > 0 && Time.time - startDropTime >= 3f)
            {
                activeTranslation = !activeTranslation;
                startDropTime = -1f;
                Debug.Log("OBJECT RELEASED");
            }

            oldPos = currentPos;
        }
    }

    public void OnTriggerEnter()
    {

    }

    public void OnTriggerDrag()
    {

    }

    public void OnTriggerExit()
    {

    }

    public void OnTriggerStop()
    {
        HandleTimedInput();
    }

    public void OnTriggerClick()
    {

    }

    public void HandleTimedInput()
    {
        if (!activeTranslation) activeTranslation = !activeTranslation;
      
        Debug.Log(activeTranslation);

        Reticle.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Terrain"))
        {
            if (activeTranslation) activeTranslation = !activeTranslation;
            Reticle.SetActive(true);
        }
    }
}