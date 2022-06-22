using UnityEngine;

public class SenseController : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {
            enemyController.StartChase();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyController.EndChase();
        }
    }
}
