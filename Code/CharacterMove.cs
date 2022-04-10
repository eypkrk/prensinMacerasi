using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 0.0f;
    private float y = 0.0f;
    public float upForce = 0.0f;
    private bool isFloor = true;
    private Animator anim;
    private bool mov = false;
    public JoyButton joyButton;
    public JumpBut jumpButton;
    public DownBut downButton;

    public AudioSource aud;

    private void Awake()

    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        joyButton = FindObjectOfType<JoyButton>();
        jumpButton = FindObjectOfType<JumpBut>();
        downButton = FindObjectOfType<DownBut>();
    }
    void Update()
    {
        if (joyButton.Pressed && GameControl.instance.speed == 1)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            anim.SetTrigger("Move");
        }
        else
        {
            rb2d.velocity = new Vector2(0 , rb2d.velocity.y);
        }
        if (jumpButton.Pressed && isFloor && GameControl.instance.speed == 1)
        {
            aud.Play();
            isFloor = false;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Jump");
        }
        if (downButton.Pressed && isFloor && GameControl.instance.speed == 1)
        {
            anim.SetTrigger("Down");
        }
        else
            anim.SetTrigger("Hold");
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
        isFloor = true;
    }
   
}
