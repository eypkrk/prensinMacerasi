using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Button level1, level2, level3, level4, level5, level6, level7;
    public int cont = 0;
    void Start()
    {
        level1.onClick.AddListener(Level1);
        level2.onClick.AddListener(Level2);
        level3.onClick.AddListener(Level3);
        level4.onClick.AddListener(Level4);
        level5.onClick.AddListener(Level5);
        level6.onClick.AddListener(Level6);
        level7.onClick.AddListener(Level7);
        cont = PlayerPrefs.GetInt("lvl");
    }
    void Level1()
    {
        if(cont >= 0)
            Application.LoadLevel("Level1");
    }
    void Level2()
    {
        if (cont >= 1)
            Application.LoadLevel("Level2");
    }
    void Level3()
    {
        if (cont >= 2)
            Application.LoadLevel("Level3"); ;
    }
    void Level4()
    {
        if (cont >= 3)
            Application.LoadLevel("Level4");
    }
    void Level5()
    {
        if (cont >= 4)
            Application.LoadLevel("Level5");
    }
    void Level6()
    {
        if (cont >= 5)
            Application.LoadLevel("Level6");
    }
    void Level7()
    {
        if (cont >= 6)
            Application.LoadLevel("Level7");
    }
}
