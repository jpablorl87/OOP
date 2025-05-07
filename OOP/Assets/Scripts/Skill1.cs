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
    /*public Skill1(string nameSkill, Image icon, float coolDown, SkillType skillType, float cost, float duration) : base(nameSkill, icon, coolDown, skillType, cost, duration)
    {
    }*/
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        skillAction1 = playerInput.actions.FindAction("Skill1");
    }
    public void DeploySkill(Image icon, float coolDown, SkillType skillType)
    {
        
    }

}
