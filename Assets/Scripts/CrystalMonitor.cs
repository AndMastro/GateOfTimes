using UnityEngine;

using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CrystalMonitor : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject player;
    public GameObject music;
    public GameObject sound;
    public GameObject portal;

    private bool sameColor = false;
    private List<GameObject> Crystals;

    void Start()
    {
        this.Crystals = FindObjectsOfType<GameObject>().Where(@object => @object.tag == "Crystal" && @object.activeSelf == true).ToList();
    }

    void Update()
    {
        List<Color> crystalColours = new List<Color>();

        foreach(GameObject crystal in this.Crystals)
            crystalColours.Add(crystal.GetComponent<Renderer>().material.color);

        if (!sameColor)
        {
            if (crystalColours.Distinct().Count() == 1)
            {
                Debug.Log("Crystal Equals");
                  
                StartCoroutine(Sleep());                  
                
                sameColor = true;
            }
        }
        
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2);

        player.transform.position = new Vector3(15.4f, -39.06782f, -114.8f);
        player.transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, -8.115001f, 0));

        yield return new WaitForSeconds(3);

        music.GetComponent<AudioSource>().Stop();
        
        this.portal.GetComponent<AudioSource>().Play();

        sound.GetComponent<AudioSource>().PlayDelayed(1.5f);

        this.leftDoor.GetComponent<Animation>().Play();
        this.rightDoor.GetComponent<Animation>().Play();
    }
}
