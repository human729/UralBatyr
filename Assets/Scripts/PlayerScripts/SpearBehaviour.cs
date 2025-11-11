using UnityEngine;

public class SpearBehaviour : MonoBehaviour
{
    public LayerMask enemyLayer;
    private void OnTriggerEnter(Collider other)
    {
        if ((enemyLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            other.gameObject.GetComponent<MeleeEnemy>().GetDamage(false);
        }

    }
}
