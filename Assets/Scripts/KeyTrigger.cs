using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject Key;
    public GameObject Player;
    public GameObject Platform;
    private int howManyKeys;
    [SerializeField] private Transform respawnPoint;

    void Start()
    {
        Platform.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            howManyKeys++;
            Player.transform.position = respawnPoint.transform.position;
            Destroy(Key);
            Platform.SetActive(true);
            Debug.Log("Ik heb" + howManyKeys + "sleutels");
        }
    }
}
