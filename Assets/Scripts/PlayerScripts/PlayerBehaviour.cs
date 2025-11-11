using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Health = 100f;
    public float MaxHealth = 100f;
    public float BowDamage = 10f;
    public float SpearDamage =  20f;
    [SerializeField] GameObject panel;
    private void Update()
    {
        CheckHp();
    }

    public void CheckHp()
    {
        if (Health <= 0) {
            Dead();
        }
    }

    public void Dead()
    {

        GameObject.Find("Player").SetActive(false);
        panel.SetActive(true);

    }

    public void GetDamage(float damage)
    {
        Health -= damage;
    }
}
