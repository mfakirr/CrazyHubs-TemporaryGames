using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpeedDebugger : MonoBehaviour
{
    [SerializeField] float defaultValue;
    Slider mainSlider;


    [SerializeField] TextMeshProUGUI valueText;


    private void Start()
    {
        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        mainSlider.value = defaultValue;
    }
    public void ValueChangeCheck()
    {
        GameManager.Instance.GameSpeed = mainSlider.value;

        valueText.text = mainSlider.value.ToString();

    }
}
