using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public int MultiplierIndex => multiplierIndex;
    [SerializeField] int multiplierIndex;
    private void Start()
    {
        multiplierIndex = Int32.Parse(GetComponentInChildren<TextMesh>().text);
    }
    public void MultiplyTotalPoint()
    {
        GameManager.Instance.Score *= MultiplierIndex;
    }
}
