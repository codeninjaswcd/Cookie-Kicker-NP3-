using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public float yEntrance; //-250
    public float yExit;
    public bool oneWay;
    
    public void Update(){
        if(transform.position.y<yEntrance){
            transform.position=new Vector3(transform.position.x,yExit,transform.position.z);
        }
        if(oneWay){ 
            return; 
        }
        if(transform.position.y>yExit){
            transform.position=new Vector3(transform.position.x,yEntrance,transform.position.z);
        }
    }
}