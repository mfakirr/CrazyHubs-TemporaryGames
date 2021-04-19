using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "LevelInfoAsset", menuName = "Level/Level Info Asset")]
public class LevelInfoAsset : ScriptableObject
{
    [Space]
    public List<LevelInfo> levelInfos = new List<LevelInfo>();
}

[System.Serializable]
public struct LevelInfo
{
    [Header("Character Speed")]
    public int movementSpeed;

    [Space(20)]
    public bool spawnPlatforms;
    
    [Space(20)]
    public Vector3 cameraPosition;

    [Space(20)]
    public float weightLossSpeed;

    [Space(20)]
    public Color platformColor;

    [ShowIf("spawnPlatforms"), Header("Platform Count At That Level")]
    public int platformCount;

    [ShowIf("spawnPlatforms"), Header("Spawnable Platform Prefabs"), Space(20)]
    public List<GameObject> platformList;

    [ShowIf("spawnPlatforms"), Header("Offset Values Of Platforms"), Space(20)]
    public float platformOffSet;

    [Space(10)]
    public bool spawnEndPlatform;

    [ShowIf("spawnEndPlatform")]
    public GameObject endPlatform;

    [ShowIf("spawnEndPlatform")]
    public float endPlatformOffSet;
}
