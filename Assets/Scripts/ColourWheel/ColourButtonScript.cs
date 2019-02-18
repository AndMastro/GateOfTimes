using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourButtonScript : MonoBehaviour, ITimedEventHandler
{
    public GameObject CrystalToChange;

    private Color MyColour;
    
    public void Start()
    {
        this.MyColour = this.GetComponent<Image>().color;
    }

    public void HandleTimedInput()
    {
        Material crystalMaterial = this.CrystalToChange.GetComponent<Renderer>().material;

        crystalMaterial.SetColor("_Color", this.MyColour);
        crystalMaterial.SetColor("_EmissionColor", this.MyColour);
    }
}
