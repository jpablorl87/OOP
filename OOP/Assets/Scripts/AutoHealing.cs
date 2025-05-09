using UnityEngine;
using UnityEngine.UI;

public class AutoHealing : Skill
{
    private float life;
    private float mana;
    private float recharge;
    private float cost;

    public override void Execute(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    //After a key is pressed, we heal an amount of health
    public void Healing()
    {
        life += recharge;
        mana -= cost;
    }
}
