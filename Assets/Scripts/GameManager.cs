using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalGems = 0;
    private int currentGems = 0;
    [SerializeField] private TextMeshProUGUI gemsText;
    //private int lives = 1;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameMenuUIHandler menuUI;
    [SerializeField] private AudioManager audioMenager;

    public void updateTotalGems(int x)
    {
        totalGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;
    }

    public void updateCurrentGems(int x)
    {
        currentGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;


        if (currentGems == totalGems)
        {
            playerObject.SetActive(false);
            audioMenager.StopAmbient("ambient");
            audioMenager.StopAmbient("battleAudio");
            audioMenager.PlaySound("endSound");
            menuUI.victory();
            menuUI.GetComponent<Animator>().SetTrigger("startFade2");
        }
    }

}
