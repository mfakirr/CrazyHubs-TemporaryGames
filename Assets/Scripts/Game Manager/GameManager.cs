using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Getters & Setters
    public float GameSpeed
    {
        get => gameSpeed;
        set => gameSpeed = value;
    }
    public float WeightLossSpeed
    {
        get => weightLossSpeed;
        set => weightLossSpeed = value;
    }
    public Vector3 CameraPosition
    {
        get => cameraPosition;
        set => cameraPosition = value;
    }
    public Color GroundColor
    {
        get => groundColor;
        set => groundColor = value;
    }
    public bool IsPlaying
    {
        get => isPlaying;
        set => isPlaying = value;
    }
    public int Score
    {
        get => score;
        set => score = value;
    }
    public static GameManager Instance => instance;
    #endregion

    #region Variables
    [SerializeField] float gameSpeed;
    [SerializeField] float weightLossSpeed;
    [SerializeField] Vector3 cameraPosition;
    [SerializeField] Color groundColor;
    [SerializeField] bool isPlaying;
    [SerializeField] int score;
    private static GameManager instance;
    #endregion

    #region MonoBehaviour(Start, Update etc.)
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

}