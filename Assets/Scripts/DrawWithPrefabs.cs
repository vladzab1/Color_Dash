using UnityEngine;
using UnityEngine.UI; // для Slider

public class DrawWithPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject ice;
    public GameObject slime;
    public GameObject trampoline;
    public GameObject magnet;

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

    foreach (Collider2D area in drawAreas)
    {
        if (area == null) continue;

        if (area.OverlapPoint(pos))
        {
            // всередині зони — спавнимо там, де тикнув
            pos.z = -1.75f;
            Instantiate(prefab, pos, Quaternion.identity);
            spawned = true;
            break;
        }
        else if (pos.y > area.bounds.max.y)
        {
            // точка вище зони — робимо raycast зверху вниз
            Vector2 rayOrigin = new Vector2(pos.x, area.bounds.max.y + 5f); // 5 юнітів вище зони
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, 100f, 1 << area.gameObject.layer);

            if (hit.collider == area)
            {
                Vector3 spawnPos = hit.point;
                spawnPos.z = -1.75f;
                Instantiate(prefab, spawnPos, Quaternion.identity);
                spawned = true;
                break;
            }
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
}