using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.SceneTemplate;

public class CardController : MonoBehaviour
{
    //public List<GameObject> cards;
    public List<Button> buttons;
    public Vector2[] range;
    public bool[] patternsMatch;
    ArrayList rangeNumbers = new ArrayList();
    public BingoNumberDisplay bingoNumberDisplay;

    public struct pair
    {
        public int index;
        public int value;
    }

    public void Start()
    {
        Debug.Log("Start");
        //Declaration of bool Array
        patternsMatch = new bool[25];

        //Adding List of ranges
        foreach (Vector2 i in range)
        {
            Debug.Log("List");
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
            Debug.Log("Instantiate");
            int rangeNumbersIndex = i % 5;
            List<int> temp = (List<int>)rangeNumbers[rangeNumbersIndex];
            int randomValue = temp[Random.Range(0, temp.Count)];
            temp.Remove(randomValue);
            rangeNumbers[rangeNumbersIndex] = temp;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomValue.ToString();

            int index = i;
            buttons[i].onClick.AddListener(delegate { OnClicked(buttons[index].gameObject, new pair { index = index, value = randomValue }); });
        }
    }

    public void OnClicked(GameObject index, pair i)
    {
        Debug.Log($" game object is {index is null} and index = {i.index} and value = {i.value}");
        Debug.Log(i.index);
        bool temp = bingoNumberDisplay.MatchChecker(index);
        if (temp)
        {
            Debug.Log("NumberMatched");
            index.GetComponent<Image>().color = Color.green;
            index.GetComponent<Button>().enabled = false;
            patternsMatch[i.index] = true;
        }
    }


    //List<int> temp1 = (List<int>)rangeNumbers[0];
    //for (int i = 0; i < 5; i++)
    //{
    //    int temp = Random.Range(0, temp1.Count);
    //    cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp1[temp].ToString();
    //    temp1.Remove(temp1[temp]);
    //}
    //List<int> temp2 = (List<int>)rangeNumbers[1];
    //for (int i = 5; i < 10; i++)
    //{
    //    int temp = Random.Range(0, temp2.Count);
    //    cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp2[temp].ToString();
    //    temp2.Remove(temp2[temp]);
    //}
    //List<int> temp3 = (List<int>)rangeNumbers[2];
    //for (int i = 10; i < 15; i++)
    //{
    //    int temp = Random.Range(0, temp3.Count);
    //    cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp3[temp].ToString();
    //    temp3.Remove(temp3[temp]);
    //}
    //List<int> temp4 = (List<int>)rangeNumbers[3];
    //for (int i = 15; i < 20; i++)
    //{
    //    int temp = Random.Range(0, temp4.Count);
    //    cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp4[temp].ToString();
    //    temp4.Remove(temp4[temp]);
    //}
    //List<int> temp5 = (List<int>)rangeNumbers[4];
    //for (int i = 20; i < 25; i++)
    //{
    //    int temp = Random.Range(0, temp5.Count);
    //    cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp5[temp].ToString();
    //    temp5.Remove(temp5[temp]);
    //}

    //public void OnClick(GameObject gameObject)
    //{
    //int index = cards.IndexOf(gameObject);
    //Debug.Log(index);
    ////TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    //bool temp = bingoNumberDisplay.MatchChecker(gameObject);
    ////Debug.Log(bingoNumberDisplay.G>);
    //if (temp)
    //{
    //    Debug.Log("NumberMatched");
    //    gameObject.GetComponent<Image>().color = Color.green;
    //    gameObject.GetComponent<Button>().enabled = false;
    //}
    //}
}
