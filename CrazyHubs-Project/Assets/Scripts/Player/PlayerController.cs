using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PlayerMovement
{
    ToRight,
    ToLeft,
    ToUp
}
public class PlayerController : MonoBehaviour
{
    #region Variables
    public Ease ease = Ease.InOutFlash; // DoTween animation style. Can be changed from inspector.
    public PlayerMovement PlayerMovement
    {
        get => playerMovement;
        set
        {
            if (!isMoving)
            {
                playerMovement = value;
                switch (playerMovement)
                {
                    case PlayerMovement.ToRight:
                        MovePlayer(PlayerMovement.ToRight);
                        break;
                    case PlayerMovement.ToLeft:
                        MovePlayer(PlayerMovement.ToLeft);
                        break;
                    case PlayerMovement.ToUp:
                        MovePlayer(PlayerMovement.ToUp);
                        break;
                }
            }

        }
    }
    private PlayerMovement playerMovement;
    private bool isMoving;// Check if player is moving

    [Header("Left-Right Section")]
    [SerializeField] private float xMoveAmount; // Amount of movement on x-Axis
    [SerializeField] private float moveDuration; // Duration of movement process

    [Header("Jump Section"), Space(10)]
    [SerializeField] private float jumpPower; // Jumping power. Used for DoJump(..)
    [SerializeField] private int numJumps; // Number of jumps. Used for DoJump(..)
    [SerializeField] private float jumpDuration; // Duration of jumping process. Used for DoJump(..)
    #endregion

    #region Methods

    /// <summary>
    /// Makes the declared movement for player.
    /// </summary>
    /// <param name="playerMovement">Movement type of player. May be left, right or jump.</param>
    public void MovePlayer(PlayerMovement playerMovement)
    {
        switch (playerMovement)
        {
            case PlayerMovement.ToRight:
                //MoveIfPossible(xMoveAmount);
                StartCoroutine(MoveIfPossible(xMoveAmount));
                break;
            case PlayerMovement.ToLeft:
                //MoveIfPossible(-xMoveAmount);
                StartCoroutine(MoveIfPossible(-xMoveAmount));
                break;
            case PlayerMovement.ToUp:
                StartCoroutine(HandleJump());
                break;
        }
    }

    /// <summary>
    /// Calculates the new position and moves player toward
    /// that position if player IS NOT already at that position.
    /// </summary>
    /// <param name="xMoveAmount"></param>
    public IEnumerator MoveIfPossible(float xMoveAmount)
    {
        isMoving = true;
        float newPosOnX = transform.position.x;
        if (newPosOnX != xMoveAmount)
        {
            newPosOnX = xMoveAmount;
            transform.DOMoveX(newPosOnX, moveDuration);
        }
        yield return new WaitForSeconds(moveDuration);
        isMoving = false;
    }

    /// <summary>
    /// Starts jumping process.
    /// </summary>
    /// <returns></returns>
    public IEnumerator HandleJump()
    {
        isMoving = true;
        transform.DOJump(
            transform.position,
            jumpPower,
            numJumps,
            jumpDuration).SetEase(ease);

        yield return new WaitForSeconds(jumpDuration);
        isMoving = false;
    }

    /// <summary>
    /// Determines the movement type of player according to swipe action.
    /// </summary>
    /// <param name="swipeState">The swipe action which is done by user.</param>
    public void HandleSwipe(SwipeState swipeState)
    {
        switch (swipeState)
        {
            case SwipeState.Right:
                PlayerMovement = PlayerMovement.ToRight;
                break;
            case SwipeState.Left:
                PlayerMovement = PlayerMovement.ToLeft;
                break;
            case SwipeState.Up:
                PlayerMovement = PlayerMovement.ToUp;
                break;
        }
    }
    #endregion

    #region Trigger Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PlayerMovement = PlayerMovement.ToUp;
            // We can make the camera do some cinematic animations
            // and we can make the ground stopted or slowed while jumping. 
        }
    }
    #endregion

    #region Enable/Disable
    private void OnEnable()
    {
        SwipeInput.swipeAction += HandleSwipe;
    }
    private void OnDisable()
    {
        SwipeInput.swipeAction -= HandleSwipe;
    }
    #endregion
}
