using UnityEngine;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public Dictionary<string, float> StarsLevel = new Dictionary<string, float>()
    {
        { "Level_1", 0 },
        { "Level_2", 0 },
        { "Level_3", 0 },
        { "Level_4", 0 },
        { "Level_5", 0 },
        { "Level_6", 0 },
        { "Level_7", 0 },
    };

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // LoadProgress();
    }

    public void SetStars(string levelName, float stars)
    {
        if (StarsLevel.ContainsKey(levelName))
        {
            if (stars > StarsLevel[levelName])
            {
                StarsLevel[levelName] = stars;
                // PlayerPrefs.SetFloat(levelName, stars);
                // PlayerPrefs.Save();
                
            }
        }
    }

    // public void LoadProgress()
    // {
    //     foreach (var key in new List<string>(StarsLevel.Keys))
    //     {
    //         StarsLevel[key] = PlayerPrefs.GetFloat(key, 0);
    //     }
    // }
// public void ResetProgress()
//     {
//         foreach (var key in new List<string>(StarsLevel.Keys))
//         {
//             StarsLevel[key] = 0;
//             PlayerPrefs.DeleteKey(key); 
//         }

//         PlayerPrefs.Save();
//         Debug.Log("🔥 Усі збереження (StarsLevel) анульовано!");
//     }
 }
