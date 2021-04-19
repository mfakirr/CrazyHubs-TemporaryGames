using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public delegate void EndFight();
    public static EndFight endFight;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Vector3 jumpPos = new Vector3(
                other.transform.position.x,
                other.transform.position.y +1f,
                other.transform.position.z);

            StartCoroutine(other.GetComponent<PlayerController2>().HandleJump(jumpPos));
            endFight();
        }
    }
}
