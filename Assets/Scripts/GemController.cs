using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] private Animator gemAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gemAnimator.SetTrigger("Collected");
    }

    private void DestroyGem()
    {
        Destroy(gameObject);
    }
}
