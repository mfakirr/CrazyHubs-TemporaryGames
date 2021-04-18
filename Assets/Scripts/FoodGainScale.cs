using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class FoodGainScale : MonoBehaviour
{
    [SerializeField]
    string catTag = default;
    [SerializeField]
    int GainWeightAmounthMeshArraySize = 0;

    private void OnTriggerEnter(Collider Touched)
    {
        if (Touched.CompareTag(catTag))
        {
            GainScaleWitgFood(Touched.GetComponent<SizeChanger>());
        }
    }

    public void GainScaleWitgFood(SizeChanger sizeChanger)
    {
        sizeChanger.meshArrayOrderIncrease(GainWeightAmounthMeshArraySize);
        sizeChanger.MeshChange();
    }
}
