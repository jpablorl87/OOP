using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float damageDuration;
    private LayerMask enemy;
    private List<Dummy1> damagedEnemies;
    public void Initialize(float amount, float time)
    {
        damage = amount;
        damageDuration = time;
        StartCoroutine(DamageArea());
    }
    public IEnumerator DamageArea()
    {
        float timeArea = 0;
        while (timeArea < damageDuration)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 2f, enemy);

            foreach (var hit in hits)
            {
                Dummy1 health = hit.GetComponent<Dummy1>();
                if (health != null && !damagedEnemies.Contains(health))
                {
                    health.TakeDamage(damage);
                    damagedEnemies.Add(health);
                }
            }

            timeArea += 1f;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
