using UnityEngine;

public class bounce : MonoBehaviour
{
    public float horizontalBoost = 2f;  // горизонтальна швидкість
    public float verticalBoost = 3f;    // вертикальна швидкість
    public AudioClip track; 
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = track;
        audioSource.Play();
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // додаємо горизонтальну та вертикальну швидкість
            rb.linearVelocity = new Vector2(horizontalBoost, verticalBoost);
        }
    }
}