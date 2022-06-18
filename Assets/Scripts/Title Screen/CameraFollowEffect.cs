using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowEffect : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float transformMultiplier;

    private Vector3 startingPosition;
    public Vector3 mousePositon;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        mousePositon = camera.ScreenToViewportPoint(Input.mousePosition) + new Vector3(-0.5f,-0.5f);
        mousePositon.x = mousePositon.x > 0.5f ? 0.5f : mousePositon.x;
        mousePositon.x = mousePositon.x < -0.5f ? -0.5f : mousePositon.x;
        mousePositon.y = mousePositon.y > 0.5f ? 0.5f : mousePositon.y;
        mousePositon.y = mousePositon.y < -0.5f ? -0.5f : mousePositon.y;
        transform.position = startingPosition + mousePositon * transformMultiplier;
    }
}
