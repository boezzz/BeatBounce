using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CannonBall : MonoBehaviour
{
    // public float velocity = 700f;
    private Rigidbody rb;
    // public Slider mySlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddRelativeForce(new Vector3(0, 0, velocity));
        // Destroy(gameObject, 5);

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


}