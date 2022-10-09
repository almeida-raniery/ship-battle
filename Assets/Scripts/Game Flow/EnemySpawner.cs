using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveData> waves;
    public List<Transform> spawnPoints;
    public EnemyFactory enemyFactory;
    public Transform playerTransform;
    public float waveInterval;
    public int startingWaveIndex;

    private Timer waveTimer;
    private Timer spawnTimer;
    private WaveData currentWave;
    private List<EnemyBase> remainingEnemies;
    private int currentWaveIndex;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Second);
        waveTimer    = new Timer(waveInterval);
        spawnTimer   = new Timer(waves[startingWaveIndex].spawnInterval, true);

        LoadWave(startingWaveIndex);
    }

    void Update()
    {
        if (!waveTimer.isDone)
            waveTimer.Tick();
        if (!spawnTimer.isDone)
            spawnTimer.Tick();
    }

    void LoadWave(int waveIndex)
    {
        if(waveIndex >= waves.Count)
            return;

        WaveData wave = waves[waveIndex];

        remainingEnemies = new List<EnemyBase>();
        
        for (int i = 0; i < wave.enemies.Length; i++)
        {
            EnemyBase enemyPrefab = wave.enemies[i];
            int enemyAmount       = wave.enemyAmounts[i];

            enemyFactory.GenerateEnemies(enemyPrefab.tag, enemyAmount, ref remainingEnemies);
        }

        currentWave      = wave;
        currentWaveIndex = waveIndex;

        spawnTimer.SetAlarm(SpawnNext);

        ShuffleSpawnOrder();
    }
    void ShuffleSpawnOrder()
    {
        for (int i = 0; i < remainingEnemies.Count; i++) {
            EnemyBase temp  = remainingEnemies[i];
            int randomIndex = Random.Range(i, remainingEnemies.Count);

            remainingEnemies[i] = remainingEnemies[randomIndex];
            remainingEnemies[randomIndex] = temp;
        }
    }

    void SpawnNext()
    {
        if (remainingEnemies.Count == 0)
        {
            waveTimer.SetAlarm(LoadNextWave);
            spawnTimer.UnsetAlarm();

            return;
        }

        Transform spawnPoint = GetRandomSpawnPoint();
        EnemyBase enemy      = remainingEnemies[0];

        enemy.target             = playerTransform;
        enemy.transform.position = spawnPoint.position;

        enemy.gameObject.SetActive(true);

        remainingEnemies.RemoveAt(0);
    }

    void LoadNextWave()
    {
        LoadWave(currentWaveIndex + 1);
    }

    Transform GetRandomSpawnPoint()
    {
        int pointIndex = Random.Range(0, spawnPoints.Count);

        return spawnPoints[pointIndex];
    }
}
