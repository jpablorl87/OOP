using UnityEngine;
[CreateAssetMenu(fileName = "New Swordsazo", menuName = "Skills/Swordsazo")]
public class Swordsazo : Skill
{
    [SerializeField] private float swordDamage;
    [SerializeField] private float swordRange;
    [SerializeField] private LayerMask dummy;
    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;//Verify if it's ready to use the skill
        
        StartCooldown();
        if (player != null)
        {
            RaycastHit hit;//Create a raycast forward
            Vector3 source = player.transform.position + Vector3.up * 0.5f;
            Vector3 attackDirection = player.transform.forward;
            if (Physics.Raycast(source, attackDirection, out hit, swordRange, dummy))
            {
                Dummy1 dummyHealth = hit.collider.GetComponent<Dummy1>();
                if (dummyHealth != null)
                {
                    dummyHealth.TakeDamage(swordDamage);
                }
            }
            
            //currentCooldown = coolDown;
        }
    }
}
