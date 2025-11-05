using UnityEngine;

public class PortalPoint : MonoBehaviour
{
    public string groupName;
    public string linkedGroupName;

    void Start()
    {
        PortalSystem ps = FindObjectOfType<PortalSystem>();
        if (ps != null)
            ps.AddPortal(this); // додаємо себе у систему
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !string.IsNullOrEmpty(linkedGroupName))
        {
            Debug.Log("Player зайшов у портал: " + gameObject.name);
            PortalSystem ps = FindObjectOfType<PortalSystem>();
            if (ps != null)
                ps.TeleportPlayer(other.gameObject, linkedGroupName);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.2f);

        if (!string.IsNullOrEmpty(linkedGroupName))
        {
            PortalPoint[] points = FindObjectsOfType<PortalPoint>();
            foreach (var p in points)
                if (p.groupName == linkedGroupName)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(transform.position, p.transform.position);
                }
        }
    }
#endif
}