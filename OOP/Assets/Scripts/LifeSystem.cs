using UnityEngine;

public class LifeSystem : Statistics
{

    public LifeSystem(float maxValue, float minValue, float currentValue) : base(maxValue, minValue, currentValue)
    {

    }

    //this method is used to spend life points
    public void UseLife(float amount)
    {
        if (CurrentValue - amount >= MinValue)
        {
            CurrentValue -= amount;
        }
        else
        {
            Debug.Log("Not enough life points!");
        }
    }

    //this method is used to recharge life points
    public void RechargeLife(float amount)
    {
        if (CurrentValue + amount <= MaxValue)
        {
            CurrentValue += amount;
        }
        else
        {
            Debug.Log("Life points are full!");
        }
    }
}
