using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : ScriptableObject
{
    public event Action OnCompleted;

    [SerializeField] protected string nameSkill;
    [SerializeField] protected Image icon;
    [SerializeField] protected float coolDown;
    [SerializeField] public int cost;
    protected float currentCooldown; //current cooldown time


    public bool isReady => currentCooldown <= 0; //check if the skill is ready to be used

    /// <summary>
    /// Execute the skill on the player
    /// </summary>
    public abstract void Execute(GameObject player, Player playerClass); //abstract method to be implemented by derived classes

    public virtual void Update()
    {
        CoolDownReset(); //call the cooldown reset method
    }

    protected void RiseOnCompleted() => OnCompleted?.Invoke(); //invoke the OnCompleted


    private void CoolDownReset() 
    {
        if (currentCooldown > 0)
        {
            Debug.Log($"Current cooldown: {currentCooldown}");
            currentCooldown -= Time.deltaTime; //reduce cooldown time

            if (currentCooldown <= 0)
            {
                RiseOnCompleted(); //reset cooldown time
            }
        }
    }
}
