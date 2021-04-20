using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainedPoint : MonoBehaviour
{
    public int MyPointIndex => myPointIndex;
    private int myPointIndex;
    private void Start()
    {
        myPointIndex = Int32.Parse(GetComponentInChildren<TextMesh>().text);
    }
    public void IncreaseTotalPoint()
    {
        GameManager.Instance.Score += MyPointIndex;
        Debug.Log("Point: " + GameManager.Instance.Score);
    }
    public void LoseWeight()
    {
        // This will make player lose extra weight
    }
}
