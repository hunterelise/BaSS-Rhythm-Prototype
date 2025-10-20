using UnityEngine;

public class NoteDestroyer : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            if (!scoreManager)
                scoreManager = GameObject.FindObjectOfType<ScoreManager>();

            scoreManager.AddScore("Miss");
            Destroy(other.gameObject);
        }
    }
}
