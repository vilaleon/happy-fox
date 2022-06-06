using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Animator gemAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gemAnimator.SetTrigger("Collected");
        }
    }

    private void DestroyGem()
    {
        Destroy(gameObject);
    }
}
