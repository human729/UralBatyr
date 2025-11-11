using System;
using System.Collections;
using UnityEngine;
public abstract class EnemyBehaviour : MonoBehaviour
{

    public float EnemyHealth = 30;
    public float EnemyDamage = 20;
    public float EnemySpeed = 10;
    bool isCoolDown = false;
    GameObject player;


    public virtual void Start()
    {
        player = GameObject.Find("Player");
    }

    public virtual void Attack()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 3 && !isCoolDown)
        {
            player.GetComponent<PlayerBehaviour>().GetDamage(EnemyDamage);
            StartCoroutine(CoolDown());
        }

    }
    
    IEnumerator CoolDown()
    {
        isCoolDown = !isCoolDown;
        yield return new WaitForSeconds(2f);
        isCoolDown = !isCoolDown;
        
    }

    public virtual void Update()
    {
        //print(Vector3.Distance(gameObject.transform.position, player.transform.position));
        print(EnemyHealth);
        Attack();
        Dead();
    }
    

    public virtual void Dead()
    {
        if(EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    public virtual void GetDamage(bool isArrow)
    {
        if (isArrow)
        {
            EnemyHealth -= player.GetComponent<PlayerBehaviour>().BowDamage;
        }
        else
        {
            EnemyHealth -= player.GetComponent<PlayerBehaviour>().SpearDamage;
        }
    }


}
