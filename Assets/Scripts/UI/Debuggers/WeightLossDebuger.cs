using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightLossDebuger : MonoBehaviour
{
    [SerializeField] float defaultValue;
    Slider mainSlider;
    private void Start()
    {
        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        mainSlider.value = defaultValue;
    }
    public void ValueChangeCheck()
    {
        GameManager.Instance.WeightLossSpeed = mainSlider.value;
    }
}
