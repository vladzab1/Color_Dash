using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class newСolors : MonoBehaviour
{
    public GameObject[] Buttons;
    public GameObject BounceButton;
    public GameObject NewPaint;
    public string currentLevel;

    private bool isBounceActivated = false;

    void Start() {
        NewPaint.SetActive(false);
    }
    

    void Update()
    {
        if(!isBounceActivated) {
            BounceButton.SetActive(false);
        }
        for (byte i = 1; i < 8; i++)
        {
            float value = SaveManager.Instance.StarsLevel[$"Level_{i}"];
            if (value > 1)
            {
                if (i == 1)
                {
                    currentLevel = SceneManager.GetActiveScene().name;
                    if (currentLevel == "Level_2" && !isBounceActivated) {
                        BounceButton.SetActive(true);
                        NewPaint.SetActive(true);
                        Debug.Log("BounceButton");
                    }

                }
            }
        } 
    }
    public void Close() {
        NewPaint.SetActive(false);
        isBounceActivated = true;
        Debug.Log("Closing NewPaint object");

    }
    //  GameObject FindByName(GameObject[] Buttons, string name)
    // {
    //     foreach (GameObject obj in Buttons)
    //     {
    //         if (obj != null && obj.name == name)
    //         {
    //             return obj;
    //         }
    //     }
    //     return null;
    // }
}
