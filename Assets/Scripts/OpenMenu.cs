using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject[] Surfaces;
    public GameObject Ball;
    public DrawWithPrefabs drawPrefabs;
    public bounce Bounce;
    public ice Ice;
    public GameObject WinMenu;
    public WinScripts win;
    void Start()
    {
        Menu.SetActive(false);
        SetSurfaces(true);
        Time.timeScale = 1f;
    }
    
    public void Open() {
        Menu.SetActive(true);
        SetSurfaces(false);
        Time.timeScale = 0f;
    }
    public void Close() {
        Menu.SetActive(false);
        SetSurfaces(true);
        Time.timeScale = 1f;
    }
    public void Restart() {
        Ball.transform.position = new Vector3(-3.2f, -2.5f, 0f);
                 
         Rigidbody2D rb2D = Ball.GetComponent<Rigidbody2D>();
        if (rb2D != null) {
                rb2D.linearVelocity = Vector2.zero;   
                rb2D.angularVelocity = 0f;      
            }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Obl")) {
            Destroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Stars")) {
            Destroy(obj);
        }
        // Bounce.horizontalBoost = 0f;
        // Bounce.verticalBoost = 0f;
        // Ice.boostSpeed = 0f;
        drawPrefabs.currentDrawAmount = 0;
        win.levelStartTime = Time.time;
        Menu.SetActive(false);
        WinMenu.SetActive(false);
        
        SetSurfaces(true);
        Time.timeScale = 1f;
    }
    public void MenuOpen() {
        SceneManager.LoadScene("StartScene");
    }
    
    
    private void SetSurfaces(bool state)
    {
        foreach (GameObject obj in Surfaces)
        {
            obj.SetActive(state);
        }
    }
}
