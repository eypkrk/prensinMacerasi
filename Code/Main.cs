using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button but;
    public Button ex;
    void Start()
    {
        but.onClick.AddListener(Ply);
        ex.onClick.AddListener(Ex);
    }
    void Ply()
    {
        Application.LoadLevel("Level");
    }
    void Ex()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
