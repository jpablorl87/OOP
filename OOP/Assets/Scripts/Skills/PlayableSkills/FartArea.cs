using UnityEngine;
[CreateAssetMenu(fileName = "New Fart", menuName = "Skills/FartArea")]
public class FartArea : Skill
{
    public GameObject fartZone;
    public float fartDuration;
    public float fartDamage;
    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;//Verify if it's ready to use the skill
        StartCooldown();
        if (!fartZone) 
        {
            
            Vector3 spawnPoint = player.transform.position + player.transform.position * 2;
            GameObject spawnArea = Object.Instantiate(fartZone, spawnPoint, Quaternion.identity);
            AreaDamage areaCode = spawnArea.GetComponent<AreaDamage>();
            if (areaCode != null)
            {
                areaCode.Initialize(fartDamage, fartDuration);
            }
            
            //currentCooldown = coolDown;
        }
    }
}