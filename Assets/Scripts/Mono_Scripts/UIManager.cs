using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI xPText;

    public void SetCoins(int temp)
    {
        coinText.text = $"{temp}";
    }
    public void SetPowers(int temp)
    {
        powerText.text = $"{temp}";
    }
    public void SetEnergy(int temp)
    {
        energyText.text = $"{temp}/20";
    }
    public void SetStars(int temp)
    {
        starText.text = $"{temp}";
    }
    public void SetXP(int temp)
    {
        xPText.text = $"{temp}";
    }
}
