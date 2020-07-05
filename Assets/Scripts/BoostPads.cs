using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPads : MonoBehaviour
{
    private PlayerController PC;
    public float boostValue;
    

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Verschillende platforms met ablities
    private void OnCollisionStay(Collision collision)
    {
        //Boost Platform
        if (collision.gameObject.tag == "Player")
        {
            PC.jumps = 2;
            if (this.gameObject.tag == "PlatformBoost")
            {                
                PC.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * boostValue, ForceMode.Impulse);
            } else
            {              
                PC.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * boostValue, ForceMode.Impulse);
            }

        }
    }
}
