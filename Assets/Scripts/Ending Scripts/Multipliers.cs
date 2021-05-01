using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multipliers : MonoBehaviour
{
    public int MultiplierIndex => multiplierIndex;
    [SerializeField] int multiplierIndex;

    [SerializeField] int min;
    [SerializeField] int max;

    private void Start()
    {
        multiplierIndex = Int32.Parse(GetComponentInChildren<TextMesh>().text);
    }
    public void MultiplyTotalPoint()
    {
        GameManager.Instance.Score *= MultiplierIndex;
        GameManager.Instance.IsPlaying = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SizeChanger size = other.GetComponent<SizeChanger>();
            print(size.meshArrayOrder);
            if (size.meshArrayOrder >= min && size.meshArrayOrder <= max)
            {
                print(size.meshArrayOrder);
                MultiplyTotalPoint();
                other.GetComponent<AnimationController>().Win();
                FindObjectOfType<ReplayScript>().ShowReplay();
            }
        }

    }

}
