using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject[] leftWalls;
    public GameObject[] rightWalls;
    public GameObject[] ceilings;
    public GameObject[] grounds;
    public int leftWallRandom;
    public int rightWallRandom;
    public int ceilingRandom;
    public int groundRandom;
    public int levelMax;
    
    public void Start(){
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        levelMax=GameManager.GetQuantity("level");
        levelMax+=1;
        Create();
    }

    //left wall -763, 22, -10
    //right wall 1311, 22, -10
    public void Create(){
        leftWallRandom=Random.Range(0,levelMax);
        rightWallRandom=Random.Range(0,levelMax);
        ceilingRandom=Random.Range(0,levelMax);
        groundRandom=Random.Range(0,levelMax);

        GameObject leftWall = leftWalls[leftWallRandom];
        GameObject rightWall = rightWalls[rightWallRandom];
        GameObject ceiling = ceilings[ceilingRandom];
        GameObject ground = grounds[groundRandom];

        Instantiate(leftWall, leftWall.transform.position, leftWall.transform.rotation);
        Instantiate(rightWall, rightWall.transform.position, rightWall.transform.rotation);
        Instantiate(ceiling, ceiling.transform.position, ceiling.transform.rotation); //200, 0, -10
        Instantiate(ground, ground.transform.position, ground.transform.rotation); //350, -360, -10
    }
}