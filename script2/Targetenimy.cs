using UnityEngine;

public class Targetenimy : MonoBehaviour
{
    public int maxHealth = 50;
    //public healthbar healthbar;
    

    void Start() {
        //healthbar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int amount)
    {
        //Debug.Log("hit");
        maxHealth -= amount;
        //healthbar.SetHealth(maxHealth);
        if(maxHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(gameObject);
    }

}
