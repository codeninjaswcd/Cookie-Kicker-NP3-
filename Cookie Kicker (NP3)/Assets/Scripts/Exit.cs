using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Cookie"){
            SceneManager.LoadScene(1);
        }
    }
}
