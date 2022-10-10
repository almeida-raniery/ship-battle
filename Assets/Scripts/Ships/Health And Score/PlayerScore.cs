using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public TMP_Text scoreDisplay;

    [SerializeField]
    private TMP_Text finalScoreDisplay;

    public void IncreaseScore()
    {
        score += 1;
        scoreDisplay.text = score.ToString();
    }

    public void SetFinalScore()
    {
        finalScoreDisplay.text = string.Format("Your Score: {0}", score);
    }
}