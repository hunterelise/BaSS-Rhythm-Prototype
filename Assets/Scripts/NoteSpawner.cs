using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject leftNotePrefab;
    public GameObject downNotePrefab;
    public GameObject upNotePrefab;
    public GameObject rightNotePrefab;

    [Header("Spawn Points")]
    public Transform leftSpawn;
    public Transform downSpawn;
    public Transform upSpawn;
    public Transform rightSpawn;

    [Header("Timing")]
    public float spawnDelay = 1f;
    public float startDelay = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // pick a random lane each time (or later use a chart)
            int lane = Random.Range(0, 4);

            switch (lane)
            {
                case 0:
                    Instantiate(leftNotePrefab, leftSpawn.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(downNotePrefab, downSpawn.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(upNotePrefab, upSpawn.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(rightNotePrefab, rightSpawn.position, Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
