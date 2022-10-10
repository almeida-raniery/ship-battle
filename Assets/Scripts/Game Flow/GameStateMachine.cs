using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateMachine : MonoBehaviour
{
    
    public EnemySpawner enemySpawner;
    public GameObject playerObject;
    public Canvas mainMenuCanvas;
    public Canvas HudCanvas;
    public Canvas GameOverCanvas;
    public Canvas worldCanvas;
    public Slider sessionTimeSlider;
    public PlayerScore playerScore;
    public int sessionDuration;
    public Timer sessionTimer;

    void Start()
    {
        sessionTimeSlider.onValueChanged.AddListener(SetSessionTimer);
    }

    public void InitGame()
    {
        sessionTimer = new Timer(sessionDuration);

        playerObject.SetActive(true);
        HudCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        worldCanvas.gameObject.SetActive(true);
        sessionTimer.SetAlarm(GameOver);
        enemySpawner.StartSpawn();

        enemySpawner.enabled = true;
    }

    void Update()
    {
        if(sessionTimer != null && !sessionTimer.isDone)
            sessionTimer.Tick();
    }

    public void SetSessionTimer(float timeScale)
    {
        int timeIncrement = (int) timeScale * 30;

        sessionDuration = 60 + timeIncrement;
    }

    public void GameOver()
    {
        HudCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(true);
        playerObject.SetActive(false);

        sessionTimer.UnsetAlarm();
        enemySpawner.StopSpawn();
         playerScore.SetFinalScore();
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
