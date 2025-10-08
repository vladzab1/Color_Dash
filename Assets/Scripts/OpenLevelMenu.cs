using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Open : MonoBehaviour
{
    public GameObject MenuObject;
    public WinScripts winScripts;

    void Start()
    {
        MenuObject.SetActive(false);
    }
    void Update()
    {
        for (byte i = 1; i < 8;i++)
        {
            float value = winScripts.StarsLevel[$"Level_{i}"];
            if (value > 0)
            {
                if (value == 1)
                {
                    GameObject obj = GameObject.Find($"StarsLevel_{i}_1");
                    obj.SetActive(true);
                }
                else if (value == 2)
                {
                    GameObject obj = GameObject.Find($"StarsLevel_{i}_1");
                    obj.SetActive(true);
                    GameObject obj1 = GameObject.Find($"StarsLevel_{i}_2");
                    obj1.SetActive(true);
                }
                else
                {
                    GameObject obj = GameObject.Find($"StarsLevel_{i}_1");
                    obj.SetActive(true);
                    GameObject obj1 = GameObject.Find($"StarsLevel_{i}_2");
                    obj1.SetActive(true);
                    GameObject obj2 = GameObject.Find($"StarsLevel_{i}_3");
                    obj2.SetActive(true);
                }
            }
        }
    }
    public void OpenLevelMenu()
    {
        MenuObject.SetActive(true);
    }
    public void PlayOpenLevel_1() {
        SceneManager.LoadScene("Level_1");
    }

    public void PlayOpenLevel_2()
    {
        float value = winScripts.StarsLevel["Level_1"];
        if (value > 0)
        {
            SceneManager.LoadScene("Level_2");
        }
    }
    
    
    // public void PlayOpenLevel_3()
    // {
    //     SceneManager.LoadScene("Level_3");
    // }
    // public void PlayOpenLevel_4()
    // {
    //     SceneManager.LoadScene("Level_4");
    // }
    // public void PlayOpenLevel_5()
    // {
    //     SceneManager.LoadScene("Level_5");
    // }
    // public void PlayOpenLevel_6()
    // {
    //     SceneManager.LoadScene("Level_6");
    // }
}
