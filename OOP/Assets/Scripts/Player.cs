using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public ManaSystem manaSystem;
    public Action<float> OnSpendMana; 
    public Action<float> OnSpendLife;
    public Action<float> OnUseSkill;
    

    private void Awake()
    {
        
        lifeSystem = new LifeSystem(100f, 0f, 100f);
        Debug.Log("LifeSystem inicializado. Vida actual: " + lifeSystem.CurrentValue);
        manaSystem = new ManaSystem(100f, 0f, 100f, 5f);
        Debug.Log("ManaSystem inicializado. Mana actual: " + manaSystem.CurrentValue);

    }

    public float GetManaPercentage()
    {
       return manaSystem.CurrentMana / manaSystem.MaxValue;
    }

    public float GetlifePercentage()
    {
        return lifeSystem.CurrentValue / lifeSystem.MaxValue;
    }
    
    

    public void UpdateStatisticMana(int amount)
    {
        manaSystem.SpendMana(amount);
        Debug.Log($"${{manaDebugger}} updateStatisticsMana : {amount}");
        OnSpendMana?.Invoke(manaSystem.CurrentMana);
    }
    
    public void UpdateStatisticLife(int amount)
    {
        if (amount < 0)
        {
            lifeSystem.TakeDamage(Mathf.Abs(amount));
            Debug.Log($"Recibido daño: {-amount}. Vida actual: {lifeSystem.CurrentValue}");
        }
        else if (amount > 0)
        {
            lifeSystem.Heal(amount);
            Debug.Log($"Recuperado: {amount} vida. Vida actual: {lifeSystem.CurrentValue}");
        }

        OnSpendLife?.Invoke(lifeSystem.CurrentValue);
    }
    public void NotifySkillUsed(float cooldown)
    {
        Debug.Log($"[skillDebugger] Player notifica skill con cooldown: {cooldown}");
        OnUseSkill?.Invoke(cooldown);
    }

   

}
