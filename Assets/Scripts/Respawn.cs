using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;


    //Als de speler de onzichtbare vloer aanraakt onderaan het level dant teleporteert hij terug naar de respawn point. 
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = respawnPoint.transform.position;

    }

}

