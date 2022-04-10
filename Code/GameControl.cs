using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{
    public GameObject character;
    public Text gameOverTx;
    public Text scoreTx;
    public Text highScoreTx;
    public Text btnTx;
    public Text levelTx;
    private bool isPause;
    private int score = 0;
    private float isIncrease = 0.0f;
    public static GameControl instance;
    public int speed = 1;
    public int health;
    public int coin;
    public bool isGet1, isGet2;
    public Button pause, level, restart;
    private bool isAlive;
    private bool isDead;
    private bool shw;
    public string nextLevel;

    private float yres, ylev;
    public float resY, levY;

    public float lastPoint = 100f;
    private float firstPoint;
    private float general;
    public int lvl;
    public Slider sld;

    public AudioSource aud;

    void Start()
    {
        yres = restart.transform.position.y;
        ylev = level.transform.position.y;

        restart.onClick.AddListener(Restart);
        level.onClick.AddListener(scene);
        pause.onClick.AddListener(paus);
        instance = GetComponent<GameControl>();
        score = 0;
        coin = 0;
        health = 3;
        isGet1 = false;
        isGet2 = false;
        isAlive = true;
        isDead = false;
        shw = true;
        highScoreTx.text = "HighScore: " + PlayerPrefs.GetInt("high_score");
        scoreTx.text = "Score: " + score;
        notShow();

        aud.Play();

        firstPoint = character.transform.position.x;
        general = lastPoint - firstPoint;
    }
    void Update()
    {
        if (isAlive && isDead == false)
        {
            if (character.transform.position.y < -20)
                gameOver();
            if (character.transform.position.x - isIncrease > 5)
            {
                isIncrease = character.transform.position.x;
                score++;
                scoreTx.text = "Score: " + score;
            }
            fnsh();
        }
        else if (shw && isDead == false)
        {
            shw = false;
            show();
            btnTx.text = "";
            levelTx.text = "Next Level";

            aud.Stop();

        }
        else if (isDead)
        {
            show();
            btnTx.text = "";
        }
    }  

    public void gameOver()
    {

        aud.Stop();

        speed = 0;
        isDead = true;
        gameOverTx.text = "GAME OVER";
        if (score > PlayerPrefs.GetInt("high_score"))
            PlayerPrefs.SetInt("high_score", score);
        highScoreTx.text = "HighScore: " + PlayerPrefs.GetInt("high_score");
    }
    void paus()
    {
        if (isPause)
            notShow();
        else
            show();
    }

    void notShow()
    {
        level.transform.position = new Vector3(level.transform.position.x, levY, level.transform.position.z);
        restart.transform.position = new Vector3(restart.transform.position.x, resY, level.transform.position.z);
        btnTx.text = "Pause";
        isPause = false;
        speed = 1;
    }

    void show()
    {
        level.transform.position = new Vector3(level.transform.position.x, ylev, level.transform.position.z);
        restart.transform.position = new Vector3(restart.transform.position.x, yres, level.transform.position.z);
        btnTx.text = "Continue";
        isPause = true;
        speed = 0;
    }

    void scene()
    {
        if(isAlive)
            Application.LoadLevel("Level");
        else
            Application.LoadLevel(nextLevel);
    }
    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void fnsh()
    {
        if (character.transform.position.x > lastPoint)
        {
            PlayerPrefs.SetInt("lvl", lvl);
            isAlive = false;
        }
        sld.value = (character.transform.position.x - firstPoint * 1.0f) / general;
    }
}
