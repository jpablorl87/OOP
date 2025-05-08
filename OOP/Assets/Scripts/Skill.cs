using UnityEngine;
using UnityEngine.UI;

public abstract class Skill
{
    private string nameSkill;
    private Image icon;
    private float coolDown;

    protected Skill(string nameSkill, Image icon, float coolDown)
    {
        this.nameSkill = nameSkill;
        this.icon = icon;
        this.coolDown = coolDown;
    }

    public float Cooldown
    {
        get { return coolDown; } //read-only property for cooldown
        set 
        {
            if (value >= 0)
            {
                coolDown = value;
            }
            else
            {
                Debug.LogError("Cooldown cannot be negative");
            }
        }
    }

    public string NameSkill
    {
        get { return nameSkill; }
        protected set 
        {
            if (!string.IsNullOrEmpty(value))
            {
                nameSkill = value;
            }
            else
            {
                Debug.LogError("Skill name cannot be null or empty");
            }
        }
    }

    public Image IconSkill
    {
        get { return icon; }

        protected set
        {
            if (value != null)
            {
                icon = value;
            }
            else
            {
                Debug.LogError("Icon cannot be null");
            }
        }
    }
}
