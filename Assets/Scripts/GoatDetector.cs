using UnityEngine;


/// <summary>
/// Using a Raycast in the player's forward direction,
/// Detect a goat by making it change color.
/// </summary>
public class GoatDetector : MonoBehaviour
{
    // The hit as a result of the raycast
    RaycastHit hit;
    
    void Update()
    {
        // The ray is cast from the position of the player
        // towards its forward direction. 
        // If the Raycast hit a physic object named "Goat",
        // then grab that object's material and change it to green.

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            /* Your code here */
        }
    }
}
