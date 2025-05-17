using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Healing", menuName = "Skills/AutoHealing")]
public class AutoHealing : Skill
{
    [SerializeField] private float healQuantity;
    [SerializeField] private float healInt;
    [SerializeField] private float healTimer;

    public override void Execute(GameObject player, Player playerClass)
    { 
        if (!isReady) return;//Verify if it's ready to use the skill
        StartCooldown();
        if (player != null)
        {
            healTimer += Time.deltaTime;

                playerClass._lifeSystem.Heal(healQuantity);
                playerClass.OnSpendLife?.Invoke(playerClass._lifeSystem.CurrentValue);
                healTimer = 0f;
                Debug.Log("Curando");
        }
    }
}
