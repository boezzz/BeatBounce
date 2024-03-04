using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PanelMenu : MonoBehaviour
{
    // status menu for each panel
    public void ShowStatus()
    {
        // show status bar of the "activated" object
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    
    
    public void HideStatus()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnDeleteClicked()
    {
        // delete the specific panel through its status menu
        Destroy(gameObject);
    }
    
    public void OnTypeChange() {
        // not implemented yet, need to change the model of the panel when the type changed
    }

    public void OnSizeChange(float scaleValue) {
        // Apply the scale to the object
        gameObject.transform.localScale = new Vector3(scaleValue, gameObject.transform.localScale.y, scaleValue);
    }
}
