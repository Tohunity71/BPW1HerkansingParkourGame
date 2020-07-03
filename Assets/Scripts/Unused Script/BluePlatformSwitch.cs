using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatformSwitch : MonoBehaviour     
{

    public GameObject bluePlatform;
    private bool platformSwitch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //BluePlatform.GetComponent<GameObject>();

        if (platformSwitch == false && Input.GetKeyDown(KeyCode.E))
        {
            platformSwitch = true;
            bluePlatform.SetActive(platformSwitch);
        }
        else if (platformSwitch == true && Input.GetKeyDown(KeyCode.E))
         {
            platformSwitch = false;
            bluePlatform.SetActive(platformSwitch);
        }
        else
        {
            return;
        }

    }
}
