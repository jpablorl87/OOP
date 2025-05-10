using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public ManaSystem manaSystem;

    //Se crean los eventos para que el UIManager pueda subscribirse o escucharlos
    public Action<float> OnSpendMana;
    public Action<float> OnSpendLife;
    public Action<float, Image> OnUseSkill;

    private void Awake()
    {
        InitializeSystems();
    }

    /// Se inicializan los sistemas de vida y mana :b
    private void InitializeSystems()
    {
        lifeSystem = new LifeSystem(100f, 0f, 100f);
        manaSystem = new ManaSystem(100f, 0f, 100f, 5f);
    }

    
    public float GetManaPercentage() => manaSystem.CurrentMana / manaSystem.MaxValue;
    public float GetlifePercentage() => lifeSystem.CurrentValue / lifeSystem.MaxValue;

    public void UpdateStatisticMana(int amount)
    {
        manaSystem.SpendMana(amount);
        OnSpendMana?.Invoke(manaSystem.CurrentMana);//invoca el evento de gasto de mana
    }

    public void UpdateStatisticLife(int amount)//invoca el evento de gasto de vida
    {
        if (amount < 0) lifeSystem.TakeDamage(Mathf.Abs(amount));
        else if (amount > 0) lifeSystem.Heal(amount);

        OnSpendLife?.Invoke(lifeSystem.CurrentValue);
    }

    public void NotifySkillUsed(float cooldown, Image targetIcon)//invoca el evento de uso de habilidad
    {
        OnUseSkill?.Invoke(cooldown, targetIcon);
    }
}