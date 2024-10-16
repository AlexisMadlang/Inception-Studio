using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public float rainDuration = 10f; // Duration the rain lasts
    public float rainInterval = 60f; // Time between rain cycles

    private float timer;

    void Start()
    {
        // Set the timer to trigger the rain for the first time
        timer = rainInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Start rain if it is not already playing
            if (!rainParticleSystem.isPlaying)
            {
                rainParticleSystem.Play();
                Invoke("StopRain", rainDuration); // Stop rain after rainDuration
            }

            // Reset timer for the next cycle
            timer = rainInterval;
        }
    }

    void StopRain()
    {
        rainParticleSystem.Stop();
    }
}
