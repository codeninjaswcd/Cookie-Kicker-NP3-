using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public float transitionSpeed;
    public bool collided;
    private int safety;
    public GameManager GameManager;
    public RectTransform rect;
    

    void Start(){
        GameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        TransitionScene(0);
    }
    public void TransitionScene(int scene){
        
        
        
    }
}
