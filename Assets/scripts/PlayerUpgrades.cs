using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private UpgradeManager upgradeManager;

    void Start()
    {
        upgradeManager = GetComponent<UpgradeManager>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                upgradeManager.ApplyUpgrade(1);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                upgradeManager.ApplyUpgrade(2);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                upgradeManager.ApplyUpgrade(3);
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
                upgradeManager.ApplyUpgrade(4);
        }
    }
}