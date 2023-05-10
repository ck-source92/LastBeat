using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject markerPrefab;

    private float[] samples;
    private float sampleRate;
    private float lastBeatTime;
    private float beatInterval = 5f; // Set the beat interval here

    private void Start()
    {
        // Get the audio samples and sample rate from the audio source
        samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);
        sampleRate = audioSource.clip.frequency;
    }

    private void Update()
    {
        // Get the current time in the audio clip
        float currentTime = audioSource.timeSamples / sampleRate;

        // Check if a beat has occurred
        if (currentTime - lastBeatTime >= beatInterval)
        {
            // Instantiate the marker prefab at the current position
            Instantiate(markerPrefab, transform.position, Quaternion.identity);

            // Update the last beat time
            lastBeatTime = currentTime;
        }
    }
}
