using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject EndScreen;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            EndScreen.gameObject.SetActive(true);
        }
    }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
        }
    }


