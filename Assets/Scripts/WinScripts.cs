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
    
   
    void Start()
    {
        levelStartTime = Time.time;
        if (WinMenu != null) WinMenu.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (DrawPrefabs == null) return;
        levelFinishTime = Time.time - levelStartTime;
        Debug.Log("WIN");
        currentLevel = SceneManager.GetActiveScene().name;
        Counting_Stars(); 
    }

    void Counting_Stars()
    {
        if (DrawPrefabs == null) return;

        if (levelFinishTime < 22f && DrawPrefabs.currentDrawAmount < 350)
        {
            SpawnStars(3);
            stars = 3;
        }
        else if (levelFinishTime < 40f && DrawPrefabs.currentDrawAmount < 500)
        {
            SpawnStars(2);
            stars = 2;
        }
        else
        {
            SpawnStars(1);
            stars = 1;
        }
    }

    void SpawnStars(byte PowerGame)
    {
        if (WinMenu == null || starPrefab == null || CanvasObject == null || starSpawnPoints == null) return;

        if (PowerGame == 3)
        {
            for (byte i = 0; i < 3; i++)
            {
                if (i >= starSpawnPoints.Length || starSpawnPoints[i] == null) continue;

                WinMenu.SetActive(true);
                SetSurfaces(false);
                starsLevel = 3;
                SaveManager.Instance.SetStars(currentLevel, starsLevel);

                var spawn = Instantiate(starPrefab, starSpawnPoints[i].position, Quaternion.identity);
                spawn.transform.SetParent(CanvasObject.transform);
                Pokas();
            }
        }

        if (PowerGame == 2)
        {
            for (byte i = 0; i < 2; i++)
            {
                if (i >= starSpawnPoints.Length || starSpawnPoints[i] == null) continue;

                WinMenu.SetActive(true);
                SetSurfaces(false);
                starsLevel = 2;
                SaveManager.Instance.SetStars(currentLevel, starsLevel);

                var spawn = Instantiate(starPrefab, starSpawnPoints[i].position, Quaternion.identity);
                spawn.transform.SetParent(CanvasObject.transform);
                Pokas();
            }
        }

        if (PowerGame == 1)
        {
            if (starSpawnPoints.Length == 0 || starSpawnPoints[0] == null) return;

            WinMenu.SetActive(true);
            SetSurfaces(false);
            starsLevel = 1;
            SaveManager.Instance.SetStars(currentLevel, starsLevel);

            var spawn = Instantiate(starPrefab, starSpawnPoints[0].position, Quaternion.identity);
            spawn.transform.SetParent(CanvasObject.transform);
            Pokas();
        }
    }

    private void SetSurfaces(bool state)
    {
        if (Surfaces == null) return;

        foreach (GameObject obj in Surfaces)
        {
            if (obj != null) obj.SetActive(state);
        }
    }
   void Pokas() 
{
    for (byte i = 1; i <= 7; i++) 
    {
        float value = SaveManager.Instance.StarsLevel[$"Level_{i}"];
        Debug.Log($"Level_{i} = {value}");
    }
}

}
