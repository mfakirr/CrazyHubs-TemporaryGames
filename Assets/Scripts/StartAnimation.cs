using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartAnimation : MonoBehaviour
{
    [SerializeField]
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scalevector = new Vector3(scale, scale, scale);
        transform.DOScale(scalevector, 1f).SetLoops(-1);
    }

}
