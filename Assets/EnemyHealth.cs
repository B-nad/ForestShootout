using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform player;

    public int damage = 10;
    private int _currentHealth;
    private Animator _animator;
    private NavMeshAgent agent;

    public int CurrentHealth 
    { 
        get => _currentHealth;
        set
        {
            healthBar.value = value;
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                if (healthBar)
                    Destroy(healthBar.gameObject);
                EnemyDied();
            }
        }
    }

    private void EnemyDied()
    {
        agent.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        _animator.SetBool("isDead", true);
        Victory.Instance.KilledEnemy(gameObject);
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        CurrentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            other.GetComponent<SphereCollider>().enabled = false;
            CurrentHealth -= damage;
            if (player && agent && agent.enabled)
                agent.SetDestination(player.position);
        }
    }
}
