using UnityEngine;
using TMPro;

public class GameTimeCounter : MonoBehaviour
{
    public GameStateMachine gameStateManager;

    private TMP_Text element;
    // Start is called before the first frame update
    void Start()
    {
        element = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int roundedTime   = (int) gameStateManager.sessionTimer.count;
        int countDownTime = gameStateManager.sessionDuration - roundedTime;

        element.text = string.Format("Time: {0}", countDownTime);
    }
}
