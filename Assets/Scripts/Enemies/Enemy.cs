using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected SpriteRenderer enemySpriteRenderer;
    [SerializeField] protected Rigidbody2D enemyRigidbody;
    [SerializeField] protected GameObject playerObject;
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected float speedMultiplier;

    protected Vector3 startingPosition;
    protected bool isOnStartingPosition = true;
    protected bool isChasing;

    void Start()
    {
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            MoveThowardDestination(playerObject.transform.position);

        }
        else if (transform.position != startingPosition && !isOnStartingPosition)
        {
            MoveThowardDestination(startingPosition);

            if ((startingPosition - transform.position).magnitude < 0.1)
            {
                isOnStartingPosition = true;
                enemyAnimator.SetBool("isMoving", false);
                enemySpriteRenderer.flipX = false;
            }
        }
    }

    public void MoveThowardDestination(Vector3 destinationPosition)
    {
        Vector3 forceVector = destinationPosition - transform.position;
        enemyRigidbody.AddForce(forceVector.normalized * speedMultiplier, ForceMode2D.Impulse);
        enemySpriteRenderer.flipX = forceVector.x > 0 ? true : false;
    }

    public void StartChase()
    {
        isChasing = true;
        isOnStartingPosition = false;
        enemyAnimator.SetBool("isMoving", true);
        StartChaseBehaviour();
    }

    public virtual void StartChaseBehaviour() { }

    public void EndChase()
    {
        isChasing = false;
        EndChaseBehaviour();
    }

    public virtual void EndChaseBehaviour() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerObject.GetComponent<PlayerController>().Death();
        }
    }



}
