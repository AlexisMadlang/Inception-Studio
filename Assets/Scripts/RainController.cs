using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public Transform houseTransform;
    public Transform playerTransform;
    public Light lightlight;

    public AudioSource houseAudioSource1; // Single sound for the house

    public Material skyboxMaterial; // Assign your procedural skybox material here
    public float farAtmosphereThickness = 1.3f; // Atmosphere thickness when far from the house
    public float closeAtmosphereThickness = 0.8f; // Atmosphere thickness when close to the house

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the audio source starts playing if it's not set to loop
        if (!houseAudioSource1.isPlaying)
        {
            houseAudioSource1.Play();
        }

        // Optionally initialize the skybox
        RenderSettings.skybox = skyboxMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 housePosition = new Vector2(houseTransform.position.x, houseTransform.position.z);
        Vector2 playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.z);
        float distanceToHouse = Vector2.Distance(housePosition, playerPosition);

        var emission = GetComponent<ParticleSystem>().emission;

        // Control rain emission and lighting intensity based on distance
        if (distanceToHouse > 55)
        {
            emission.rateOverTime = 0;
            lightlight.intensity = 1;
        }
        else if (distanceToHouse > 15)
        {
            emission.rateOverTime = (int)(1900 * (1 - (distanceToHouse - 15) / 40.0));
            lightlight.intensity = (distanceToHouse - 15) / 40f;
        }
        else
        {
            emission.rateOverTime = 1900;
            lightlight.intensity = 0;
        }

        // Control sound based on distance to the house
        float maxVolume = 0.5f; // Max volume for the sound
        float maxPitch = 1.2f;  // Optional: Adjust pitch slightly
        float minPitch = 0.8f;

        if (distanceToHouse > 55)
        {
            houseAudioSource1.volume = 0; // No sound if too far
        }
        else
        {
            float adjustedVolume = maxVolume * (1 - (distanceToHouse / 55));
            houseAudioSource1.volume = adjustedVolume;

            // Adjust pitch slightly for variation
            houseAudioSource1.pitch = Mathf.Lerp(minPitch, maxPitch, (55 - distanceToHouse) / 55);
        }

        // Control the skybox atmosphere thickness based on distance to the house
        if (skyboxMaterial != null)
        {
            // Lerp the atmosphere thickness from far to close as you approach the house
            float atmosphereThickness = Mathf.Lerp(farAtmosphereThickness, closeAtmosphereThickness, (55 - distanceToHouse) / 55);
            skyboxMaterial.SetFloat("_AtmosphereThickness", atmosphereThickness);
        }
    }
}
