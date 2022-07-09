using UnityEngine;

public class Eagle : Enemy
{
    [SerializeField] private AudioSource battleCryAudio;

    public override void StartChaseBehaviour()
    {
        battleCryAudio.Play();
        playerObject.GetComponent<PlayerController>().Scared();
        gameManager.ChaseStarting();
    }

    public override void EndChaseBehaviour()
    {
        gameManager.ChaseEnding();
    }

}
