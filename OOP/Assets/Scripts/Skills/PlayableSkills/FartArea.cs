using UnityEngine;

[CreateAssetMenu(fileName = "New Fart", menuName = "Skills/FartArea")]
public class FartArea : Skill
{
    [Header("Settings")]
    public GameObject fartZone;           
    public float fartDuration = 2f;       
    public float fartRadius   = 3f;       
    public LayerMask enemyMask; 
    [SerializeField] private float spawnDistance = 6;
    [SerializeField] private float spawnHeight = 2;

    [Header("Damage Settings")]
    public float fartDamage = 10f;        

    [Header("Feedback")]
    public ParticleSystem extraVFX;       

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
            Instantiate(extraVFX, spawnPoint, Quaternion.identity).Play();
        
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
