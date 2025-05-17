using UnityEngine;
public enum ManaState
{
    time, 
    instant 
}


public class ManaSystem : Statistics
{
    [SerializeField] private ManaState regenCondition;
    [SerializeField] private float speedRecharge = 1;
    public ManaSystem(float maxValue, float minValue, float currentValue, float speedRecharge) : base(maxValue, minValue, currentValue)
    {
        this.speedRecharge = speedRecharge;
    }

    public float CurrentMana => CurrentValue;

    public void Recharge(float amount) 
    {
        ModifyValue(amount);
    }

    public void SpendMana(int value) 
    {
        Debug.Log($"[manaDebugger] Spend mana 1 : {value}");
        ModifyValue(-value);
        Debug.Log($"[manaDebugger] spend mana 2 : {CurrentValue}");
    }
}
