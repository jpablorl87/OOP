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
        if (other.CompareTag("Player"))
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
            Debug.Log("Maná actual del jugador: " + player._manaSystem.CurrentValue);
            {
                player._manaSystem.Recharge(rechargeType, manaAmount);

                if (rechargeType == ManaState.instant)
                    manaTimer = 0f; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            Debug.Log("Jugador salio de la zona de mana");
        }
    }
}
