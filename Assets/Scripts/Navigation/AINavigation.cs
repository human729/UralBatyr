using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
       // agent.SetDestination(target.position);
    }
}
