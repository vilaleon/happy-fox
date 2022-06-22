using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysTooltipController : MonoBehaviour
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
