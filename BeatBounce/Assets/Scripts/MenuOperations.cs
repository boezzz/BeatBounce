using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOperations : MonoBehaviour
{
    // this refer to the hand menu, add in world operations
    public void OnClearButtonClicked() {
        // clear all panels in space
        foreach (var each_panel in GameObject.FindGameObjectsWithTag("panel")){
            Destroy(each_panel);
        }
    }
}
