using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTeleport : MonoBehaviour
{
    public float orbThrowDistance;
    [SerializeField] private Transform Player;
    GameObject prefab;
    private GameObject orbProjectile;
    private bool orbSpawn = false;
    private bool orbCooldownBool = false;



    void Start()
    {
        prefab = Resources.Load("orbTeleport") as GameObject;
    }

    void Update()
    {
        //Dit is de teleportatie mechanic. Als je linker muisknop drukt dan gooi je een bal. 
        if (Input.GetMouseButtonDown(0) && orbSpawn == false && orbCooldownBool == false)
        {
            orbSpawn = true;
            orbProjectile = Instantiate(prefab) as GameObject;
            orbProjectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody orbTeleportRB = orbProjectile.GetComponent<Rigidbody>();
            orbTeleportRB.velocity = Camera.main.transform.forward * 25;
            StartCoroutine(orbLifetime());
        }
        //Nadat de bal gegooit is kan je op rechtermuisknop drukken om ernaar toe te teleporteren. 
        else if (Input.GetMouseButtonDown(1) && orbSpawn == true)
        {
            orbSpawn = false;
            orbCooldownBool = true; // omdat hij nu true is kan ik niet meer schieten.
            Player.transform.position = orbProjectile.transform.position;
            Destroy(orbProjectile);
            StartCoroutine(orbCooldown());
        }
        

    }
    // Dit is een cool down die begint als je de teleportatie niet gebruikt maar de bal wel hebt gegooit
    private IEnumerator orbLifetime()
    {
        yield return new WaitForSeconds(4.5f);
        if (orbSpawn == true)
            orbSpawn = false;
            Destroy(orbProjectile);
    }

    //Dit is de cool down nadat je bent geteleporteerd. Je kan geen nieuwe bal meer gooien na aantal seconden. 
    private IEnumerator orbCooldown()
    {
        yield return new WaitForSeconds(5f);
        orbCooldownBool = false;
    }

}

