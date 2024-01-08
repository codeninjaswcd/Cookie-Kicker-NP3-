using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{
    public GameManager GameManager;

    [Header("Mouse")]
    public bool activate;
    public float zAxisPos;

    //public Texture2D cursorTexture;
    public float offsetX;

    public float offsetY;

    public float cooldown;
    public float cooldownMax;

    public float cooldownSpeed;

    [Header("Boundaries")]
    public float max_x;

    public float min_x;

    public float max_y;

    public float min_y;

    private float newX;

    private float newY;

    [Header("Collision")]
    public Collider2D Collider;
    public bool cookieCollision;
    public bool clickSound;

    SpriteRenderer spriteR;

    [Header("Sound")]
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip clickMiss;
    void Start() {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.color = Color.white;
        Cursor.visible = false;
        cooldownMax = 25;
        cooldownMax += (GameManager.GetQuantity("mouse")*10);
        cooldown = 0;
        cookieCollision=false;
        clickSound=true;

        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        activate = true;
    }

    void Update()
    {
        //if (GameManager.gameStatus == 0 || SceneManager.GetActiveScene().buildIndex == 3)
        //{
            cooldown += cooldownSpeed;
            if (cooldown > cooldownMax)
            {
                cooldown = cooldownMax;
            }
            if (Input.GetMouseButtonUp(0) && cooldown == cooldownMax)
            {
                cooldown = 0;
                clickSound=true;
            }
            if (cooldown == cooldownMax)
            {
                Collider.enabled = false;
                spriteR.color = Color.white;
            }
            else
            {
                Collider.enabled = true;
                spriteR.color = new Color(1f, cooldown / 50, cooldown / 50, 1f); //Color.red;
                
                if(clickSound){
                    clickSound=false;
                    if(cookieCollision){
                        soundManager.Instance.PlaySound(click);
                    }else{
                        soundManager.Instance.PlaySound(clickMiss);
                    }
                }

            }
            if (cooldown > (cooldownMax*1.25) && cooldown < cooldownMax)
            {
                spriteR.color = Color.red;
            }
            if (activate)
            {
                //Cursor.visible = false;
                gameObject.SetActive(true);
                Vector3 mouse = Input.mousePosition;
                transform.position =
                    new Vector3(mouse.x + offsetX, mouse.y + offsetY, zAxisPos);
                Boundaries(transform.position.x, transform.position.y);
                /* if(transform.position.x > max_x || transform.position.x < min_x || transform.position.y > max_y || transform.position.y < min_y){
                transform.position = new Vector3(mouse.x-offsetX, mouse.y-offsetY, mouse.z); } */
            }
            else
            {
                gameObject.SetActive(false);
                //Cursor.visible = true;
            } //boundaries
        //}
    }

    private void Boundaries(float xPos, float yPos)
    {
        newX = xPos;
        newY = yPos;
        if (xPos > max_x)
        {
            newX = max_x;
        }
        else if (xPos < min_x)
        {
            newX = min_x;
        }
        if (yPos > max_y)
        {
            newY = max_y;
        }
        else if (yPos < min_y)
        {
            newY = min_y;
        }
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag=="Cookie"){
            cookieCollision=true;
        }else{
            cookieCollision=false;
        }
    }
}