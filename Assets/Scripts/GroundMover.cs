using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    #region Variables & Constructors

    #region Get & Set
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    public bool DoMove
    {
        get => doMove;
        set => doMove = value;
    }
    #endregion
    private Rigidbody body;
    private float speed;
    private Renderer myRenderer;
    [SerializeField] private bool doMove;

    #endregion

    #region MonoBehaviour
    void Start()
    {
        body = GetComponent<Rigidbody>();
        myRenderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        Speed = GameManager.Instance.GameSpeed;
        myRenderer.material.color = GameManager.Instance.GroundColor;

        if (DoMove && GameManager.Instance.IsPlaying)
            body.velocity = Vector3.back * Speed * Time.deltaTime;
        else
        {
            body.velocity = Vector3.zero;
        }
    }
    #endregion
}
