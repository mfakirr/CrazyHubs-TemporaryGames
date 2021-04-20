using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class ReplayScript : MonoBehaviour
{
    public Ease ease = Ease.Linear;
    public void ReplayLevel()
    {
        StartCoroutine(ReplayRoutine());
    }
    IEnumerator ReplayRoutine()
    {
        HideReplay();
        yield return new WaitForSeconds(.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void HideReplay()
    {
        transform.DOLocalMoveX(1000f, 1f).SetEase(ease);
    }
    public void ShowReplay()
    {
        transform.DOLocalMoveX(0f, 1f).SetEase(ease);
    }
}
