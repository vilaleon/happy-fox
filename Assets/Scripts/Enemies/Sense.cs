using UnityEngine;

public class Sense : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.StartChase();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.EndChase();
        }
    }
}
