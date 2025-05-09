using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction sprint;

    [SerializeField] private Image skill;
    [SerializeField] private float coolDown;
    [SerializeField] private float skillValue;
    [SerializeField] private float cost;

    [SerializeField] private Image lifeBar;
    [SerializeField] private Image manaBar;

    [SerializeField] private float maxLife;
    [SerializeField] private float lifeValue;
    [SerializeField] private float currentLife;
    [SerializeField] private float maxMana;
    [SerializeField] private float manaValue;
    [SerializeField] private float currentMana;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        sprint = playerInput.actions.FindAction("Sprint");

        lifeValue = maxLife;
        manaValue = maxMana;
        skillValue = coolDown;
    }
    void Update()
    {
        skillValue = Mathf.Clamp(skillValue, 0, coolDown);
        if (sprint.WasPressedThisFrame() && skillValue == coolDown)
        {
            manaValue -= cost;
            manaBar.fillAmount = manaValue / maxMana;
            skillValue = 0;
            skill.fillAmount = skillValue / coolDown;
        }
        if (skillValue < coolDown)
        {
            skill.fillAmount = Mathf.MoveTowards(skill.fillAmount, coolDown, Time.deltaTime);
            skillValue += Time.deltaTime;
        }
    }
}
