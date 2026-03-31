using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int level = 1;
    public int xpToNextLevel = 20;

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log("XP: " + currentXP);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXP = 0;
        xpToNextLevel += 10;
        GameObject pet = transform.Find("Pet")?.gameObject;

        if (pet != null)
        {
            PetEvolution evolution = pet.GetComponent<PetEvolution>();

            if (evolution != null && level % 3 == 0)
            {
                evolution.Evolve();
            }
        }

        Debug.Log("LEVEL UP! Agora nível: " + level);
        Debug.Log("1 - Mais dano");
        Debug.Log("2 - Mais Vida");
        Debug.Log("3 - Cooldown da skill");
        Debug.Log("4 - Magnet (coleta XP de longe)");

        Time.timeScale = 0f; // pausa o jogo
    }
}
