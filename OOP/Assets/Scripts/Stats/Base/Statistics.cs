using UnityEngine;

public abstract class Statistics
{
    [SerializeField] private float maxValue;
    [SerializeField] private float minValue;
    [SerializeField] private float currentValue;

    protected Statistics(float maxValue, float minValue, float currentValue)
    {
        this.maxValue = maxValue = 100;
        this.minValue = minValue = 0;
        this.currentValue = currentValue = 100;
    }

    public float MaxValue => maxValue; //read-only property for max value

    public float CurrentValue => currentValue; //read-only property for current value

    public virtual void ModifyValue(float amount) 
    {
        currentValue = Mathf.Clamp(currentValue + amount, minValue, maxValue); //clamp the current value between min and max
    }
}
