using System.Collections;
using System.Collections.Generic;
// using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, 700f));
        Destroy(gameObject, 5);

    }
}