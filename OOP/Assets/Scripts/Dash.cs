using UnityEngine;

[CreateAssetMenu(fileName = "New Dash", menuName = "Skills/Dash")]

public class Dash : Skill
{
    [SerializeField] private float dashForce = 10f;
    public override void Execute(GameObject player)
    {
        if (!isReady) return;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null) 
        {
            Vector3 direction = player.transform.forward;
            rb.AddForce(direction * dashForce, ForceMode.Impulse);
            RiseOnCompleted();
        }
    }
}
