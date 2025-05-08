using UnityEngine;

public abstract class Statistics
{
    private float maxValue;
    private float minValue;
    private float currentValue;

    public Statistics(float maxValue, float minValue, float currentValue, float minValue1, float v, float currentValue1) : this(maxValue, minValue, currentValue)
    {
    }

    protected Statistics(float maxValue, float minValue, float currentValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
        this.currentValue = currentValue;
    }

    public float MaxValue
    {
        get { return maxValue; }
        protected set
        {
            if (value < minValue)
            {
                Debug.LogError("Max value cannot be less than min value.");
                return;
            }
            maxValue = value;
        } 
    }

    public float MinValue
    {
        get { return minValue; }
        protected set
        {
            if (value > maxValue)
            {
                Debug.LogError("Min value cannot be greater than max value.");
                return;
            }
            minValue = value;
        } 
    }

    public float CurrentValue
    {
        get { return currentValue; }
        protected set
        {
            if (value < minValue || value > maxValue)
            {
                Debug.LogError("Current value must be between min and max values.");
                return;
            }
            currentValue = value;
        } 
    }
}
