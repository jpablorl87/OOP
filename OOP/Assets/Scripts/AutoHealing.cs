using UnityEngine;
using UnityEngine.UI;

public class AutoHealing : Skill
{
    private float life;
    private float mana;
    private float recharge;
    private float cost;
    public AutoHealing(string nameSkill, Image icon, float coolDown, float life, float mana, float recharge, float cost) : base(nameSkill, icon, coolDown)
    {
        this.life = life;
        this.mana = mana;
        this.cost = cost;
        this.recharge = recharge;
    }
    //After a key is pressed, we heal an amount of health
    public void Healing()
    {
        life += recharge;
        mana -= cost;
    }
}
