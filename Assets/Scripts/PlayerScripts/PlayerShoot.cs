using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject ArrowPrefab;
    public Transform ShootPoint;

    public float ArrowSpeed;
    public float ChargeTime = 1f;

    private float timer = 0;
    private bool canFire = false;
    private bool StopCharge = false;

    private void Start()
    {
        timer = ChargeTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !canFire)
        {
            //print("Holding");
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
        } else
        {
            
            
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

    private void Fire()
    {
        var arrow = (GameObject)Instantiate(ArrowPrefab,ShootPoint.position,ShootPoint.rotation);

        arrow.GetComponent<Rigidbody>().linearVelocity = arrow.transform.forward * 50;

        Destroy(arrow, 1);
    }

}
