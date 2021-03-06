using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DebugButton : MonoBehaviour
{
    public Ease ease = Ease.Linear;
    [SerializeField] private GameObject debugMenu;
    [SerializeField] private float menuShowY;
    [SerializeField] private float menuHideY;
    [SerializeField] private float animDuration;
    [SerializeField] private GameObject player;
    [SerializeField]
    PlayerSpeedDebugger playerSpeedDebugger;

    public void ShowDebugMenu()
    {
        GameManager.Instance.IsPlaying = false;
        debugMenu.transform.DOLocalMoveY(menuShowY, animDuration).SetEase(ease);
        player.GetComponent<AnimationController>().Idle();
        player.GetComponent<AnimationController>().StopWalk();
        player.GetComponent<SizeChanger>().canLoseWeight = false;
    }
    public void HideDebugMenu()
    {
        debugMenu.transform.DOLocalMoveY(menuHideY, animDuration).SetEase(ease);

        GameManager.Instance.IsPlaying = true;

        player.GetComponent<SizeChanger>().canLoseWeight = true;

        if (playerSpeedDebugger.mainSlider.value > 0)
        {
            player.GetComponent<AnimationController>().Walk();
        }
    }
}
