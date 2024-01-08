using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float startSize;
    public float sizeDecrease;
    public float minSize;
    public float currentSize;
    public float movDegree;
    public float currentMov;
    public ParticleSystem StartParticle;
    public GameManager GameManager;
    [Header("Sound")]
    [SerializeField] private AudioClip startHit;

    void Start(){
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartParticle = this.transform.Find("Purchase").gameObject.GetComponent<ParticleSystem>();
        StartParticle.Pause();
    }
    void Update(){
        // this.transform.position += new Vector3(currentMov,currentMov,0);
        // currentMov*=0.3f;
        if(currentSize<minSize-currentSize+0.0001f){
            //GameManager.GameEnd(0);
            SceneManager.LoadScene(1);
            //print("god bless the queen");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Cookie"){
            this.transform.localScale += new Vector3(sizeDecrease,sizeDecrease,0);
            currentSize+=sizeDecrease;

            this.transform.Find("Purchase").gameObject.transform.localScale += new Vector3(sizeDecrease,sizeDecrease,0); 
            soundManager.Instance.PlaySound(startHit);
            StartParticle.Play();
            // currentMov=movDegree*-(Random.Range(10,20)/10*((Mathf.Floor(Random.Range(-1,0)))*2)+1);

        }
    }
}
