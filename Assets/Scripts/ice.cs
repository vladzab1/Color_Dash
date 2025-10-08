using UnityEngine;

public class ice : MonoBehaviour
{
    public float boostSpeed = 2f; // сила додавання горизонтальної швидкості

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // додаємо горизонтальну швидкість
            rb.linearVelocity = new Vector2(boostSpeed, rb.linearVelocity.y);
        }
    }
}