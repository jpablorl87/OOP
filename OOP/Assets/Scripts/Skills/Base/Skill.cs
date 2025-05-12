using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public event Action OnCompleted;

    [Header("Skill Settings")]
    [SerializeField] protected string skillName;
    [SerializeField] protected Sprite icon;
    [SerializeField] public float coolDown;
    [SerializeField] public int cost;
    protected float currentCooldown;

    public float CurrentCooldown => currentCooldown;
    public Sprite Icon => icon;
    public bool isReady => CurrentCooldown <= 0;
    
    protected void RiseOnCompleted() => OnCompleted?.Invoke();

    public abstract void Execute(GameObject player, Player playerClass);//Metodo abstracto que se implementa en cada habilidad

    public virtual void Update()
    {
        UpdateCooldown();
    }

    public void StartCooldown()
    {
        currentCooldown = coolDown;
        
    }

    private void UpdateCooldown()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                RiseOnCompleted();
            }
        }
    }
}