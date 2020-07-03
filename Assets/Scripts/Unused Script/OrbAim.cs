using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAim : MonoBehaviour { 

    [SerializeField] private Transform Player;
    private bool orbSpawn = false;
    GameObject prefab;
    private GameObject orbProjectile;


    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("AimIndicator") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            orbSpawn = true;
            orbProjectile = Instantiate(prefab) as GameObject;
            orbProjectile.transform.position = Player.transform.position + Camera.main.transform.forward * 5;

        } 



    }
}
