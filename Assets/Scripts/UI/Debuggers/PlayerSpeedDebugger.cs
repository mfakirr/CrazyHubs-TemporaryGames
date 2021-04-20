using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpeedDebugger : MonoBehaviour
{
    public float defaultValue;

    [HideInInspector]public Slider mainSlider;

    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    AnimationController animationController;



    private void Start()
    {
        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        mainSlider.value = defaultValue;
    }
    public void ValueChangeCheck()
    {
        GameManager.Instance.GameSpeed = mainSlider.value;

        if (mainSlider.value>0 )
        {
            playerAnimator.SetFloat("SpeedHandler", mainSlider.value / 500);   
        }
        else
        {
            animationController.Idle();
            animationController.StopWalk();
        }

        valueText.text = mainSlider.value.ToString();

    }
}
