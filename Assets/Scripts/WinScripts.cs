using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WinScripts : MonoBehaviour
{
    public float levelStartTime;
    
    private float levelFinishTime;
    public DrawWithPrefabs DrawPrefabs;
    private int stars;
    public GameObject CanvasObject;
    public GameObject[] Surfaces;
    private string currentLevel;
    private float starsLevel;
    

    public Transform[] starSpawnPoints;
    public GameObject starPrefab;
    public GameObject WinMenu;
    
    Dictionary<string, float> StarsLevel = new Dictionary<string, float>()
    {
        { "Level_1", 0 },
        { "Level_2", 0 },
        { "Level_3", 0 },
        { "Level_4", 0 },
        { "Level_5", 0 },
        { "Level_6", 0 },
        { "Level_7", 0 },
    }; 
    
    void Start()
    {
        levelStartTime = Time.time;
        WinMenu.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        levelFinishTime = Time.time - levelStartTime;
        Debug.Log("WIN");
        Counting_Stars(); 
        currentLevel = SceneManager.GetActiveScene().name;
    }

    void Counting_Stars()
    {
        if (levelFinishTime < 15f && DrawPrefabs.currentDrawAmount < 200)
        {
            SpawnStars(3);
            stars = 3;
        }

        else if (levelFinishTime < 30f && DrawPrefabs.currentDrawAmount < 300)
        {
            SpawnStars(2);
            stars = 2;
        }
        else
        {
            SpawnStars(1);
            stars = 1;
        }
        Debug.Log($"Player earned {stars} stars. Time: {levelFinishTime}, Draws: {DrawPrefabs.currentDrawAmount}");
    }

    void SpawnStars(byte PowerGame)
    {
        if (PowerGame == 3)
        {
            for (byte i = 0; i < 3; i++)
            {
                WinMenu.SetActive(true);
                SetSurfaces(false);
                starsLevel = 3;
                StarsLevel[currentLevel] = starsLevel;
                var spawn = Instantiate(starPrefab, starSpawnPoints[i].position, Quaternion.identity);
                spawn.transform.SetParent(CanvasObject.transform);
            }
        }

        if (PowerGame == 2)
        {
            for (byte i = 0; i < 2; i++)
            {
                WinMenu.SetActive(true);
                SetSurfaces(false);
                starsLevel = 2;
                StarsLevel[currentLevel] = starsLevel;
                var spawn = Instantiate(starPrefab, starSpawnPoints[i].position, Quaternion.identity);
                spawn.transform.SetParent(CanvasObject.transform);
            }
        }

        if (PowerGame == 1)
        {
            WinMenu.SetActive(true);
            SetSurfaces(false);
            starsLevel = 3;
            StarsLevel[currentLevel] = starsLevel;
            var spawn =Instantiate(starPrefab, starSpawnPoints[0].position, Quaternion.identity);
            spawn.transform.SetParent(CanvasObject.transform);
        }
    }
    private void SetSurfaces(bool state)
    {
        foreach (GameObject obj in Surfaces)
        {
            obj.SetActive(state);
        }
    }
}
