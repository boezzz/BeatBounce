using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnObject : MonoBehaviour
{
    // spawn the panels using primary button on the controller
    public GameObject objectTospawn;
    public InputActionReference confirmReference = null;
    private void Awake()
    {
        confirmReference.action.started += Create; // subsribe to the primary button
    }

    private void Create(InputAction.CallbackContext context) {
        Instantiate(objectTospawn, transform.position, transform.rotation);
    }
}
