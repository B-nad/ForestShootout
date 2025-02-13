using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthBar;

    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            healthBar.value = value;
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                EnemyDied();
            }
        }
    }

    private void EnemyDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (transform.position.y <= -10)
        {
            CurrentHealth = 0;
        }
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CurrentHealth = maxHealth;
    }
}
