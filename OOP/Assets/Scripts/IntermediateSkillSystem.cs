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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        foreach (var slot in skills) 
        {
            if (slot.inputAction != null) 
            {
                slot.inputAction.action.performed += _ => TryUseSkill(slot.skill);
                slot.inputAction.action.Enable();
            }
        }
    }

    private void Update()
    {
        currentSkill?.Update(); // Update the current skill if it's not null
    }


    private void TryUseSkill(Skill skill) 
    {
        if (currentSkill != null) return; // Check if the skill is null

        if (skill.isReady) 
        {
            currentSkill = skill; // Set the current skill to the one being used
            currentSkill.OnCompleted += ResetCurrentSkill; // Subscribe to the OnCompleted event
            currentSkill.Execute(player); // Execute the skill
            
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
