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

    private Dictionary<string, List<EnemyBase>> enemyPools;
    void Start()
    {
        enemyPools = new Dictionary<string, List<EnemyBase>>();

        foreach(EnemyBase enemy in enemyPrefabs)
        {
            string tag = enemy.tag;

            enemyPools[tag] = new List<EnemyBase>(maxPoolSize);
        }
    }

    public EnemyBase GetEnemy(EnemyType enemyType)
    {
        string tag = enemyType.ToString();

        foreach(EnemyBase enemy in enemyPools[tag]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPools[tag].Count < maxPoolSize) 
            return CreateEnemy((int) enemyType);
        
        return null;
    }
    public EnemyBase GetEnemy(int enemyIndex)
    {
        EnemyType type = (EnemyType) enemyIndex;
        string tag     = enemyPrefabs[enemyIndex].tag;
        
        foreach(EnemyBase enemy in enemyPools[tag]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPools[tag].Count < maxPoolSize) 
            return CreateEnemy(enemyIndex);
        
        return null;
    }

    public EnemyBase GetEnemy(string enemyTag)
    {
        EnemyType type  = (EnemyType) System.Enum.Parse(typeof(EnemyType), enemyTag, true);
        
        foreach(EnemyBase enemy in enemyPools[tag]) 
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        if (enemyPools[tag].Count < maxPoolSize) 
            return CreateEnemy((int) type);
        
        return null;
    }

    public void GenerateEnemies(string enemyTag, int amount, ref List<EnemyBase> outputList)
    {
        List<EnemyBase> pooledEnemies = new List<EnemyBase>();

        foreach (EnemyBase enemy in enemyPools[enemyTag])
        {
            if (!enemy.gameObject.activeInHierarchy)
                pooledEnemies.Add(enemy);

             if (pooledEnemies.Count == amount)
             {
                outputList.AddRange(pooledEnemies);
                return;
             }
        }

        EnemyType enemyType = (EnemyType) System.Enum.Parse(typeof(EnemyType), enemyTag, true);

        for(int i = 0; i < amount - pooledEnemies.Count; i++)
        {
            EnemyBase newEnemy  = CreateEnemy((int) enemyType);

            outputList.Add(newEnemy);
        }

        return;
    }

    private EnemyBase CreateEnemy(int enemyIndex)
    {
        EnemyBase enemy = Instantiate(enemyPrefabs[enemyIndex]);
        
        enemy.gameObject.SetActive(false);
        enemyPools[enemy.tag].Add(enemy);

        return enemy;
    }
}
