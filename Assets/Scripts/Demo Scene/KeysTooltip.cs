using UnityEngine;

public class KeysTooltip : MonoBehaviour
{
    [SerializeField] private Animator tooltipAnimator;

    void Update()
    {
        if (Input.anyKey)
        {
            tooltipAnimator.SetTrigger("fadeOutTrigger");
        }
    }

    private void DestroyTooltip()
    {
        Destroy(gameObject);
    }
}
