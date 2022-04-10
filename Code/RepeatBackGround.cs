using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatBackGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength = 0.0f;
    private float y;
    public bool isFirst;
    public float speed = 0.0f;
    private Rigidbody2D rb2d;
    public GameObject character;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, 0);
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        y = transform.position.y;
    }
    private void Update()
    {
        rb2d.velocity = new Vector2(speed, 0);
        if (transform.position.x < character.transform.position.x - (groundHorizontalLength * 6) / 10)
        {
            RepositionBackground();
            if (isFirst)
            {
                GameControl.instance.isGet1 = true;
                GameControl.instance.isGet2 = false;
            }
            else
            {
                GameControl.instance.isGet2 = true;
                GameControl.instance.isGet1 = false;
            }
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(character.transform.position.x + (groundHorizontalLength * 14) / 10, y);
        transform.position = groundOffSet;
    }
}