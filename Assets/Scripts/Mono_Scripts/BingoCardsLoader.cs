using UnityEngine;
using UnityEngine.UI;

public class BingoCardsLoader : MonoBehaviour
{

    public GameObject CardPrefab1;
    public GameObject spawn;
    public Toggle cards1;
    public Toggle cards2;
    public Toggle cards3;
    public Toggle cards4;
    public GameObject disablebutton78;
    public GameObject disablebutton56;
    public GameObject disablebutton34;
    public scrollViewSystem scv;

    public void LoadPrefab()
    {
        GameManager gameManager = GameManager.instance;
        if (cards1.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card2);
            disablebutton34.SetActive(false);
            disablebutton56.SetActive(false);
            disablebutton78.SetActive(false);
        }
        else if (cards2.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card2);
            GameObject temp1 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card2);
            disablebutton56.SetActive(false);
            disablebutton78.SetActive(false);
            scv.card2 = 1;
        }
        else if(cards3.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card2);
            GameObject temp1 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card2);
            GameObject temp2 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp2.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp2.GetComponent<CardReference>().card2);
            disablebutton78.SetActive(false);
            scv.card2 = 2;
        }
        else if (cards4.isOn)
        {
            GameObject temp = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp.GetComponent<CardReference>().card2);
            GameObject temp1 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp1.GetComponent<CardReference>().card2);
            GameObject temp2 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp2.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp2.GetComponent<CardReference>().card2);
            GameObject temp3 = Instantiate(CardPrefab1, spawn.transform);
            gameManager.cards.Add(temp3.GetComponent<CardReference>().card1);
            gameManager.cards.Add(temp3.GetComponent<CardReference>().card2);
        }
    }
}
