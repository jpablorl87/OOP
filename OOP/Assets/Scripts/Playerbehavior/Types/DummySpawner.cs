using System.Collections;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{
    [SerializeField] private GameObject dummy;
    [SerializeField] private float delaySpawn;
    private Dummy1 dummy1;
    private void Start()
    {
        InitiateSpawn();
    }
    public void InitiateSpawn()
    {
        GameObject gameObject = Instantiate(dummy, transform.position, Quaternion.identity);
        dummy1 = gameObject.GetComponent<Dummy1>();
        if (dummy1 != null)
        {
            dummy1.Prepare(this);
        }
    }
    public void Destroyed()
    {
        StartCoroutine(Respawn());
    }
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(delaySpawn);
        InitiateSpawn();
    }
}
