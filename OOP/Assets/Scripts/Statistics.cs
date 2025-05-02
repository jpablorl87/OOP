using UnityEngine;

public abstract class Statistics
{
    private float maxValue;
    private float minValue;
    private float currentValue;

    protected Statistics(float maxValue, float minValue, float currentValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
        this.currentValue = currentValue;
    }

    public virtual void AffectStat(float value,float currentValue)
    {
        currentValue += value;
    }
}
