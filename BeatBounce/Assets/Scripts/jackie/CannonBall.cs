// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CannonBall : MonoBehaviour
{
    // Clip to play on collision
    public AudioClip soundToPlay;
    private AudioSource audioSource;
    // public float velocity = 700f;
    private Rigidbody rb;
    // public Slider mySlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddRelativeForce(new Vector3(0, 0, velocity));
        // Destroy(gameObject, 5);
        GameObject gameObject = GameObject.Find("Audio Source");
        if (gameObject != null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
    }

    public void SetVelocity(float velocity)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, velocity, 0));

        Destroy(gameObject, 5);
    }

    public void SetMass(float mass)
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;

    }

    void OnCollisionEnter(Collision collision)
    {
        PlaySound();
    }

    // TODO: replace with Peyton's spatial audio script
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
        else
        {
            Debug.LogError("AudioSource component is null!");
        }
    }
}