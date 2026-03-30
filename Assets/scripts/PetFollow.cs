using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public float speed = 4f;
    public float followDistance = 2f;
    public float detectionRange = 6f;

    private Transform player;

    void Start()
    {
        player = transform.parent;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance && distance <= detectionRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            // vai até o inimigo
            Vector2 direction = (closestEnemy.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        else
        {
            // volta pro player
            Vector2 targetPosition = (Vector2)player.position + new Vector2(followDistance, 0);
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}