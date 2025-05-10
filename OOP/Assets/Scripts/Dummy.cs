using UnityEngine;

public class Dummy : Player
{
    public override void ApplySkillCost(int cost)
    {
        
        Debug.Log($"Habilidad usada");
    }

    protected override void Awake()//No inicializar el sistema
    {
        _lifeSystem = null;
        _manaSystem = null;
    }

    public override float GetManaPercentage() => 1f;
    public override float GetlifePercentage() => 1f;

}
