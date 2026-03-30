using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public float skillRange = 3f;
    public int damage = 20;
    public float cooldown = 5f;

    private float lastUseTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= lastUseTime + cooldown)
            {
                UseSkill();
                lastUseTime = Time.time;
            }
        }
    }

    void UseSkill()
    {
        Debug.Log("SKILL USADA!");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance <= skillRange)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}