using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePlatformSwitch : MonoBehaviour
{

    public GameObject orangePlatform;
    private bool platformSwitch = false;
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
            orangePlatform.SetActive(platformSwitch);
        }
        else if (platformSwitch == true && Input.GetKeyDown(KeyCode.E))
        {
            platformSwitch = false;
            orangePlatform.SetActive(platformSwitch);
        }
        else
        {
            return;
        }

    }
}
