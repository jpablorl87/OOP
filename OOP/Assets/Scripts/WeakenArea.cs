using UnityEngine;
using UnityEngine.UI;

public class WeakenArea : Skill
{
    private float cost;
    private float damage;
    private float mana;

    public override void Execute(GameObject player, Player playerClass)
    {
        throw new System.NotImplementedException();
    }

    public void MiddleFingerzazo()
    {
        mana -= cost;
    }
}
