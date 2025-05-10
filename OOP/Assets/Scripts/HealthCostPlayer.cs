using UnityEngine;

public class HealthCostPlayer : Player
{
    public override void ApplySkillCost(int cost)
    {
        if (_lifeSystem == null) return;

        _lifeSystem.TakeDamage(cost);
        OnSpendLife?.Invoke(_lifeSystem.CurrentValue);
    }
}
