using System;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{

    public float EnemyHealth = 30;
    public float EnemyDamage = 20;
    public float EnemySpeed = 10;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public virtual void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 10)
        {
            player.GetComponent<PlayerBehaviour>().Health -= EnemyDamage;
        }

    }
    private void Update()
    {
        Console.WriteLine(Vector3.Distance(gameObject.transform.position, player.transform.position));
        Dead();
    }

    public virtual void Dead()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "")
    //}



}
