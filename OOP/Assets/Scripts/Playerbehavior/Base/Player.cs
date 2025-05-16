using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    public LifeSystem _lifeSystem = new LifeSystem(100f, 0f, 100f);
    public ManaSystem _manaSystem = new ManaSystem(100f, 0f, 100f, 5f);

    //Se crean los eventos para que el UIManager pueda subscribirse o escucharlos
    public Action<float> OnSpendMana;
    public Action<float> OnSpendLife;
    public Action<float, Image> OnUseSkill;

    public abstract void ApplySkillCost(int cost);
    public virtual float GetManaPercentage() => _manaSystem.CurrentMana /_manaSystem.MaxValue; //se obtiene el porcentaje de mana actual en funcion del maximo de mana
    public virtual float GetlifePercentage() => _lifeSystem.CurrentValue / _lifeSystem.MaxValue;

    public void NotifySkillUsed(float cooldown, Image targetIcon)//invoca el evento de uso de habilidad
    {
        OnUseSkill?.Invoke(cooldown, targetIcon);
    }
}