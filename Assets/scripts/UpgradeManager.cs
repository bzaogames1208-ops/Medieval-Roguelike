using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private AutoAttack attack;
    private PlayerHealth health;
    private PlayerSkill skill;

    void Start()
    {
        attack = GetComponent<AutoAttack>();
        health = GetComponent<PlayerHealth>();
        skill = GetComponent<PlayerSkill>();
    }

    public void ApplyUpgrade(int choice)
    {
        switch (choice)
        {
            case 1:
                attack.damage += 2;
                Debug.Log("Dano aumentado!");
                break;

            case 2:
                health.maxHealth += 20;
                Debug.Log("Vida aumentada!");
                break;

            case 3:
                skill.cooldown *= 0.8f;
                Debug.Log("Skill mais rápida!");
                break;
        }

        Time.timeScale = 1f;
    }
}