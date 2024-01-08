using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    //[SerializeField] private AudioClip enterPipe;
    public void SwitchScene(int scene){
        //soundManager.Instance.PlaySound(enterPipe);
        SceneManager.LoadScene(scene);
    }
}
 