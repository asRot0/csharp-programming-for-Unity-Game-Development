using UnityEngine;
using UnityEngine.AI;

public class Targetenimy : MonoBehaviour
{
    public enum AiType { aienemyexm, enemyAI, enemyaitra, enemymove};
    public AiType aiType = AiType.enemymove;
    private NavMeshAgent agent;
    Animator animator;
    CapsuleCollider capsuleCollider;
    private Aienemyexm aienemyexm;
    private EnemyAI enemyAI;
    private enemyaitra enemyaitra;
    private enemymove enemymove;
    //bool isdeth = false;
    public int maxHealth = 50;
    public float dethTime = 4f;
    //public healthbar healthbar;

    void Start() {
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        //aienemyexm = GetComponentInChildren<Aienemyexm>();
        // aiType = GetComponentInChildren<AiType>();
        //healthbar.SetMaxHealth(maxHealth);
        if (aiType == AiType.aienemyexm)
            aienemyexm = GetComponentInChildren<Aienemyexm>();
        else if (aiType == AiType.enemymove)
            enemymove = GetComponentInChildren<enemymove>();
        else if (aiType == AiType.enemyaitra)
            enemyaitra = GetComponentInChildren<enemyaitra>();
        else
            enemyAI = GetComponentInChildren<EnemyAI>();

    }
    public void TakeDamage(int amount)
    {
        //Debug.Log("hit");
        maxHealth -= amount;
        //healthbar.SetHealth(maxHealth);
        if(maxHealth <= 0)
        {
            
            //isdeth = true;
            Die();
            enemytype();
        }

    }
    void Die()
    {
        capsuleCollider.enabled = false;
        agent.enabled = false;
        animator.Play("deth");
        Destroy(gameObject,dethTime);
    }
    void enemytype()
    {
        if (aiType == AiType.aienemyexm)
            aienemyexm.enabled = false;
        else if (aiType == AiType.enemymove)
            enemymove.enabled = false;
        else if (aiType == AiType.enemyaitra)
            enemyaitra.enabled = false;
        else
            enemyAI.enabled = false;
    }

}
