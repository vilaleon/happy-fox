using TMPro;
using UnityEngine;

public class ChatBubbleController : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject background;

    void Start()
    {
        text.renderer.sortingOrder = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
}
