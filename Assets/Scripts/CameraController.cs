using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;

    void LateUpdate()
    {
        transform.position = new Vector3(
            playerGameObject.transform.position.x,
            playerGameObject.transform.position.y,
            -1f);
    }
}
