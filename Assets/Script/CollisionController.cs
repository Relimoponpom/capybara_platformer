using UnityEngine;

public class CollisionAnimationTrigger : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // OnCollisionEnter is called when this GameObject collides with another GameObject
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a GameObject tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the "death" animation
            animator.Play("death");
        }
    }
}
