using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private Animator gemAnimator;
    [SerializeField] private AudioSource collectedAudio;

    private GameManager gameManager;
    private bool gemCollected;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateTotalGems(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gemCollected)
        {
            gemCollected = true;
            gemAnimator.SetTrigger("collectedTrigger");
            collectedAudio.Play();
            gameManager.UpdateCurrentGems(1);
        }
    }

    private void DestroyGem()
    {
        Destroy(gameObject);
    }
}
