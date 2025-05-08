using UnityEngine;
using UnityEngine.UI;

public class DestinySword : Skill
{
    private float cost;
    private float mana;
    private float damage;
    public DestinySword(string nameSkill, Image icon, float coolDown, float cost, float mana, float damage) : base(nameSkill, icon, coolDown)
    {
        this.cost = cost;
        this.mana = mana;
        this.damage = damage;
    }
    public void Swordzazo()
    {
        mana -= cost;
    }
}
