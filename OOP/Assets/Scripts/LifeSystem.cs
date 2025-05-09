using UnityEngine;

public class LifeSystem : Statistics
{

    public LifeSystem(float maxValue, float minValue, float currentValue) : base(maxValue, minValue, currentValue)
    {

    }

    public void TakeDamage(float amount)
    {
        ModifyValue(-amount); //subtract the damage amount from the current value
    }

    public void Heal(float amount)
    {
        ModifyValue(amount); //add the healing amount to the current value
    }
}
