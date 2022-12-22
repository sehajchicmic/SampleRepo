using UnityEngine;

public class gamePanelLoader : MonoBehaviour
{
    public GameObject gameScreenPanel;
    public GameObject homeScreenPanel;
    public GameObject buttonPanel;

    public void LoadScene()
    {
        homeScreenPanel.SetActive(false);
        gameScreenPanel.SetActive(true);
        buttonPanel.SetActive(false);
    }
}
