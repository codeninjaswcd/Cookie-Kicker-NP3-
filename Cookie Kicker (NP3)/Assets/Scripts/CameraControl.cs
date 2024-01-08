using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    [Header("Camera")]
    public GameObject target;
    public float min_x;
    public float max_x;
    private float newX;

    void Update(){
        transform.position = new Vector3(target.transform.position.x,0,transform.position.z);
        newX=transform.position.x;
        if(transform.position.x>max_x){
            newX=max_x;
        }else if(transform.position.x<min_x){
            newX=min_x;
        }
        transform.position = new Vector3(newX,0,transform.position.z);
        //print(newX);
    }
}