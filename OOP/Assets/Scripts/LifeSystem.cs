using UnityEngine;

public class LifeSystem : Statistics
{
    private float spentAmount;

    public LifeSystem(float maxValue, float minValue, float currentValue) : base(maxValue, minValue, currentValue)
    {

    }
}
