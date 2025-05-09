using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public enum SkillType
{
    Attack,
    Defense,
    Support
}
public class IntermediateSkillSystem : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot 
    {
        public InputActionReference inputAction;
        public Skill skill;
    }
   
    public List<SkillSlot> skills = new List<SkillSlot>();
    private GameObject player;
    private Skill currentSkill;


    /// <summary>
    /// Inicializa el sistema de habilidades y asigna las acciones de entrada a las habilidades correspondientes.
    /// </summary>
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        foreach (var slot in skills) 
        {
            if (slot.inputAction != null && slot.skill != null) 
            {
                var currentSlot = slot; // Capture the current slot in a local variable
                currentSlot.inputAction.action.performed += _ => TryUseSkill(slot.skill);
                currentSlot.inputAction.action.Enable();
            }
        }
    }

    private void Update()
    {
        foreach (var slot in skills)
        {
            slot.skill.Update(); // Update each skill          
        }
    }

    private void TryUseSkill(Skill skill) 
    {
        if (currentSkill != null) return; // Check if the skill is null

        if (skill.isReady) 
        {
            currentSkill = skill; // Set the current skill to the one being used
            currentSkill.Execute(player); // Execute the skill
            currentSkill.OnCompleted += ResetCurrentSkill; // Subscribe to the OnCompleted event
            
            
        }
    }

    private void ResetCurrentSkill() 
    {
        currentSkill.OnCompleted -= ResetCurrentSkill; // Unsubscribe from the event
        currentSkill = null; // Reset the current skill
    }

    private void OnDestroy()
    {
        foreach (var slot in skills)
        {
            slot.inputAction.action.Dispose();
        }
    }
}
