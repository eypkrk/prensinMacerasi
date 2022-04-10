using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinTx;
    public bool isFirst;
    public bool isTaken;
    private float posY;
    public AudioSource aud;

    void Start()
    {
        isTaken = false;
        posY = transform.position.y;
    }

    void Update()
    {
        coins();
    }

    void coins()
    {
        float y;
        if (isFirst)
        {
            if (GameControl.instance.isGet1)
            {
                y = posY;
                isTaken = false;
            }
            else if (isTaken == false)
                y = posY;
            else
                y = -20;
            transform.position = new Vector3(transform.position.x, y, 0);
        }
        else
        {
            if (GameControl.instance.isGet2)
            {
                y = posY;
                isTaken = false;
            }
            else if (isTaken == false)
                y = posY;
            else
                y = -20;
            transform.position = new Vector3(transform.position.x, y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CharacterMove>() != null)
        {
            GameControl.instance.coin += 1;
            isTaken = true;
            coinTx.text = "Coin: " + GameControl.instance.coin;
            aud.Play();
        }
    }
}
