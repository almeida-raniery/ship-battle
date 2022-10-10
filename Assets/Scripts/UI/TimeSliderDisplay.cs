using UnityEngine;
using TMPro;

public class TimeSliderDisplay : MonoBehaviour
{
    
    public GameStateMachine gameStateManager;
    private TMP_Text element;
    void Start()
    {
        element = GetComponent<TMP_Text>();
    }

    void Update()
    {
        element.text = string.Format("Time: {0} Seconds", gameStateManager.sessionDuration);
    }
}
