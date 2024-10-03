using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position; // Move player to spawn point
        }
    }
}
