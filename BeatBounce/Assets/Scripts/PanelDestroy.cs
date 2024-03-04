using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CustomDestroy : MonoBehaviour
{
    // the destroy logic via secondary button on a controller
    public InputActionReference destroyButton;

    private void Awake()
    {
        // can play creation sound track here
    }

    private void OnDestroy()
    {
        destroyButton.action.started -= OnInputActionStarted; // Unsubscribe from the destory event
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        destroyButton.action.started += OnInputActionStarted; // Subscribe to the destroy event
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        destroyButton.action.started -= OnInputActionStarted;
    }

    private void OnInputActionStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Destroying object");
        Destroy(gameObject);
    }
}
