using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController2 : MonoBehaviour
{
    const float BORDER_ON_X = 4.55f;
    public Ease ease = Ease.InOutFlash; // DOTween animation style. Can be changed from inspector.
    private float changingX;
    [SerializeField]private float slideSensitivity;
    
    private AnimationController animationController;
    [HideInInspector]public bool jumping;

    [Header("Jump Section"), Space(10)]
    [SerializeField] private float jumpPower; // Jumping power. Used for DoJump(..)
    [SerializeField] private int numJumps; // Number of jumps. Used for DoJump(..)
    [SerializeField] private float jumpDuration; // Duration of jumping process. Used for DoJump(..)
    [SerializeField] private Transform enemy;
    private void Update()
    {
        if (!jumping && GameManager.Instance.IsPlaying)
        {
            if (Input.GetMouseButton(0))
            {
                changingX += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * slideSensitivity;

                changingX = Mathf.Clamp(changingX, -BORDER_ON_X, BORDER_ON_X);

                transform.position = new Vector3(changingX,
                                                  transform.position.y,
                                                  transform.position.z);
            }

        }
    }

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
    }

    /// <summary>
    /// Starts jumping process.
    /// </summary>
    /// <returns></returns>
    public IEnumerator HandleJump(Vector3 jumpPosition)
    {
        jumping = true;
        transform.DOJump(
            jumpPosition,
            jumpPower,
            numJumps,
            jumpDuration).SetEase(ease);
        animationController.Jump();


        yield return new WaitForSeconds(jumpDuration);
        jumping = false;
        
    }

    public void EndFightStarted()
    {
        transform.LookAt(enemy);
        Vector3 fightPos = (transform.position + enemy.position) /2f;
        transform.DOLocalMove(fightPos, 1f);
        GetComponent<AnimationController>().StopWalk();
        GetComponent<AnimationController>().Attack();
        
    }

    #region Trigger Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !jumping)
        {
            StartCoroutine(HandleJump(transform.position));
            other.GetComponent<GainedPoint>().IncreaseTotalPoint();
        }
    }
    #endregion
}

