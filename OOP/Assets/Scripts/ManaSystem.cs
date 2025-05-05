using UnityEngine;
public enum ManaState
{
    time, 
    instant 
}


public class ManaSystem : Statistics
{
    private float speedRecharge; //this variable is used to define the speed of mana recharge]
    public ManaSystem(float maxValue, float minValue, float currentValue, float speedRecharge) : base(maxValue, minValue, currentValue)
    {
        this.speedRecharge = speedRecharge;
    }

    public void RechargeMana(float amount, ManaState state)
    {
        if (state == ManaState.time)
        {
            CurrentValue += amount * Time.deltaTime * speedRecharge; //recharge the mana over time
        }
        else if(state == ManaState.instant)
        {
            CurrentValue += amount; //recharge the mana instantly
        }

        Mathf.Clamp(CurrentValue, MinValue, MaxValue);
    }
}
