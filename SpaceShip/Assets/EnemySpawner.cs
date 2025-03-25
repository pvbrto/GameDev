using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab do inimigo
    public float spawnRate = 2f;    // Tempo entre spawns
    public float spawnYMin = -3f;   // Posição mínima Y
    public float spawnYMax = 3f;    // Posição máxima Y

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
        if (transform.position.x <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPos = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 2f, spawnY, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}