using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic.Dictionary;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Cookie Cookie;

    public Dictionary<string, int> Upgrades = new Dictionary<string, int>();

    public Transition Transition;

    [Header("Score")]
    public float tScore;

    public Text scoreText;

    [Header("Game Status")]
    public int gameStatus;
    
    [Header("Music")]
    [SerializeField] private AudioClip _clip;

    public void Start()
    {
        tScore = 0;
        Upgrades.Add("level", 0); //added
        Upgrades.Add("mouse", 0); //added
        Upgrades.Add("points", 0); //added
        Upgrades.Add("speed", 0); //added
        Upgrades.Add("time", 0); //added
        soundManager.Instance.PlayMusic(_clip);
    }

    public void Update()
    {
        GetQuantity("level");
        Cookie = GameObject.Find("Cookie").GetComponent<Cookie>();
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        //Transition = GameObject.Find("Transition").GetComponent<Transition>();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            scoreText.text = "Cookie : " + tScore.ToString();
        }
        else
        {
            //print("the scene is not the shop");
        }
        //print(Upgrades["level"]);
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void GameEnd(int switchScene)
    {
        tScore += Mathf.Floor(Cookie.score/8);
        scoreText.text = tScore.ToString();

        //print(tScore);
        //Transition.TransitionScene(switchScene);
        SceneManager.LoadScene(switchScene);
    }

    public void IncreaseUpgrade(string upgrade, int amount, float cost)
    {
        Upgrades[upgrade] = Upgrades[upgrade] + amount;
        ChangeTScore(cost*-1f);
        //print(Upgrades[upgrade]);
    }

    public void SetGameStatus(int newStatus)
    {
        gameStatus = newStatus;
    }

    public void ChangeTScore(float amount)
    {
        tScore += amount;
        scoreText.text = tScore.ToString();
    }

    public int GetQuantity(string fortnite)
    {
        //print(Upgrades[fortnite]);
        return Upgrades[fortnite];
    }
}
