using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    public float BowDamage = 10f;
    public float SpearDamage = 20f;
    public GameObject gameOverPanel;

    private void Start()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        CheckHp();
    }

    public void CheckHp()
    {
        if (Health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void Heal(float healAmount)
    {
        Health += healAmount;
        if (Health > MaxHealth) Health = MaxHealth;
    }
}