using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New WrathShield", menuName = "Skills/WrathShield")]
public class WrathShield : Skill
{
    [SerializeField] private GameObject prefabShield;
    [SerializeField] private float shieldDuration;

    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady || prefabShield == null || player == null) 
            return;

        // Iniciar corrutina una sola vez
        playerClass.StartCoroutine(UseShield(player));
        StartCooldown();
        //currentCooldown = coolDown;
    }

    private IEnumerator UseShield(GameObject player)
    {
        // Usar posición global
        Vector3 playerPosition = player.transform.position;
        GameObject skillInstance = Instantiate(prefabShield, playerPosition, Quaternion.identity);
        
        yield return new WaitForSeconds(shieldDuration);
        
        Destroy(skillInstance);
    }
}