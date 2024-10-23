using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearController : MonoBehaviour
{
    public Transform houseTransform;        // Reference to the house's transform
    public Transform playerTransform;       // Reference to the player's transform
    public GameObject[] objectsToAppear;    // Array of objects to appear sequentially
    public float distanceThreshold = 20f;    // Distance threshold for the objects to appear
    public float objectDuration = 4f;        // Duration each object stays visible

    private Coroutine appearCoroutine;       // To track the coroutine
    private int currentObjectIndex = 0;     // To keep track of which object is currently being displayed

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide all objects
        foreach (GameObject obj in objectsToAppear)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance to the house
        float distanceToHouse = Vector3.Distance(houseTransform.position, playerTransform.position);

        // Debug log to check the distance
        Debug.Log("Distance to house: " + distanceToHouse);

        // Check if the player is within the distance threshold
        if (distanceToHouse <= distanceThreshold)
        {
            // Start the coroutine if it is not already running and not all objects have appeared
            if (appearCoroutine == null && currentObjectIndex < objectsToAppear.Length)
            {
                appearCoroutine = StartCoroutine(HandleObjectAppearance());
            }
        }
        // Pause the action if the player is outside the distance threshold
        else if (appearCoroutine != null)
        {
            // The coroutine will not be stopped; it will just keep track of the last object shown
            // If the player goes out of range, do nothing, allowing the coroutine to finish
            Debug.Log("Player is too far away, pausing appearance.");
        }
    }

    private IEnumerator HandleObjectAppearance()
    {
        while (currentObjectIndex < objectsToAppear.Length)
        {
            GameObject obj = objectsToAppear[currentObjectIndex];
            obj.SetActive(true);                // Show the current object
            yield return new WaitForSeconds(objectDuration); // Wait for the duration

            // Hide the current object after the duration
            obj.SetActive(false);
            currentObjectIndex++;               // Move to the next object
        }

        // Show the last object permanently
        if (currentObjectIndex > 0)
        {
            objectsToAppear[currentObjectIndex - 1].SetActive(true);
        }

        appearCoroutine = null;                // Reset the coroutine tracker
    }
}
