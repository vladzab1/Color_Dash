using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Open : MonoBehaviour
{
    public GameObject MenuObject;
    private WinScripts winScripts;
    
    public GameObject[] Stars;
    

    void Start()
    { 
        MenuObject.SetActive(false);
        GameObject winningHole = GameObject.Find("WinningHole");
    }
    void Update()
    {
        levelAssessmentExhibition();
    }

    void levelAssessmentExhibition()
    {
        for (byte i = 1; i < 8; i++)
        {
            float value = SaveManager.Instance.StarsLevel[$"Level_{i}"];
            if (value > 0)
            {
                if (value == 1)
                {
                    GameObject obj = FindByName(Stars, $"StarLevel_{i}_1");
                    obj.SetActive(true);
                }
                if (value == 2)
                {
                    GameObject obj = FindByName(Stars, $"StarLevel_{i}_1");
                    obj.SetActive(true);
                    GameObject obj1 = FindByName(Stars, $"StarLevel_{i}_2");
                    obj1.SetActive(true);
                }
                if (value == 3)
                {
                    GameObject obj = FindByName(Stars, $"StarLevel_{i}_1");
                    obj.SetActive(true);
                    GameObject obj1 = FindByName(Stars, $"StarLevel_{i}_2");
                    obj1.SetActive(true);
                    GameObject obj2 = FindByName(Stars, $"StarLevel_{i}_3");
                    obj2.SetActive(true);
                }
            }
        } 
    }
    public void OpenLevelMenu()
    {
        MenuObject.SetActive(true);
    }

    GameObject FindByName(GameObject[] Stars, string name)
    {
        foreach (GameObject obj in Stars)
        {
            if (obj != null && obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }
    public void PlayOpenLevel_1() {
        SceneManager.LoadScene("Level_1");
    }

    public void PlayOpenLevel_2()
    {
        float value = SaveManager.Instance.StarsLevel["Level_1"];
        if (value > 0)
        {
            SceneManager.LoadScene("Level_2");
        }
    }

    public void PlayOpenLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }
     public void PlayOpenLevel_4()
     {
         SceneManager.LoadScene("Level_4");
     }
     public void PlayOpenLevel_5()
     {
         SceneManager.LoadScene("Level_5");
     }
    // public void PlayOpenLevel_6()
    // {
    //     SceneManager.LoadScene("Level_6");
    // }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            // Якщо запускаєш гру прямо в Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // На телефонах або ПК
            Application.Quit();
        #endif
    }
}
