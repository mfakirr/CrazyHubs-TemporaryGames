using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Transform player;
    private float xPos;
    private float yPos;
    private float zPos;
    private LevelInfoAsset level;
    private float speed = 1f;
    private void Start()
    {
        player = FindObjectOfType<PlayerController2>().transform;
    }
    void FixedUpdate()
    {
        Vector3 posUpdate = GameManager.Instance.CameraPosition;

        if (transform.position != posUpdate)
        {
            transform.position = posUpdate;
            Vector3 lTargetDir = player.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(lTargetDir),
                Time.time * speed);
        }
    }
}
