using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Health = 100f;
    public float BowDamage = 10f;
    public float SpearDamage = 10f;

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
        Destroy(GameObject.Find("Player"));
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
    }
}
