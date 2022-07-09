using UnityEngine;

public class CameraFollowEffect : MonoBehaviour
{
    [SerializeField] private new Camera camera;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Vector3 mousePositon = camera.ScreenToViewportPoint(Input.mousePosition) + new Vector3(-0.5f, -0.5f);
        mousePositon.x = mousePositon.x > 0.5f ? 0.5f : mousePositon.x;
        mousePositon.x = mousePositon.x < -0.5f ? -0.5f : mousePositon.x;
        mousePositon.y = mousePositon.y > 0.5f ? 0.5f : mousePositon.y;
        mousePositon.y = mousePositon.y < -0.5f ? -0.5f : mousePositon.y;
        transform.position = startingPosition + mousePositon;
    }
}
