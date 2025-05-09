using UnityEngine;
using UnityEngine.UI;

public class DestinySword : Skill
{
    private float cost;
    private float mana;
    private float damage;

    public override void Execute(GameObject player)
    {
        Debug.Log("Execute attack");
    }

    public void Swordzazo()
    {
        mana -= cost;
    }
}
