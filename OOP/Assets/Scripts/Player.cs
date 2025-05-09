using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public ManaSystem manaSystem;
    public Action<float> OnSpendMana; 
    //falta OnSpendLife

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
    
    //Falta GetlifePercentage

    public void UpdateStatisticMana(int amount)
    {
        manaSystem.SpendMana(amount);
        Debug.Log($"${{manaDebugger}} updateStatisticsMana : {amount}");
        OnSpendMana?.Invoke(manaSystem.CurrentMana);
    }
    
    //Falta UpdateStatisticsLife
}
