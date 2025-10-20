using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    public int score = 0;

    public int perfectPoints = 100;
    public int goodPoints = 50;
    public int okPoints = 25;
    public int missPoints = 0;

    public void AddScore(string hitType)
    {
        switch (hitType)
        {
            case "Perfect":
                score += perfectPoints;
                break;
            case "Good":
                score += goodPoints;
                break;
            case "Ok":
                score += okPoints;
                break;
            case "Miss":
                score += missPoints;
                break;
            default:
                Debug.LogWarning("Unknown hit type: " + hitType);
                break;
        }

        Debug.Log($"Hit: {hitType} | Score: {score}");
    }
}
