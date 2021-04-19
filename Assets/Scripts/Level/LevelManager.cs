using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;
    public int LevelIndex => levelIndex;
    private static LevelManager instance;
    private int levelIndex;
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        levelIndex = 0;
    }
    
    public void LevelUp()
    {
        levelIndex++;
    }
}
