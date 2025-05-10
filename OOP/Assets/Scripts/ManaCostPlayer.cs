using UnityEngine;

public class ManaCostPlayer : Player
{

    public override void ApplySkillCost(int cost)
    {
        _manaSystem.SpendMana(cost);
        OnSpendMana?.Invoke(_manaSystem.CurrentValue);
    }
}
