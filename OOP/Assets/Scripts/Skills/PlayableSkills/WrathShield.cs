using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New WrathShield", menuName = "Skills/WrathShield")]
public class WrathShield : Skill
{
    [SerializeField] private GameObject prefabShield;//Prefab of the shield
    [SerializeField] private float shieldDuration;//Time of duration of the shield
    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;//Verify if it's ready to use the skill
        if (player != null || prefabShield != null)
        {
            player.GetComponent<MonoBehaviour>().StartCoroutine(UseShield(player));//Apply the courutine
        }
    }
    private IEnumerator UseShield(GameObject player)
    {
        Vector3 playerPosition = player.transform.localPosition;//Vector of the position of the player
        GameObject skillInstance = Object.Instantiate(prefabShield, playerPosition, Quaternion.identity);//Instantiate the shield
        yield return new WaitForSeconds(shieldDuration);//Duration of the shield
        Object.Destroy(skillInstance);//Finaly, destroy the shield after the duration
    }
}
