using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using TMPro;


public class YCamDebugger : MonoBehaviour
{
    float defaultValue;
    Slider mainSlider;

    [SerializeField] TextMeshProUGUI valueText;


    private void Start()
    {
        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        defaultValue = Camera.main.transform.position.y;
        mainSlider.value = defaultValue;
    }
    public void ValueChangeCheck()
    {
        Vector3 exPos = GameManager.Instance.CameraPosition;
        Vector3 newPos = new Vector3(exPos.x, mainSlider.value, exPos.z);
        GameManager.Instance.CameraPosition = newPos;

        valueText.text = mainSlider.value.ToString();

    }
}
