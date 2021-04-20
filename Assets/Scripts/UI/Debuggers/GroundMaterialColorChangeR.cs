using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GroundMaterialColorChangeR : MonoBehaviour
{
    [SerializeField] float defaultValue;
    Slider mainSlider;

    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField]
    SkinnedMeshRenderer GroundMat;

    Color charactercolor;

    private void Start()
    {
        charactercolor = GroundMat.material.color;

        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        mainSlider.value = defaultValue;


    }
    public void ValueChangeCheck()
    {
        if (mainSlider.value>0)
        {
            GroundMat.material.color = new Color(mainSlider.value, GroundMat.material.color.g, GroundMat.material.color.b);
        }
        else if(GroundMat.material.color.g == 0 && GroundMat.material.color.b ==0)
        {
            GroundMat.material.color = charactercolor;
        }
        defaultValue = mainSlider.value;

        valueText.text = mainSlider.value.ToString();

    }
}
