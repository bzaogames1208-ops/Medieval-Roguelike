using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 40;
    private int currentHealth;

    public int xpValue = 10;

public GameObject xpPrefab;


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
    GameObject xp = Instantiate(xpPrefab, transform.position, Quaternion.identity);

    XPCollect xpScript = xp.GetComponent<XPCollect>();

    if (xpScript != null)
        {
        xpScript.xpValue = xpValue;
        }

    Destroy(gameObject);
    }
}