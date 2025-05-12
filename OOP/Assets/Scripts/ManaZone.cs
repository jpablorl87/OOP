using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ManaZone : MonoBehaviour
{
    public float manaAmount = 1f;
    public float manaInterval = 1f;
    public ManaState rechargeType = ManaState.time;

    private float manaTimer;
    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = other.GetComponent<Player>();
            manaTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            manaTimer += Time.deltaTime;

            if (rechargeType == ManaState.time || manaTimer >= manaInterval)
            {
                player._manaSystem.Recharge(rechargeType, manaAmount);
                player.OnSpendMana?.Invoke(player._manaSystem.CurrentValue);

                if (rechargeType == ManaState.instant)
                    manaTimer = 0f; 
                
                Debug.Log("Maná actual del jugador: " + player._manaSystem.CurrentValue);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            player = null;
            Debug.Log("Jugador salio de la zona de mana");
        }
    }
}
