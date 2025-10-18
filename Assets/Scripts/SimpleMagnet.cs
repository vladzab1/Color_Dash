using UnityEngine;

public class SimpleMagnet : MonoBehaviour
{
    public float force = 5f;
    public float attractionRadius = 3f;
    public float DestroyDistance = 0.1f;
    
    public Transform ball;
    void Start() {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        ball = obj.transform;
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, ball.position);
        if (distance < attractionRadius)
        {
            Vector2 direction = (transform.position - ball.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(ball.position, direction, distance);
            if (hit.collider == null || hit.collider.gameObject == gameObject || hit.collider.gameObject == ball.gameObject) {
                ball.position += (Vector3)(direction * force * Time.deltaTime);
            }

            if (distance < DestroyDistance) {
                Destroy(gameObject);
            }
        }
    }
}
