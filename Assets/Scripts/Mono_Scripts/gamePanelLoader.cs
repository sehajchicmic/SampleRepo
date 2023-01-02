using UnityEngine;
using UnityEngine.UI;

public class gamePanelLoader : MonoBehaviour
{
    public GameObject gameScreenPanel;
    public GameObject homeScreenPanel;
    public GameObject buttonPanel;
    public BingoCardsLoader bingoCardsLoader;
    public Toggle cards1;
    public Toggle cards2;
    public Toggle cards3;
    public Toggle cards4;

    public void LoadScene()
    {
        if(cards1.isOn && GameManager.instance.player.playerEnergy>=1)
        {
            bingoCardsLoader.LoadPrefab();
            homeScreenPanel.SetActive(false);
            gameScreenPanel.SetActive(true);
            buttonPanel.SetActive(false);
            GameManager.instance.player.playerEnergy -= 1;
            GameManager.instance.saveLoader.SavePlayerData(GameManager.instance.player);
        }
        else if (cards2.isOn && GameManager.instance.player.playerEnergy >= 2)
        {
            bingoCardsLoader.LoadPrefab();
            homeScreenPanel.SetActive(false);
            gameScreenPanel.SetActive(true);
            buttonPanel.SetActive(false);
            GameManager.instance.player.playerEnergy -= 2;
            GameManager.instance.saveLoader.SavePlayerData(GameManager.instance.player);
        }
        else if (cards3.isOn && GameManager.instance.player.playerEnergy >= 3)
        {
            bingoCardsLoader.LoadPrefab();
            homeScreenPanel.SetActive(false);
            gameScreenPanel.SetActive(true);
            buttonPanel.SetActive(false);
            GameManager.instance.player.playerEnergy -= 3;
            GameManager.instance.saveLoader.SavePlayerData(GameManager.instance.player);
        }
        else if (cards4.isOn && GameManager.instance.player.playerEnergy >= 4)
        {
            bingoCardsLoader.LoadPrefab();
            homeScreenPanel.SetActive(false);
            gameScreenPanel.SetActive(true);
            buttonPanel.SetActive(false);
            GameManager.instance.player.playerEnergy -= 4;
            GameManager.instance.saveLoader.SavePlayerData(GameManager.instance.player);
        }
        else
        {
            Debug.Log("Not enough Keys");
        }
    }
}
