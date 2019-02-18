using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationScript : MonoBehaviour
{
    public GameObject Reticle;
    public GameObject animationObject;
    private bool activeTranslation = false;

    void Start()
    {
        Debug.Log("STARTED");
    }


    void Update()
    {
        
        if (activeTranslation)
        {
            Ray ray = new Ray(Reticle.transform.position, Reticle.transform.forward);
            animationObject.transform.position = ray.GetPoint(4);
        }
    }

    public void OnTriggerEnter()
    {

    }

    public void OnTriggerExit()
    {

    }

    public void OnTriggerClick()
    {
        activeTranslation = !activeTranslation;
    }
}