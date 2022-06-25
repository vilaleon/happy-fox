using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Rigidbody2D enemyRigidbody;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private string animationString;

    [SerializeField] private AudioSource battleCryAudio;

    protected Vector3 startingPosition;
    private bool isOnStartingPosition = true;
    private bool isChasing;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isChasing)
        {
            Vector3 forceVector = playerObject.transform.position - transform.position;
            enemyRigidbody.AddForce(forceVector.normalized * speedMultiplier, ForceMode2D.Impulse);
            enemySpriteRenderer.flipX = forceVector.x > 0 ? true : false;
        }
        else if (transform.position != startingPosition && !isOnStartingPosition)
        {
            Vector3 forceVector = startingPosition - transform.position;
            enemyRigidbody.AddForce(forceVector.normalized * speedMultiplier, ForceMode2D.Impulse);
            enemySpriteRenderer.flipX = forceVector.x > 0  ? true : false;

            if (forceVector.magnitude < 0.1)
            {
                isOnStartingPosition = true;
                enemyAnimator.SetBool(animationString, false);
                enemySpriteRenderer.flipX = false;
            }
        }
    }

    public void StartChase()
    {
        isChasing = true;
        isOnStartingPosition = false;
        playerObject.GetComponent<PlayerController>().Scared();
        if (battleCryAudio) battleCryAudio.Play();
        enemyAnimator.SetBool(animationString, true);
    }

    public void EndChase()
    {
        isChasing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerObject.GetComponent<PlayerController>().StartDying();
        }
    }
}
