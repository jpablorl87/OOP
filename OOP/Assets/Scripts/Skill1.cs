using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Skill1 : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private PlayerInput playerInput;
    private InputAction skillAction1;
    private IntermediateSkillSystem intermediateSkillSystem;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        skillAction1 = playerInput.actions.FindAction("Skill1");
    }
    public void DeploySkill(Image icon, float coolDown, SkillType skillType)
    {
        if (skillAction1.WasPressedThisFrame())
        {
            if (intermediateSkillSystem.CanUse() == true)
            {
                icon.fillAmount = 0;
                //intermediateSkillSystem.CurrentValue. = 
            }
        }
    }
}
