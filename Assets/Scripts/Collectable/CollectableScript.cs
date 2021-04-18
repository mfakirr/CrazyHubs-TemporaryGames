using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableScript : MonoBehaviour
{
    private Vector3 rotation;
    public Ease ease = Ease.Linear;
    private void Awake() {
        rotation = new Vector3(0f, 10f, 45f);
    }
    void Start()
    {
        transform.DORotate(rotation, .1f).SetLoops(-1, LoopType.Incremental).SetEase(ease);
    }
}
