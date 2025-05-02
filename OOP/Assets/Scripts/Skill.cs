using UnityEngine;

public abstract class Skill
{
    private string name;
    private Sprite icon;
    private float coolDown;
    private float amount;

    protected Skill(string name, Sprite icon, float coolDown, float amount)
    {
        this.name = name;
        this.icon = icon;
        this.coolDown = coolDown;
        this.amount = amount;
    }

    public void UseSkill(float coolDown, float amount)
    {

    }
}
