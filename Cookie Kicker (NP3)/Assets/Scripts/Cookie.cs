using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public Transform target;
    public GameObject GameManagerObject;
    public GameManager GameManager;

    [Header("Texturing")]
    
    public SpriteRenderer sr;
    public Sprite[] CookieLives;
    public float breakCooldown;
    public float breakCooldownStart;
    public int BrokenAmount;

    [Header("Rigidbody")]
    public Rigidbody2D rb2D;

    public float maxVelocity;
    //public float maxGravity;

    public float forceMultiplier;

    [Header("Score")]
    public Text scoreText;
    public float score;
    public float scoreAdded;
    public float scoreTime;
    [Header("Time")]
    public Text timeText;
    public float seconds;
    private string minDis;
    private string secDis;
    public float time;
    
    [SerializeField] private AudioClip lastThreeSeconds;


    public void Start() {
        GameManagerObject=GameObject.Find("Game Manager");
        GameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        score=0;
        scoreAdded=1;
        seconds=time+(GameManager.GetQuantity("time")*5)+1;
        rb2D = gameObject.GetComponent<Rigidbody2D>();  
        scoreText.text="Score : 0";

        maxVelocity+=(GameManager.GetQuantity("speed")*10f);
        if(maxVelocity>1000){
            maxVelocity=1000;
        }

        if(SceneManager.GetActiveScene().buildIndex==2){
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }else{
            rb2D.bodyType = RigidbodyType2D.Static;
        }
        Score();
        Time();
    }
    public void GameManagerStart() {
        //print("test");
        InvokeRepeating("Score", scoreTime, scoreTime);
        InvokeRepeating("Time", 0, 1f);
    }
    
    public void Update() {
        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxVelocity); //velocity cannot excede maxVelocity
        breakCooldown-=1;
        if(BrokenAmount>=CookieLives.Length){
            if(SceneManager.GetActiveScene().buildIndex==1){
                GameManager.GameEnd(2); //game
            }
        }else{
            sr.sprite=CookieLives[BrokenAmount];
        }

        //print(GameManager.gameStatus);
        if(GameManager.gameStatus==0 || SceneManager.GetActiveScene().buildIndex == 3){
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
        //rb2D.gravityScale = Vector2.ClampMagnitude(rb2D.gravityScale, maxGravity); //gravity cannot excede maxGravity
        //print(GameManager.GetQuantity("level"));

    }
    
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Solid"){
            scoreAdded/=2;
            if(breakCooldown<0){
                BrokenAmount+=1;
                breakCooldown=breakCooldownStart;
            }
        }
        if(other.gameObject.tag == "Lava" || other.gameObject.tag == "Spike"){
            scoreAdded=1;
            if(breakCooldown<0){
                BrokenAmount+=2;
                breakCooldown=breakCooldownStart;
            }
            if(other.gameObject.tag == "Lava"){
                score*=0.75f;
            }else{
                score*=0.9f;
            }
            if(score<0){
                score=0;
            }
        }
        //rb2D.sharedMaterial = null;
        if(other.gameObject.tag == "Player"){
            scoreAdded+=1f;
        }
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Solid"){}
    }

    public void Score(){
        score+=(scoreAdded*((GameManager.GetQuantity("points") / 4)+1));
        //score--;
        score=Mathf.Floor(score);
        if(SceneManager.GetActiveScene().buildIndex==1){
            scoreText.text="Crumb : " + score.ToString();
        }
    }

    public void Time(){
        seconds-=1;
        string display="";
        //display=Mathf.Floor(seconds/60).ToString()+":"+(seconds%60).ToString();
        
        minDis=Mathf.Floor(seconds/60).ToString();
        display = minDis;
        display=display+":";

        secDis=/*Mathf.Abs*/((seconds%60)).ToString();
        secDis=secDis.PadLeft(2,'0');
        display=display+secDis;
        timeText.text="Time : " + display.ToString(); //secDis.ToString().PadLeft(2, '0')
        if(seconds<=3){
            soundManager.Instance.PlaySound(lastThreeSeconds);
        }
        if(seconds<=0){
            GameManager.GameEnd(2);
        }
    }
}