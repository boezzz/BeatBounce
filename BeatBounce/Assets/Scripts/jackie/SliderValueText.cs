using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueText : MonoBehaviour
{
    private Slider slider;
    //private GameObject textObj;
    // private Text textComp;
    private TMP_Text textComp;


    void Awake()
    {
        slider = GetComponentInParent<Slider>();
        textComp = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateText(slider.value);
        slider.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(float val)
    {
        textComp.text = slider.value.ToString();
    }



}
