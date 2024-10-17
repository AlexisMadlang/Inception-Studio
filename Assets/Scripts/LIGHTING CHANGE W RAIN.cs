using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light directionalLight;
    public float rainLightIntensity = 0.4f; // Darker intensity during rain
    public float normalLightIntensity = 1.0f; // Normal light intensity
    public float fadeDuration = 1.0f; // Duration of the light fade

    private bool isRaining = false;

    public void TriggerRainLight(bool rainActive)
    {
        isRaining = rainActive;

        if (isRaining)
        {
            StartCoroutine(FadeLightIntensity(directionalLight.intensity, rainLightIntensity));
        }
        else
        {
            StartCoroutine(FadeLightIntensity(directionalLight.intensity, normalLightIntensity));
        }
    }

    System.Collections.IEnumerator FadeLightIntensity(float from, float to)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            directionalLight.intensity = Mathf.Lerp(from, to, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        directionalLight.intensity = to;
    }
}
