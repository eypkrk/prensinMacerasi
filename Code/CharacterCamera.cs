using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public GameObject character;
    private float x, y;
    void Start()
    {
        x = transform.position.x - character.transform.position.x;
        y = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(x + character.transform.position.x, y, -10);
    }
}
