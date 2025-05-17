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

    [Header("Configuraci�n de Jugadores")]

    private Player currentPlayer;
    private Skill currentSkill;

    private void Awake()
    {
        currentPlayer = GetComponent<Player>();
    }

    private void Start()
    {
        SetupSkillInputs();
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

        // Verificaci�n de costos espec�fica para cada jugador
        bool canUseSkill = false;

        if (currentPlayer is HealthCostPlayer)
        {
            canUseSkill = slot.skill.cost <= currentPlayer._lifeSystem.CurrentValue;
        }
        else if (currentPlayer is ManaCostPlayer)
        {
            canUseSkill = slot.skill.cost <= currentPlayer._manaSystem.CurrentMana;
        }
        else
        {
            canUseSkill = false;
        }


        if (canUseSkill)
        {
            currentSkill = slot.skill;
            currentPlayer.ApplySkillCost(slot.skill.cost);
            slot.skill.Execute(currentPlayer.gameObject, currentPlayer);
            Debug.Log($"Invocando cooldown en icon: {slot.uiIcon?.name ?? "NULL"}");
            currentPlayer.NotifySkillUsed(slot.skill.CurrentCooldown, slot.uiIcon);
            currentSkill.OnCompleted += ResetCurrentSkill;
        }
    }

    /// Resetea la habilidad actual cuando termina el cooldown
    private void ResetCurrentSkill()
    {
        currentSkill.OnCompleted -= ResetCurrentSkill;
        currentSkill = null;
        Debug.Log("Habilidad lista para usarse de nuevo");
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