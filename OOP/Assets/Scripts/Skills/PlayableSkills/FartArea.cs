using UnityEngine;

[CreateAssetMenu(fileName = "New Fart", menuName = "Skills/FartArea")]
public class FartArea : Skill
{
    [Header("Settings")]
    [SerializeField]private GameObject fartZone;           
    [SerializeField]private float fartDuration = 2f;       
    [SerializeField]private float fartRadius   = 3f;       
    [SerializeField]private LayerMask enemyMask; 
    [SerializeField] private float spawnDistance = 6;
    [SerializeField] private float spawnHeight = 2;

    [Header("Damage Settings")]
    [SerializeField]private float fartDamage = 10f;        

    [Header("Feedback")]
    [SerializeField]private ParticleSystem extraVFX;       

    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;
        StartCooldown();

        //Calcula punto de spawn
        Vector3 spawnPoint = player.transform.position + player.transform.forward * spawnDistance + Vector3.up * spawnHeight;

        //Instancia el prefab principal
        if (fartZone != null)
        {
            GameObject zone = Instantiate(fartZone, spawnPoint, Quaternion.identity);
            Destroy(zone, fartDuration);
        }
        else
        {
            Debug.LogError("no has asignado el prefab fartZone");
        }

        if (extraVFX != null)//Inicializa las particulas
        {
            ParticleSystem particle = Instantiate(extraVFX, spawnPoint, Quaternion.identity);
            Destroy(particle, particle.main.duration);
        }
        Collider[] hits = Physics.OverlapSphere(spawnPoint, fartRadius, enemyMask);
        int count = 0;
        foreach (var col in hits)
        {
            if (col.TryGetComponent<Dummy1>(out var dummy))
            {
                dummy.TakeDamage(fartDamage);
                count++;
            }
        }
    }
}
