using UnityEngine;

public class Targetplayer : MonoBehaviour
{
    public int health = 50;
    public healthbar healthbar;
    public Transform gameobj;
    public static Targetplayer singleton;
    private void Awake() 
    {
        singleton = this;
    }
    void Start() 
    {
        healthbar.SetMaxHealth(health);
    }

    public void TakeDamage(int amount)
    {
        //Debug.Log("hit");
        health -= amount;
        healthbar.SetHealth(health);
        if(health <= 0f)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
        //Destroy(gameobjfpscam);
        //Destroy(gameobj);
        //Destroy(transform.gameObject);
    }

}
