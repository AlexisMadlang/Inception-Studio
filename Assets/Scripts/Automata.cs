using System.Collections;
using UnityEngine;

/// <summary>
/// Procedurally generate a lot of cars floating in space,
/// allowing the player to control their rotation based on
/// its own movement.
/// </summary>
public class Automata : MonoBehaviour
{
    // The player for controlling the cars
    [SerializeField]
    GameObject player;

    // The different types of cars that can be generated
    [SerializeField]
    GameObject[] prefabs;

    // The number of cars to generate
    [SerializeField, Range(1, 100)]
    int instanceCount = 50;

    // A container to store all the generated automobiles
    GameObject[] automobiles;

    // Rotation speed for individual automobiles
    float[] speeds;

    // A boolean value to keep track of whether the rotation is activated
    bool activate;

    // Two containers to keep track of the controller's positions 
    // at two consecutive timestamps
    Vector3 currentPosition;
    Vector3 previousPosition;
 

    void Start()
    {
        InitializeAutomata();
    }

    /// <summary>
    /// Initialize all instances of the automobiles, including their 
    /// positions, rotations, and speeds.
    /// </summary>
    void InitializeAutomata()
    {
        /* Initialize arrays for the automobile instances and their speeds. */

        // Your code here


        /* Using a for-loop:
         * 1) Create the automobile instances;
         * 2) Place them at a random position with:
         *     * Range (-50f, 50f) for the xz-plane;
         *     * Range (0f, 50f) for the y-axis (above ground).
         * 3) Orient them randomly;
         * 4) Make them children of the GameObject that uses this script;
         * 5) Give each of them a random speed (between 0 and 10).
         */

        // Your code here


    }


    // Update is called once per frame
    void Update()
    {
        ControlAutomata();
    }


    /// <summary>
    /// Use player movement to activate the rotation of 
    /// all instantiated automobiles simultaneously.
    /// </summary>
    void ControlAutomata()
    {
        /* Update previous position from the last frame */
        previousPosition = currentPosition;

        /* Get the current player position */
        currentPosition = player.transform.position;

        /* Compare between these two positions to track.
         * If there is a difference between the two positions,
         * rotation is activated, and vice versa. */        
        activate = Vector3.Distance(currentPosition, previousPosition) > 0.001f;

        /* Realize the activation by making all automobile instances rotate */
        // Your code here


    }

}
