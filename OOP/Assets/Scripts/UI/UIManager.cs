using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction sprint;


    [SerializeField] private Player player;
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
        manaBar.fillAmount = player.GetManaPercentage();
        Debug.Log($"[manaDebugger] mana fill amount : {player.GetManaPercentage()}");
    }

    private void OnEnable()
    {
        player.OnSpendMana += UpdateManaView;
    }

    private void OnDisable()
    {
       player.OnSpendMana -= UpdateManaView;
    }

    void UpdateManaView(float amount) 
    {
        Debug.Log($"[manaDebugger] UpdateManaView : {amount}");
        manaBar.fillAmount = player.GetManaPercentage();
    }
    
    //falta update life view
    
    //falta update skills view
}
