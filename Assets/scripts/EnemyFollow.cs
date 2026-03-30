using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public float damageInterval = 1f; // tempo entre cada dano (em segundos)
    
    private Transform player;
    private float damageTimer = 0f; // contador interno

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // atualiza o timer todo frame
        if (damageTimer > 0f)
            damageTimer -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && damageTimer <= 0f)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                damageTimer = damageInterval; // reinicia o cooldown
            }
        }
    }
}