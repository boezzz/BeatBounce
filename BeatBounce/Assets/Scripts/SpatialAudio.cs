using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialAudio : MonoBehaviour
{
    public float sampleRate = 44100f; // Sample rate (usually 44100 Hz for CD quality audio)
    public AudioClip GenerateSineWave(float frequency, float duration, float volume, string instrument)
    {
        int numSamples = (int)(duration * sampleRate);
        float[] samples = new float[numSamples];

        float increment = frequency * 2 * Mathf.PI / sampleRate;
        string name = instrument;

        // Change type of wave to get a different "instrument"
        for (int i = 0; i < numSamples; i++)
        {
            float soundAttenuation = 1 - ((float) i)/numSamples; // to cause a fading effect. In the range [0,1]

            float waveValue; // value of the wave (just the fundamental frequency)

            if (instrument == "SquareWave") {
                waveValue = Mathf.Sign(Mathf.Sin(increment * i));
            } else if (instrument == "TriangleWave") { // Goes up to a height and then back down linearly
                waveValue = Mathf.PingPong(increment * i, 2) - 1; // need to subtract by 1 to center the wave between 0 & 1
            } else if (instrument == "SawtoothWave") { // will go up to a height but won't go back down, will jump to bottom.
                waveValue = Mathf.Repeat(increment * i, 2) - 1;
            } else if (instrument == "SineWave") { // Standard Sinewave
                waveValue = Mathf.Sin(increment * i);
            } else
            {
                return null;
            }

            samples[i] = volume * waveValue * soundAttenuation;
        }

        AudioClip audioClip = AudioClip.Create(name, numSamples, 1, (int) sampleRate, false);
        audioClip.SetData(samples, 0);

        return audioClip;
    }

    // public AudioClip clip; //make sure you assign an actual clip here in the inspector
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MusicalBall"))
        {
            Debug.Log("Sphere collided with square!");
            // You can add any actions you want to perform when collision happens
            var collisionPt = collision.GetContact(0);
            Debug.Log("Collided at point " + collisionPt.point);

            // frequency we want to play depends on the scale of the square
            // range of values for the slider are 0.4 to 0.7. Want to scale to 0.0 to 1.0
            float frequencyPercent = (transform.localScale.x - 0.4f)/(0.7f-0.4f);
            // Now that we have 0.0 to 1.0, want to determine which note to play in the range
            // 220 to 880 (aka A3 to A5 two octaves)
            float frequency = 220 * Mathf.Pow(2, frequencyPercent + 1);

            float duration = 0.5f; // will be constant for now

            float volume = collision.relativeVelocity.magnitude * 0.2f; // Multiplied by factor of 0.5 since it's pretty loud
            AudioClip clip = GenerateSineWave(frequency, duration, volume, gameObject.tag);
            if (clip != null) AudioSource.PlayClipAtPoint(clip, collisionPt.point);
        }
    }
}
