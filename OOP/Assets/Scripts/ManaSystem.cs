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
}
