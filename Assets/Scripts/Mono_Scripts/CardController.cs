using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    //public List<GameObject> cards;

    public List<Button> buttons;
    public Vector2[] range;
    public bool[] patternsMatch;
    ArrayList rangeNumbers = new ArrayList();
    public IDictionary<int, GameObject> keyValues = new Dictionary<int, GameObject>();
    bool[] pattern;
    int totalnumberofPatternsCanMade = 13;
    //int n = 0;

    public struct pair
    {
        public int index;
        public int value;
    }

    public void Start()
    {
        pattern = new bool[GameManager.instance.pattern_SO.BingoPatterns.Length];
        patternsMatch = new bool[25];

        //Adding List of ranges
        foreach (Vector2 i in range)
        {
            List<int> temp = new List<int>();
            for (int j = (int)i.x; j <= i.y; j++)
            {
                temp.Add(j);
            }
            rangeNumbers.Add(temp);
        }

        //Generating Numbers and assigning Onclicks
        for (int i = 0; i < buttons.Count; i++)
        {
            int rangeNumbersIndex = i % 5;
            List<int> temp = (List<int>)rangeNumbers[rangeNumbersIndex];
            int randomValue = temp[Random.Range(0, temp.Count)];
            temp.Remove(randomValue);
            rangeNumbers[rangeNumbersIndex] = temp;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomValue.ToString();

            int index = i;
            buttons[i].onClick.AddListener(delegate { OnClicked(buttons[index].gameObject, new pair { index = index, value = randomValue }); });

            keyValues.Add(randomValue, buttons[index].gameObject);
        }
    }

    public void OnClicked(GameObject index, pair i)
    {
        //Debug.Log($" game object is {index is null} and index = {i.index} and value = {i.value}");
        Debug.Log(i.index);
        bool temp = GameManager.instance.MatchChecker(i.value);
        if (temp)
        {
            index.GetComponent<Image>().color = Color.green;
            index.GetComponent<Button>().enabled = false;
            patternsMatch[i.index] = true;
            pattern = GameManager.instance.PatternCheck(patternsMatch,pattern);
            int numberOfPatternsMatched = 0;
            for (int j = 0; j < pattern.Length; j++)
            {
                //Debug.Log($"Bingo Pattern Matching with Pattern {j} is {pattern[j]}");
                if(pattern[j])
                {
                    BingoLineClear(j);
                    numberOfPatternsMatched++;
                }
            }
            if(numberOfPatternsMatched >= totalnumberofPatternsCanMade)
            {
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }

    public void BingoLineClear(int Line)
    {
        bool[] temp = GameManager.instance.pattern_SO.BingoPatterns[Line].cells;
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i]==true)
            {
                buttons[i].GetComponent<Image>().color = Color.blue;
            }
        }
    }
}
