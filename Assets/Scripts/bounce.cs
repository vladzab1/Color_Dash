using UnityEngine;

public class bounce : MonoBehaviour
{
    public float horizontalBoost = 2f;  // горизонтальна швидкість
    public float verticalBoost = 3f;    // вертикальна швидкість

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // додаємо горизонтальну та вертикальну швидкість
            rb.linearVelocity = new Vector2(horizontalBoost, verticalBoost);
        }
    }
}