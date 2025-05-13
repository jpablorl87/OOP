using UnityEngine;

public class Dummy1 : Player
{
    public float maxLyfe;
    private float lyfe;
    private DummySpawner spawner;
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
    internal void Prepare(DummySpawner _spawner)
    {
        spawner = _spawner;
    }
    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.Destroyed();
        }
    }
}
