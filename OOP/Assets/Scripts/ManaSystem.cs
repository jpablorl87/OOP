using UnityEngine;
public enum ManaState{time, instant}


public class ManaSystem : Statistics
{
    private ManaState state;
    public ManaSystem(float maxValue, float minValue, float currentValue) : base(maxValue, minValue, currentValue)
    {
    }

    public override void AffectStat(float currentValue, float value)
    {
        currentValue -= value;
    }
}
