using UnityEngine;
using UnityEngine.UI;

public class AutoShield : Skill
{
    private float cost;
    private float mana;
    public AutoShield(string nameSkill, Image icon, float coolDown, float cost, float mana) : base(nameSkill, icon, coolDown)
    {
        this.cost = cost;
        this.mana = mana;
    }
    public void Shield()
    {
        mana -= cost;
    }
    //Profe aquí esta vuelta conecta con esta otra y hay un escudo, imagineselo
}
