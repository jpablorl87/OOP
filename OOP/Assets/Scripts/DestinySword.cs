using UnityEngine;
using UnityEngine.UI;

public class DestinySword : Skill
{
    private float cost;
    private float mana;
    private float damage;

    public override void Execute(GameObject player, Player playerClass)
    {
        throw new System.NotImplementedException();
    }

    public void Swordzazo()
    {
        mana -= cost;
    }
}
