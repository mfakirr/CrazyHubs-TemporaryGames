using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XCamDebugger : MonoBehaviour
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
        Vector3 newPos = new Vector3(mainSlider.value, exPos.y, exPos.z);
        GameManager.Instance.CameraPosition = newPos;
    }
}
