using UnityEngine;

public class BreakObjectOnProximity : MonoBehaviour
{
    public ParticleSystem particleEffect; // Assign your particle system in the Inspector
    public float triggerDistance = 10f; // Distance to trigger the effect
    private Transform player;

    void Start()
    {
        // Find the player using its tag (ensure your player has the tag "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check distance between the player and the object
        if (Vector3.Distance(player.position, transform.position) <= triggerDistance)
        {
            TriggerEffect();
        }
    }

    void TriggerEffect()
    {
        // Play the particle effect
        if (particleEffect != null)
        {
            particleEffect.Play();
        }

        // Disable the object's renderer to make it disappear
        GetComponent<Renderer>().enabled = false;

        // Optionally disable the collider to prevent further interaction
        GetComponent<Collider>().enabled = false;

        // Destroy the object after a delay (if you want it to be fully removed)
        Destroy(gameObject, 2f); // Adjust the time as needed
    }
}
