using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController2 : MonoBehaviour
{
    const float BORDER_ON_X = 1f;
    public Ease ease = Ease.InOutFlash; // DOTween animation style. Can be changed from inspector.
    private float playerZPosition;
    private Vector3 offSet;
    private bool jumping;

    [Header("Jump Section"), Space(10)]
    [SerializeField] private float jumpPower; // Jumping power. Used for DoJump(..)
    [SerializeField] private int numJumps; // Number of jumps. Used for DoJump(..)
    [SerializeField] private float jumpDuration; // Duration of jumping process. Used for DoJump(..)
    private void Update()
    {
        float speed = Input.GetAxis("Mouse X");
        if (!jumping)
        {
            if (Input.GetMouseButtonDown(0))
            {
                offSet = gameObject.transform.position - GetMouseAsWorldPoint();
            }
            if (Input.GetMouseButton(0))
            {
                playerZPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                float x = Mathf.Clamp(GetMouseAsWorldPoint().x + offSet.x, -BORDER_ON_X, BORDER_ON_X);
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }
    }
    Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y,z)
        Vector3 mousePos = Input.mousePosition;
        // z coordinate of game object on screen
        mousePos.z = playerZPosition;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    /// <summary>
    /// Starts jumping process.
    /// </summary>
    /// <returns></returns>
    public IEnumerator HandleJump()
    {
        jumping = true;
        transform.DOJump(
            transform.position,
            jumpPower,
            numJumps,
            jumpDuration).SetEase(ease);

        yield return new WaitForSeconds(jumpDuration);
        jumping = false;
        offSet = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    #region Trigger Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !jumping)
        {
            StartCoroutine(HandleJump());
        }
    }
    #endregion
}

