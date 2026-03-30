using UnityEngine;

public class PetEvolution : MonoBehaviour
{
    private PetAttack attack;

    public int stage = 1;

    void Start()
    {
        attack = GetComponent<PetAttack>();
    }

    public void Evolve()
    {
    stage++;

    if (stage == 2)
        {
        transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        attack.damage += 3;
        attack.attackRange += 1f;
        Debug.Log("MÉDIO");
        }
    else if (stage == 3)
        {
        transform.localScale = new Vector3(2f, 2f, 1f);
        attack.damage += 5;
        attack.attackRange += 1.5f;
        Debug.Log("GRANDE");
        }
    else if (stage == 4)
        {
        transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        attack.damage += 7;
        attack.attackRange += 2f;
        Debug.Log("GIGANTE");
        }
    else
        {
        // depois disso só buffa
        attack.damage += 2;
        attack.attackCooldown *= 0.95f; // ataca mais rápido
        Debug.Log("Pet ficou mais forte!");
        }
    }
         
}