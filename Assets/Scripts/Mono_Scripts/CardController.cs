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
    IDictionary<int, GameObject> keyValues = new Dictionary<int, GameObject>();

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

            keyValues.Add(randomValue, buttons[index].gameObject);
        }
        //GameManager.instance.Elements.Add((IDictionary)keyValues);
    }

    public void OnClicked(GameObject index, pair i)
    {
        Debug.Log($" game object is {index is null} and index = {i.index} and value = {i.value}");
        Debug.Log(i.index);
        bool temp = GameManager.instance.MatchChecker(index);
        if (temp)
        {
            index.GetComponent<Image>().color = Color.green;
            index.GetComponent<Button>().enabled = false;
            patternsMatch[i.index] = true;
        }
    }
}
