using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
