using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalSystem : MonoBehaviour
{
    public float maxDistance = 2f; // макс. відстань для групи
    public List<List<PortalPoint>> groups = new List<List<PortalPoint>>();
    private bool canTeleport = true; // для затримки
    private HashSet<GameObject> teleportCooldownPlayers = new HashSet<GameObject>();


    public void AddPortal(PortalPoint portal)
    {
        foreach (var group in groups)
        {
            foreach (var p in group)
            {
                if (Vector3.Distance(p.transform.position, portal.transform.position) <= maxDistance)
                {
                    group.Add(portal);
                    UpdateGroups();
                    return;
                }
            }
        }

        List<PortalPoint> newGroup = new List<PortalPoint> { portal };
        groups.Add(newGroup);
        UpdateGroups();
    }

    public void UpdateGroups()
    {
        for (int i = 0; i < groups.Count; i++)
            foreach (var p in groups[i])
                p.groupName = "G" + i;

        for (int i = 0; i < groups.Count; i += 2)
        {
            if (i + 1 >= groups.Count) break;
            string g1 = groups[i][0].groupName;
            string g2 = groups[i + 1][0].groupName;

            foreach (var p in groups[i]) p.linkedGroupName = g2;
            foreach (var p in groups[i + 1]) p.linkedGroupName = g1;
        }
    }

    public void TeleportPlayer(GameObject player, string targetGroup)
    {
        if (teleportCooldownPlayers.Contains(player)) return; // чекаємо затримку

        foreach (var group in groups)
        {
            if (group.Count == 0) continue;
            if (group[0].groupName != targetGroup) continue;

            PortalPoint exitPortal = group[Random.Range(0, group.Count)];
            player.transform.position = exitPortal.transform.position;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            StartCoroutine(TeleportCooldown(player)); // затримка для цього гравця
            return;
        }
    }


    private IEnumerator TeleportCooldown(GameObject player)
    {
        teleportCooldownPlayers.Add(player);
        yield return new WaitForSeconds(1f); // 1 секунда затримки
        teleportCooldownPlayers.Remove(player);
    }


}
