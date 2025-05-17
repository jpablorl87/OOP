using UnityEngine;
[RequireComponent(typeof(Collider))]
public class DamageZone : MonoBehaviour
{
    private float dmgAmount = -1;
    private float dmgInterval = 1;

    private float dmgTime;
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = other.GetComponent<Player>();
            dmgTime = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            dmgTime += Time.deltaTime;

            if (dmgTime >= dmgInterval)
            {
                player._lifeSystem.Heal(dmgAmount);
                player.OnSpendLife?.Invoke(player._lifeSystem.CurrentValue);
                dmgTime = 0f;
                Debug.Log("Dañando al jugador");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = null;
            Debug.Log("Jugador salio de la zona de daño");
        }
    }
}
