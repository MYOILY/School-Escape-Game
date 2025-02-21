using System.Collections;
using UnityEngine;

public class Shade : MonoBehaviour
{
    public Material playerDissolveMaterial;  // Assign the dissolve material in the Inspector
    private float dissolveDuration = 1.0f;   // Duration of each dissolve and reappear cycle (in seconds)
    private bool isDissolving = false;        // Track dissolve state

    void Start()
    {
        // Start the continuous dissolve and resume loop when the game starts
        StartCoroutine(ContinuousDissolve());
    }

    IEnumerator ContinuousDissolve()
    {
        while (true) // Infinite loop to repeat dissolve and resume
        {
            // Start dissolve: Gradually increase _DissolveThreshold from 0 to 1
            yield return StartCoroutine(ChangeDissolveAmount(0f, 1f));

            // Optional pause when fully dissolved
            yield return new WaitForSeconds(0.5f);

            // Start reappearance: Gradually decrease _DissolveThreshold from 1 to 0
            yield return StartCoroutine(ChangeDissolveAmount(1f, 0f));

            // Optional pause after fully reappearing
            yield return new WaitForSeconds(0.5f); // Adjust if needed
        }
    }

    IEnumerator ChangeDissolveAmount(float start, float end)
    {
        float startTime = Time.time;
        float endTime = startTime + dissolveDuration;

        // Animate the dissolve threshold from start to end over the dissolve duration
        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / dissolveDuration;
            float dissolveValue = Mathf.Lerp(start, end, t);
            playerDissolveMaterial.SetFloat("_DissolveThreshold", dissolveValue);
            yield return null;  // Wait for the next frame
        }

        // Ensure the final dissolve value is set correctly
        playerDissolveMaterial.SetFloat("_DissolveThreshold", end);
    }
}
