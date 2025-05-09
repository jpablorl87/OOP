using UnityEngine;
using UnityEngine.UI;

public class AutoShield : Skill
{
    private float cost;
    private float mana;
    public override void Execute(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    public void Shield()
    {
        mana -= cost;
    }
    //Profe aquí esta vuelta conecta con esta otra y hay un escudo, imagineselo
}
