using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Animator gemAnimator;
    [SerializeField] private AudioSource collectedAudio;
    private GameManager gameManager;
    private bool gemCollected;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.updateTotalGems(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gemCollected)
        {
            gemCollected = true;
            gemAnimator.SetTrigger("Collected");
            collectedAudio.Play();
            gameManager.updateCurrentGems(1);
        }
    }

    private void DestroyGem()
    {
        Destroy(gameObject);
    }
}
