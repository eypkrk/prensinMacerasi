using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Butterfly : MonoBehaviour
{
    float moveSpeed = -5f;
    public GameObject character;
    private Rigidbody2D rb2d;
    private bool decreaseHealth = false;
    public Image damageImage, damageImage1, damageImage2;
    public float flashSpeed = 5f;

    public AudioSource aud;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - character.transform.position.x) < -20)
        {
            move();
        }
        if (decreaseHealth)
        {
            GameControl.instance.health--;
            decreaseHealth = false;
        }
        if (GameControl.instance.speed == 0)
            rb2d.velocity = Vector3.zero;
        else
            rb2d.velocity = new Vector2(moveSpeed, 0);
    }

    void move()
    {
        transform.position = new Vector2(character.transform.position.x + 50.0f, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CharacterMove>() != null)
        {
            if (GameControl.instance.health == 3)
            {
                Destroy(damageImage2);
                decreaseHealth = true;
                move();
                aud.Play();
            }
            if (GameControl.instance.health == 2)
            {
                Destroy(damageImage1);
                decreaseHealth = true;
                move();
                aud.Play();
            }
            if (GameControl.instance.health == 1)
            {
                Destroy(damageImage);
                GameControl.instance.gameOver();
                decreaseHealth = true;
                aud.Play();
            }
        }
    }
}
