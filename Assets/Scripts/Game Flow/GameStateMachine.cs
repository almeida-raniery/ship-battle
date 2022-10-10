using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    
    public EnemySpawner enemySpawner;
    public GameObject playerObject;
    public Canvas mainMenuCanvas;
    public Canvas HudCanvas;
    public Canvas GameOverCanvas;
    public Canvas worldCanvas;
    public int sessionDuration;
    
    private Timer sessionTimer;

    public void InitGame()
    {
        sessionTimer = new Timer(sessionDuration);

        playerObject.SetActive(true);
        HudCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        worldCanvas.gameObject.SetActive(false);
        sessionTimer.SetAlarm(GameOver);
        enemySpawner.StartSpawn();

        enemySpawner.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(sessionTimer != null && !sessionTimer.isDone)
            sessionTimer.Tick();
    }

    public void GameOver()
    {
        HudCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(true);
        playerObject.SetActive(false);

        sessionTimer.UnsetAlarm();
        enemySpawner.StopSpawn();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
