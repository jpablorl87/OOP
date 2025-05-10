using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IntermediateSkillSystem : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot
    {
        public InputActionReference inputAction;
        public Skill skill;
        public Image uiIcon;
    }

    [SerializeField] private List<SkillSlot> skills = new List<SkillSlot>();

    private Player player;
    private Skill currentSkill;

    private void Start()
    {
        InitializePlayer();
        SetupSkillInputs();
    }

    private void InitializePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void SetupSkillInputs()
    {
        foreach (var slot in skills)
        {
            if (slot.inputAction != null && slot.skill != null)
            {
                slot.inputAction.action.performed += _ => TryUseSkill(slot);// asigna el evento de la habilidad al input
                slot.inputAction.action.Enable();
            }
        }
    }

    private void TryUseSkill(SkillSlot slot)
    {
        if (currentSkill != null || !slot.skill.isReady) return;

        if (slot.skill.cost <= player.manaSystem.CurrentMana)
        {
            currentSkill = slot.skill;
            player.UpdateStatisticMana(slot.skill.cost);
            slot.skill.Execute(player.gameObject, player);// ejecuta la habilidad
            player.NotifySkillUsed(slot.skill.coolDown, slot.uiIcon);
            currentSkill.OnCompleted += ResetCurrentSkill;// asigna el evento de cooldown
        }
    }

    /// Resetea la habilidad actual cuando termina el cooldown
    private void ResetCurrentSkill()
    {
        currentSkill.OnCompleted -= ResetCurrentSkill;
        currentSkill = null;
    }

    private void Update()
    {
        foreach (var slot in skills)
        {
            slot.skill.Update();
        }
    }

    private void OnDestroy()
    {
        foreach (var slot in skills)
        {
            slot.inputAction?.action.Dispose();
        }
    }
}