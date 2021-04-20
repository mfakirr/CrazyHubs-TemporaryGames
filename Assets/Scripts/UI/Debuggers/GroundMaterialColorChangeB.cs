using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GroundMaterialColorChangeB : MonoBehaviour
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
            GroundMat.material.color = new Color(GroundMat.material.color.r, GroundMat.material.color.g, mainSlider.value);
        }
        else if(GroundMat.material.color.g == 0 && GroundMat.material.color.b ==0)
        {
            GroundMat.material.color = charactercolor;
        }
        defaultValue = mainSlider.value;

        valueText.text = mainSlider.value.ToString();

    }
}
