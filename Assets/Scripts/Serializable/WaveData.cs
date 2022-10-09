using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveData")]
public class WaveData : ScriptableObject
{
    public EnemyBase[] enemies;
    [HideInInspector]
    public List<int> enemyAmounts;
    public float spawnInterval;
}
