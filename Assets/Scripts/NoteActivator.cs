using UnityEngine;

public class NoteActivator : MonoBehaviour
{
    public KeyCode keyToPress;
    public ScoreManager scoreManager;
    public float fadeDuration = 0.2f;

    private int triggerCount = 0;
    private string hitType = "";
    private bool hit = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!scoreManager)
            scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && triggerCount > 0 && !hit)
        {
            hit = true;
            scoreManager.AddScore(hitType);
            StartCoroutine(FadeAndDestroy());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Perfect"))
            hitType = "Perfect";
        else if (other.CompareTag("Good"))
            hitType = "Good";
        else if (other.CompareTag("Ok"))
            hitType = "Ok";

        triggerCount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerCount = Mathf.Max(0, triggerCount - 1);
    }

    private System.Collections.IEnumerator FadeAndDestroy()
    {
        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(gameObject);
    }
}
