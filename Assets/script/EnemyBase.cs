using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int totalHp = 1;
    
    protected int currentHp;
    EnemySpawner spawner;

    public void Awake()
    {
        currentHp = totalHp;
    }

    protected virtual void Move()
    {


    }


    public virtual void Hit()
    {
        Debug.Log("Nemico colpito");
        currentHp--;
        if (currentHp <= 0) 
        { 
            currentHp = 0;
            Death();

        }

    }

    public void Initialaze(EnemySpawner _spawner)
    {
        spawner = _spawner;
    }
    protected virtual void Death()
    {
        spawner.EnemyDie(this); 
        
        
        Debug.Log("Nemico morto");

        Destroy(gameObject);    
    }
}
