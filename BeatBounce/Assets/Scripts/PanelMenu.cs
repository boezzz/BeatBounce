using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PanelMenu : MonoBehaviour
{

    public Material White;
    public Material Red;
    public Material Blue;
    public Material Yellow;

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

    public void OnTypeChange(TMP_Dropdown myDropdown)
    {
        int selectedIndex = myDropdown.value;

        // Get the string value of the selected option
        string instrument = myDropdown.options[selectedIndex].text;
        string waveType;

        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (instrument == "Keyboard")
        {
            waveType = "SineWave";
            renderer.material = White;
        } else if (instrument == "Synth")
        {
            waveType = "TriangleWave";
            renderer.material = Blue;
        }
        else if (instrument == "Arcade")
        {
            waveType = "SquareWave";
            renderer.material = Yellow;
        }
        else if (instrument == "Alarm")
        {
            waveType = "SawtoothWave";
            renderer.material = Red;
        }
        else
        {
            return;
        }

        gameObject.tag = waveType;

    }

    public void OnSizeChange(float scaleValue) {
        // Apply the scale to the object
        gameObject.transform.localScale = new Vector3(scaleValue, gameObject.transform.localScale.y, scaleValue);
    }
}
