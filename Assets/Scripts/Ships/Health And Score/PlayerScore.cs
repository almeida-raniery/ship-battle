using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public TMP_Text scoreDisplay;

    public void IncreaseScore()
    {
        score += 1;
        scoreDisplay.text = score.ToString();
    }
}