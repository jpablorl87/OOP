using UnityEngine;
[CreateAssetMenu(fileName = "New Swordsazo", menuName = "Skills/Swordsazo")]
public class Swordsazo : Skill
{
    [SerializeField] private float swordDamage;
    [SerializeField] private float swordRange;
    [SerializeField] private LayerMask dummy;
    [SerializeField] private ParticleSystem vfxSword;
    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;//Verify if it's ready to use the skill
        
        StartCooldown();
        if (player != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, swordRange, dummy);

            foreach (Collider collider in hitColliders)
            {
                if (collider.TryGetComponent(out Dummy1 dummyHealth))
                {
                    dummyHealth.TakeDamage(swordDamage);
                }
            }

            if (vfxSword != null)
            {
                ParticleSystem particle = Instantiate(vfxSword, player.transform.position, Quaternion.identity);
                particle.transform.forward = player.transform.up;

                Destroy(particle, particle.main.duration);
            }
            //currentCooldown = coolDown;
        }
    }
}
