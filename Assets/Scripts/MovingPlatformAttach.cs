using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformAttach : MonoBehaviour
{
    public GameObject Player;
    private PlatformSwitch Switch;
    //public Rigidbody Player;


    private void Start()
    {
        Switch = GameObject.Find("Manager").GetComponent<PlatformSwitch>();
        //Player = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;   
            Switch.MP = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
            Switch.MP = false;
        }
    }

    private void Stopped()
    {
        Player.transform.parent = null;
        Switch.MP = false;
        Debug.Log("IK BEN VRIJ");
    }

    private void stayed()
    {
        if (Switch.MP == true)
        {
            Player.transform.parent = transform;
        }
    }

}
