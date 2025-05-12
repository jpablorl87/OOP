using UnityEngine;

public class Dummy1 : Player
{
    public float maxLyfe;
    private float lyfe;
    public override void ApplySkillCost(int cost)
    {
        throw new System.NotImplementedException();
    }
    private void Start()
    {
        lyfe = maxLyfe;
    }
    public void TakeDamage(float damage)
    {
        lyfe -= damage;
        Debug.Log(lyfe);
        if (lyfe <= 0)
        {
            DummyDead();
        }
    }
    public void DummyDead()
    {
        Destroy(gameObject);
    }
}
