using UnityEngine;

public class Player : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public ManaSystem manaSystem;

    private void Awake()
    {
        
        lifeSystem = new LifeSystem(100f, 0f, 50f);
        Debug.Log("LifeSystem inicializado. Vida actual: " + lifeSystem.CurrentValue);
        manaSystem = new ManaSystem(100f, 0f, 30f, 5f);
        Debug.Log("ManaSystem inicializado. Mana actual: " + manaSystem.CurrentValue);

    }
}
//Para el ejemplo de que todo esté funcionando bien jeje
