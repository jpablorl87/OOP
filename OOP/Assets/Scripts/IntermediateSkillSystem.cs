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

    [Header("Configuración de Jugadores")]
    //[SerializeField] private bool testingMode;
    [SerializeField] private Player currentPlayer;

    //private Player player;
    private Skill currentSkill;

    private void Start()
    {
        DetectCurrentPlayer();
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


    /// Detecta el jugador actual en la escena
    private void DetectCurrentPlayer()
    {
        currentPlayer = Object.FindFirstObjectByType<ManaCostPlayer>() ?? (Player)FindFirstObjectByType<HealthCostPlayer>();

        if (currentPlayer == null)
            Debug.LogError("Agrega un jugador a la escena");
    }

    private void TryUseSkill(SkillSlot slot)
    {
        if (currentSkill != null || !slot.skill.isReady) return;

        // Verificación de costos específica para cada jugador
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
            currentPlayer.NotifySkillUsed(slot.skill.coolDown, slot.uiIcon);
            currentSkill.OnCompleted += ResetCurrentSkill;
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