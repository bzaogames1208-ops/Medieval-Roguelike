using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float spawnRate = 2f;
    public float spawnDistance = 8f;

    private Transform player;

    private float gameTime = 0f;

    public GameObject bossPrefab;

    public float bossSpawnTime = 30f;
    private float bossTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        bossTimer += Time.deltaTime;

        if (bossTimer >= bossSpawnTime)
        {
            SpawnBoss();
            bossTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
    if (player == null) return;

    Vector2 spawnDirection = Random.insideUnitCircle.normalized;
    Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnDistance;

    GameObject enemyToSpawn = GetEnemyByTime();

    GameObject newEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

    // 💥 AQUI entra o aumento de vida
    EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();

    if (enemyHealth != null)
        {
        enemyHealth.maxHealth += Mathf.FloorToInt(gameTime * 0.5f);
        }
    }

    GameObject GetEnemyByTime()
    {
        // 0 = normal, 1 = fast, 2 = tank

        if (gameTime < 20f)
        {
            return enemyPrefabs[0]; // só normal
        }
        else if (gameTime < 40f)
        {
            return enemyPrefabs[Random.Range(0, 2)]; // normal + fast
        }
        else
        {
            return enemyPrefabs[Random.Range(0, 3)]; // todos
        }
    }

    void SpawnBoss()
    {
    Vector2 spawnDirection = Random.insideUnitCircle.normalized;
    Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnDistance;

    GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
    EnemyHealth health = boss.GetComponent<EnemyHealth>();

    if (health != null)
        {
            health.maxHealth += Mathf.FloorToInt(gameTime * 3f);
        }

    Debug.Log("BOSS SPAWNOU!");
    }
}