using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 40;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            PlayerXP xp = player.GetComponent<PlayerXP>();

            if (xp != null)
            {
                xp.AddXP(10);
            }
        }
        Destroy(gameObject);
    }
}