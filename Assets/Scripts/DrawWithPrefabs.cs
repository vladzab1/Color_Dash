using UnityEngine;
using UnityEngine.UI; // для Slider

public class DrawWithPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject ice;
    public GameObject slime;
    public GameObject trampoline;
    public GameObject magnet;
    public GameObject teleport;

    public float spawnRate = 0.001f;
    private float nextSpawnTime;

    

    [Header("Drawing Areas")]
    public Collider2D[] drawAreas;

    [Header("Drawing Limit")]
    public int maxDrawAmount = 100; // максимальна кількість "кліків" або спавнів
    public int currentDrawAmount = 0;

    [Header("UI")]
    public Slider drawSlider; // сюди потягнеш свій слайдер

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TrySpawn(mousePos);
        }

        if (Input.touchCount > 0)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            TrySpawn(touchPos);
        }

        // оновлюємо слайдер
        if (drawSlider != null)
            drawSlider.value = (float)currentDrawAmount / maxDrawAmount;
    }

    void TrySpawn(Vector3 pos)
{
    if (currentDrawAmount >= maxDrawAmount)
        return;
        
    if (Time.time < nextSpawnTime)
        return;
    
    bool spawned = false;
    
    // ВАЖЛИВО: ставимо Z = 0 для перевірки OverlapPoint (2D колайдери на площині Z=0)
    Vector2 pos2D = new Vector2(pos.x, pos.y);
    
    Debug.Log($"Перевіряю {drawAreas.Length} зон. Позиція кліку 2D: {pos2D}");
    
    // Спочатку перевіряємо, чи клік всередині якоїсь зони
    for (int i = 0; i < drawAreas.Length; i++)
    {
        Collider2D area = drawAreas[i];
        
        if (area == null)
        {
            Debug.Log($"Зона {i} = NULL");
            continue;
        }
        
        Debug.Log($"Зона {i} ({area.name}): bounds={area.bounds}, OverlapPoint={area.OverlapPoint(pos2D)}");
        
        if (area.OverlapPoint(pos2D))
        {
            Debug.Log($"✅ СПАВН в зоні {i} ({area.name})");
            Vector3 spawnPos = new Vector3(pos2D.x, pos2D.y, -1.75f);
            Instantiate(prefab, spawnPos, Quaternion.identity);
            spawned = true;
            break;
        }
    }
    
    // Якщо не заспавнили всередині, шукаємо найближчу межу
    if (!spawned)
    {
        Debug.Log("Не знайшов клік всередині жодної зони. Шукаю найближчу межу...");
        
        float minDistance = float.MaxValue;
        Vector3 bestSpawnPos = Vector3.zero;
        bool foundNearby = false;
        
        for (int i = 0; i < drawAreas.Length; i++)
        {
            Collider2D area = drawAreas[i];
            if (area == null) continue;
            
            Vector2 closestPoint = area.ClosestPoint(pos2D);
            float distance = Vector2.Distance(pos2D, closestPoint);
            
            Debug.Log($"Зона {i} ({area.name}): відстань={distance}, найближча точка={closestPoint}");
            
            if (distance < minDistance && distance < 10f)
            {
                minDistance = distance;
                bestSpawnPos = new Vector3(closestPoint.x, closestPoint.y, -1.75f);
                foundNearby = true;
                Debug.Log($"⭐ Нова найближча зона: {i} ({area.name})");
            }
        }
        
        if (foundNearby)
        {
            Debug.Log($"✅ СПАВН на межі. Позиція: {bestSpawnPos}");
            Instantiate(prefab, bestSpawnPos, Quaternion.identity);
            spawned = true;
        }
        else
        {
            Debug.Log("❌ Не знайшов жодної підходящої зони");
        }
    }
    
    if (spawned)
    {
        nextSpawnTime = Time.time + spawnRate;
        currentDrawAmount++;
    }
}


    public void ResetDrawAmount()
{
    currentDrawAmount = 0;

    if (drawSlider != null)
        drawSlider.value = 0; // одразу оновлюємо UI
}


    bool IsInsideDrawAreas(Vector3 pos)
    {
        foreach (Collider2D area in drawAreas)
        {
            if (area != null && area.OverlapPoint(pos))
                return true;
        }
        return false;
    }

    public void Ice() => prefab = ice;
    public void Slime() => prefab = slime;
    public void Trampoline() => prefab = trampoline;
    public void Magnet() => prefab = magnet;    
    public void Teleport() => prefab = teleport;
}