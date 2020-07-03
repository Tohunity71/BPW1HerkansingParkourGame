using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{

    public GameObject bluePlatform;
    public GameObject orangePlatform;
    public GameObject[] orange;
    List<GameObject> orangelist;
    List<GameObject> bluelist;
    public GameObject[] blue;
    private bool platformSwitch = true;

    string[] Orange = { "OrangeWall", "orange" };
    string[] Blue = { "BlueWall", "blue" };

    // Start is called before the first frame update
    void Start()
    {
        orangelist = new List<GameObject>();
        foreach (string kleur in Orange)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag(kleur))
            {
                orangelist.Add(o);
            }

            //Orange settings
            //Vult Array[orange] met alle game objecten met de tag "orange"
            orange = GameObject.FindGameObjectsWithTag(kleur);
            
            // Voor elk game object in Array[orange] maakt hij ze "false"
            foreach (GameObject orangeObjects in orange)
            {
                orangeObjects.SetActive(false);
            }
        }

        bluelist = new List<GameObject>();
        foreach (string kleur in Blue)
        {
            foreach (GameObject b in GameObject.FindGameObjectsWithTag(kleur))
            {
                bluelist.Add(b);
            }
            // blue settings
            //Vult Array[orange] met alle game objecten met de tag "orange"
            blue = GameObject.FindGameObjectsWithTag(kleur);

            // Voor elk game object in Array[orange] maakt hij ze "false"
            foreach (GameObject blueObjects in blue)
            {
                blueObjects.SetActive(true);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (platformSwitch == false && Input.GetKeyDown(KeyCode.E))
        {
            platformSwitch = true;

                foreach (GameObject blueObjects in bluelist)
                {
                blueObjects.SetActive(platformSwitch);
                }

                foreach (GameObject orangeObjects in orangelist)
            {
                orangeObjects.SetActive(!platformSwitch);

            }
        }
        else if (platformSwitch == true && Input.GetKeyDown(KeyCode.E))
        {
            platformSwitch = false;

            foreach (GameObject blueObjects in bluelist)
            {
                blueObjects.SetActive(platformSwitch);
            }

                foreach (GameObject orangeObjects in orangelist)
            {
                orangeObjects.SetActive(!platformSwitch); 
            }
        }
        else
            {
                return;
            }

    }
}
