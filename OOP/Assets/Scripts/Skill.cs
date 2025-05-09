using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : ScriptableObject
{
    public event Action OnCompleted;

    [SerializeField] protected string nameSkill;
    [SerializeField] protected Image icon;
    [SerializeField] protected float coolDown;
    protected float currentCooldown; //current cooldown time


    public bool isReady => currentCooldown <= 0; //check if the skill is ready to be used

    public abstract void Execute(GameObject player); //abstract method to be implemented by derived classes

    public virtual void Update()
    {
        CooldownReduction(); 
    }

    protected void RiseOnCompleted() => OnCompleted?.Invoke(); //invoke the OnCompleted event

    private void CooldownReduction() 
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime; //reduce cooldown time
        }
    }
}
