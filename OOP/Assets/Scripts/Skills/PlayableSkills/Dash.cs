using UnityEngine;

[CreateAssetMenu(fileName = "New Dash", menuName = "Skills/Dash")]

public class Dash : Skill
{
    [SerializeField] private float dashForce = 10f;
    public override void Execute(GameObject player, Player playerClass)
    {
        if (!isReady) return;
        StartCooldown();
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null) 
            {
                
                Debug.Log("[manaDebugger] Execute called");
                Vector3 direction = player.transform.forward;
                rb.AddForce(direction * dashForce, ForceMode.Impulse);

                 
            
            }  
       
            
    }
}
