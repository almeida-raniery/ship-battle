using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Chaser,
    Shooter
}

public class EnemyFactory : MonoBehaviour
{
    public int maxPoolSize;
    public List<EnemyBase> enemyPrefabs;

    private Dictionary<EnemyType, List<EnemyBase>> enemyPool;
    void Start()
    {
        foreach(EnemyBase enemy in enemyPrefabs)
        {
            EnemyType type = (EnemyType) System.Enum.Parse(typeof(EnemyType), enemy.tag, true);

            enemyPool[type] = new List<EnemyBase>(maxPoolSize);
        }
    }

    public EnemyBase GetEnemy(EnemyType type)
    {
        foreach(EnemyBase enemy in enemyPool[type]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPool[type].Count < maxPoolSize) 
            return CreateEnemy((int) type);
        
        return null;
    }
    public EnemyBase GetEnemy(int enemyIndex)
    {
        EnemyType type = (EnemyType) enemyIndex;
        
        foreach(EnemyBase enemy in enemyPool[type]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPool[type].Count < maxPoolSize) 
            return CreateEnemy((int) type);
        
        return null;
    }

    public EnemyBase GetEnemy(string enemyTag)
    {
        EnemyType type  = (EnemyType) System.Enum.Parse(typeof(EnemyType), enemyTag, true);
        
        foreach(EnemyBase enemy in enemyPool[type]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPool[type].Count < maxPoolSize) 
            return CreateEnemy((int) type);
        
        return null;
    }

    private EnemyBase CreateEnemy(int enemyIndex)
    {
        EnemyBase enemy = Instantiate(enemyPrefabs[enemyIndex]);
        EnemyType type  = (EnemyType) System.Enum.Parse(typeof(EnemyType), enemy.tag, true);
        
        enemy.gameObject.SetActive(false);
        enemyPool[type].Add(enemy);

        return enemy;
    }
}
