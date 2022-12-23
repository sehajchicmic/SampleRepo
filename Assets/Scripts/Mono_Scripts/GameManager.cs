using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BingoNumberDisplay bingoNumberDisplay;
    public List<CardController> cards;
    public Pattern_SO pattern_SO;
    //public List<IDictionary> Elements;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool MatchChecker(int temp)
    {
        bool temp1 =bingoNumberDisplay.MatchChecker(temp);
        return temp1;
    }
    public  void Roll(TextMeshProUGUI rollsLeft)
    {
        bingoNumberDisplay.Display(rollsLeft);
    }

    public bool[] PatternCheck(bool[] temp, bool[] previous)
    {
        bool[] finalResult = new bool[pattern_SO.BingoPatterns.Length];
        for (int i = 0 ; i < pattern_SO.BingoPatterns.Length ; i++)
        {
            if(!previous[i])
            {
                bool result = true;
                for (int j = 0; j < pattern_SO.BingoPatterns[i].cells.Length; j++)
                {
                    if (pattern_SO.BingoPatterns[i].cells[j] == true)
                    {
                        if (temp[j] == false)
                        {
                            result = false;
                        }
                    }
                }
                finalResult[i] = result;
            }
        }
        return finalResult;
    }

    public void AutoDaubing(int number)
    {
        int temp = 0;
        //bool returnelement=false;
        foreach (CardController card in cards)
        {
            int count = 0;
            if (card.keyValues.ContainsKey(number))
            {
                temp++;
                if (temp == cards.Count)
                {
                    //returnelement = true;
                    Debug.Log(number);
                    DaubNumbers(number);

                }
            }
            else
            {
                count++;
                if (count == card.keyValues.Count)
                {
                    //returnelement = false;
                }
            }
        }
        //return returnelement;
    }
    public void DaubNumbers(int temp)
    {
        foreach (CardController i in cards)
        {
            i.keyValues[temp].GetComponent<Button>().onClick.Invoke();
        }
    }
}
