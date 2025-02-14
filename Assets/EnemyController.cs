using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius = 7f;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerHealth playerHealth;

    private Animator animator;
    private NavMeshAgent agent;
    private EnemyHealth health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private float attackDelay = 0f;

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead()) {  return; }

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookRadius)
        {
            lookRadius = 7;
            agent.SetDestination(player.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            LookAtPlayer();
            animator.SetBool("isAttacking", true);
            attackDelay += Time.deltaTime;
            if (attackDelay >= 1f)
            {
                playerHealth.Damage(10);
                attackDelay = 0f;
                AudioManager.PlayFromResources(Sound.Attack,1,Random.Range(0.9f,1.1f));
            }
        }
        else
        {
            attackDelay = 0f;
            float speed = agent.velocity.magnitude;
            animator.SetFloat("isRunning", speed);
            animator.SetBool("isAttacking", false);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }

}
