using UnityEngine;

public class SpearBehaviour : MonoBehaviour
{
    public LayerMask enemyLayer;
    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        if ((enemyLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            print("hit inside");
            other.gameObject.GetComponent<MeleeEnemy>().GetDamage(false);
        }

    }
}
