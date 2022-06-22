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

    public void updateTotalGems(int x)
    {
        totalGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;
    }

    public void updateCurrentGems(int x)
    {
        currentGems += x;
        gemsText.text = "Gems: " + currentGems + "/" + totalGems;
    }
}
