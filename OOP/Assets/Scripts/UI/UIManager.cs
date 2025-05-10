using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{

    [Header("UI Elements")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image manaBar;

    private Player currentPlayer;

    private void Start()
    {
        // Buscar por tag en lugar de por tipo
        GameObject playerObj = GameObject.FindGameObjectWithTag("MainPlayer");

        if (playerObj != null)
        {
            currentPlayer = playerObj.GetComponent<Player>();

            // Verificar tipo concreto
            if (currentPlayer == null)
            {
                Debug.LogError("El jugador no tiene un componente Player válido");
                return;
            }
        }

        InitializeUI();
        SetupEventListeners(); // Nueva función
    }

    private void InitializeUI()
    {
        if (currentPlayer == null) return;
        lifeBar.fillAmount = currentPlayer.GetlifePercentage();
        manaBar.fillAmount = currentPlayer.GetManaPercentage();
    }

    private void SetupEventListeners()
    {
        if (currentPlayer == null) return;

        // Limpiar suscripciones previas
        currentPlayer.OnSpendMana -= UpdateManaView;
        currentPlayer.OnSpendLife -= UpdateLifeView;
        currentPlayer.OnUseSkill -= UpdateSkillView;

        // Suscribir eventos
        currentPlayer.OnSpendMana += UpdateManaView;
        currentPlayer.OnSpendLife += UpdateLifeView;
        currentPlayer.OnUseSkill += UpdateSkillView;
    }

    private void UpdateManaView(float amount)
    {
        manaBar.fillAmount = currentPlayer.GetManaPercentage();
    }

    private void UpdateLifeView(float amount)
    {
        lifeBar.fillAmount = currentPlayer.GetlifePercentage();
    }

    public void UpdateSkillView(float cooldownTime, Image targetIcon)
    {
        if (targetIcon != null && cooldownTime > 0)
        {
            StartCoroutine(SkillCooldownRoutine(targetIcon, cooldownTime));
        }
    }

    private IEnumerator SkillCooldownRoutine(Image icon, float duration)
    {
        icon.fillAmount = 0f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            icon.fillAmount = Mathf.Clamp01(elapsed / duration);//se actualiza el valor de la barra en funcion del tiempo
            elapsed += Time.deltaTime;// se suma el tiempo transcurrido
            yield return null;
        }

        icon.fillAmount = 1f;
    }
}