using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Targetplayer : MonoBehaviour
{
    public int health = 50;
    public healthbar healthbar;
    public GameObject rigobj;
    private RigBuilder rigBuilder;
    private newmove newmove;
    Animator animator;
    public static Targetplayer singleton;
    private void Awake() 
    {
        singleton = this;
    }
    void Start() 
    {
        rigobj.SetActive(false);
        rigBuilder = GetComponentInChildren<RigBuilder>();
        animator = GetComponentInChildren<Animator>();
        newmove = GetComponentInChildren<newmove>();
        healthbar.SetMaxHealth(health);
        rigobj.SetActive(true);
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
        rigobj.SetActive(false);
        rigBuilder.enabled = false;
        newmove.enabled = false;
        animator.Play("deth");
        Destroy(gameObject, 4f);
    }

}
