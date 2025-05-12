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
    private float currentMana ;
    public ManaSystem(float maxValue, float minValue, float currentValue, float speedRecharge) : base(maxValue, minValue, currentValue)
    {
        this.speedRecharge = speedRecharge;
        this.currentMana = currentValue;
    }

    public float CurrentMana { get => currentMana;}

    public void Recharge(ManaState state, float amount) 
    {
        if (state == regenCondition)
        {
            ModifyValue(amount * speedRecharge); //multiply the amount by the speed of recharge
        }
        else 
        {
            ModifyValue(amount); //just modify the value
        }
    }

    public void SpendMana(int value) 
    {
        Debug.Log($"[manaDebugger] Spend mana 1 : {value}");
        currentMana -= value; //subtract the value from the current mana
        Debug.Log($"[manaDebugger] spend mana 2 : {currentMana}");
    }
}
