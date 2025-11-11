using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject ArrowPrefab;
    public GameObject Spear;
    public Transform ShootPoint;

    public float ArrowSpeed;
    public float ChargeTime = 1f;

    private float timer = 0;
    private bool canFire = false;
    private bool StopCharge = false;
    private Animator animator;

    private void Start()
    {
        timer = ChargeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        BowBehavior();
        SpearStart();
    }

    private void Fire()
    {
        var arrow = (GameObject)Instantiate(ArrowPrefab,ShootPoint.position,ShootPoint.rotation);

        arrow.GetComponent<Rigidbody>().linearVelocity = arrow.transform.forward * ArrowSpeed;

        Destroy(arrow, 1);
    }

    void BowBehavior()
    {
        if (Input.GetMouseButton(0) && !canFire)
        {
                print(timer); 
                if (timer <= 0 && !StopCharge)
                {
                    print("Fire"); 
                    canFire = true;
                    StopCharge = true;
                } else
                {
                    timer -= Time.deltaTime;
                }
        }

        if (Input.GetMouseButtonUp(0))
        {
            timer = ChargeTime;
            if (canFire)
            {
                canFire = false;
                Fire();
                StopCharge = false;
            }
        }
    }

    void SpearStart()
    {
        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(0) && animator.GetBool("canSpear") != true)
        {
            Spear.SetActive(true);
            animator.SetBool("canSpear", true);
        }
    }

    void EndSpear()
    {
        animator.SetBool("canSpear", false);
        Spear.SetActive(false);
    }

}
