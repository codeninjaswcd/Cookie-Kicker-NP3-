using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("General")]
    public GameManager GameManager;
    SpriteRenderer spriteR;
    Collider2D Collider;
    public ParticleSystem MoneyParticle;
    [Header("Cost")]
    public float cost;
    [Header("Quantity")]
    public int quantity;
    [Header("Sound")]
    [SerializeField] private AudioClip _clip;

    public void Update(){
        if(GameManager.tScore>=cost){
            spriteR.color = new Color(1f,1f,1f, 1f); //normal
            Collider.enabled = true;
        }else{
            spriteR.color = new Color(1f,1f,1f, 0.5f); //transparent
            Collider.enabled = false;
        }
    }
    public void Start(){
        GameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.color = Color.white;
        Collider = GetComponent<BoxCollider2D>();
        MoneyParticle = this.transform.Find("Purchase").gameObject.GetComponent<ParticleSystem>();
        MoneyParticle.Pause();
        quantity=0;
    }
    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag=="Cookie"){
            Purchase();
        }
    }
    public void Purchase(){
        //print("purchase - " + gameObject.name + " : costs - " + GameManager.tScore);
        if(GameManager.tScore>=cost){
            soundManager.Instance.PlaySound(_clip);
            GameManager.IncreaseUpgrade(gameObject.name,1,cost);
            MoneyParticle.Play();
            print(cost);
            if(this.gameObject.name=="level"){
                cost*=4;
                if(quantity>2){
                    cost=999999999999999999;
                    quantity=4;
                }
            }else{
                cost*=1.2f; cost+=(quantity*4); cost=Mathf.Floor(cost);
            }
            quantity+=1;
            print(cost);
        }
    }
}
