using UnityEngine;

/// <summary>
/// Enable the platform as a trigger for teleporting to another scene.
/// </summary>
public class Platform : MonoBehaviour
{
    // Teleporter for scene transition handling
    [SerializeField]
    Teleporter teleporter;

    // User-defined scene to teleport to. Default: 0
    [SerializeField]
    public int targetSceneId = 0;   

    /// <summary>
    /// When the player steps onto the platform,
    /// the platform is triggered, 
    /// and the player is teleported to another scene.
    /// </summary>
    /// <param name="other">The collider for the trigger (player)</param>
    private void OnTriggerEnter(Collider other)
    {
        /* If the tag of the collider's game object is Player,
         * the teleporter is activated to switch to the scene with
         * targetSceneId. */

        if (other.CompareTag("Player"))
        {
            /* Your code here */
            teleporter.SwitchToScene(targetSceneId);
        }
    }
}
