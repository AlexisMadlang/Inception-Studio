using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle scene transition (teleporting) with a fading screen.
/// </summary>
public class Teleporter : MonoBehaviour
{
    [SerializeField]
    Animator animator;      // Animator that controls the fading screen

    int nextScene = 0;      // Index for the scene to load. Default: 0.

    /// <summary>
    /// Update the scene index to before switching to the target scene.
    /// </summary>
    /// <param name="sceneId">Index for the scene to switch</param>
    public void SwitchToScene(int sceneId)
    {
        nextScene = sceneId;
        animator.SetTrigger("FadeOut");
    }

    /// <summary>
    /// Call SceneManager to load the target scene.
    /// Used as an animation event function.
    /// </summary>
    public void OnSceneSwitch()
    {
        SceneManager.LoadScene(nextScene);
    }

}
