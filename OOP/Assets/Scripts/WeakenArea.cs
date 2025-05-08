using UnityEngine;
using UnityEngine.UI;

public class WeakenArea : Skill
{
    private float cost;
    private float damage;
    private float mana;
    public WeakenArea(string nameSkill, Image icon, float coolDown, float cost, float damage, float mana) : base(nameSkill, icon, coolDown)
    {
        this.cost = cost;
        this.damage = damage;
        this.mana = mana;
    }
    public void MiddleFingerzazo()
    {
        mana -= cost;
    }
}
