using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainedPoint : MonoBehaviour
{
    public int MyPointIndex => myPointIndex;
    [SerializeField]private int myPointIndex;


    private void Start()
    {
        myPointIndex = Int32.Parse(GetComponentInChildren<TextMesh>().text);
    }
    public void IncreaseTotalPoint()
    {
        GameManager.Instance.Score += MyPointIndex;
    }
    public void LoseWeight(GameObject cat)
    {
        cat.GetComponent<SizeChanger>().meshArrayOrder -= 3;
    }
}
