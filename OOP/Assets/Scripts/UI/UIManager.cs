using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private Player player;

    [Header("UI Elements")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image manaBar;

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        lifeBar.fillAmount = player.GetlifePercentage();
        manaBar.fillAmount = player.GetManaPercentage();
    }

    private void OnEnable()
    {
        player.OnSpendMana += UpdateManaView;
        player.OnSpendLife += UpdateLifeView;
        player.OnUseSkill += UpdateSkillView;
    }

    private void OnDisable()
    {
        player.OnSpendMana -= UpdateManaView;
        player.OnSpendLife -= UpdateLifeView;
        player.OnUseSkill -= UpdateSkillView;
    }

    private void UpdateManaView(float amount)
    {
        manaBar.fillAmount = player.GetManaPercentage();
    }

    private void UpdateLifeView(float amount)
    {
        lifeBar.fillAmount = player.GetlifePercentage();
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