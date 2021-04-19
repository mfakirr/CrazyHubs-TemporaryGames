using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZCamDebugger : MonoBehaviour
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
        Vector3 exPos = GameManager.Instance.CameraPosition;
        Vector3 newPos = new Vector3(exPos.x, exPos.y, mainSlider.value);
        GameManager.Instance.CameraPosition = newPos;
    }
}
