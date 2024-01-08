using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartingText : MonoBehaviour
{
    [Header("General")]
    public GameManager GameManager;
    public Cookie Cookie;
    [Header("Starting Text")]
    public string[] startingText;
    public Text startingTextText;
    public float delayTime;
    public int occurrences;
    [SerializeField] private AudioClip countdownSound;
    
    void Start(){
        //print(SceneManager.GetActiveScene().buildIndex);
        StartText();
    }
    public void StartText(){
        GameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        Cookie = GameObject.Find("Cookie").GetComponent<Cookie>();
        startingTextText=GameObject.Find("Starting Text").GetComponent<Text>();
        startingTextText.text="";
        occurrences=0;
        //Time.timeScale = 0f;
        GameManager.SetGameStatus(1);
        InvokeRepeating("DisplayStartText", 0f, delayTime);
    }

    public void DisplayStartText(){
        if(occurrences>=startingText.Length){
            startingTextText.text="";
            //Time.timeScale = 1f;
            GameManager.SetGameStatus(0);
            Cookie.GameManagerStart();
            Destroy(this);
            return;            
        }
        soundManager.Instance.PlaySound(countdownSound);
        startingTextText.text=startingText[occurrences];
        occurrences++;
    }
}