using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HealingZone : MonoBehaviour
{
    public float healAmount = 1f;
    public float healInterval = 1f;

    private float healTimer;
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = other.GetComponent<Player>();
            healTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                player._lifeSystem.Heal(healAmount);
                player.OnSpendLife?.Invoke(player._lifeSystem.CurrentValue);
                healTimer = 0f;
                 Debug.Log("Curando al jugador"); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = null;
             Debug.Log("Jugador salio de la zona de curacion");
        }
    }

}
