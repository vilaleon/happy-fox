using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            playerGameObject.transform.position.x,
            playerGameObject.transform.position.y,
            -1f);
    }
}
