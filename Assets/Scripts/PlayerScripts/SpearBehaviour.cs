using UnityEngine;

public class SpearBehaviour : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void EndSpear()
    {
        animator.SetBool("canSpear", false);
        gameObject.SetActive(false);
    }
}
