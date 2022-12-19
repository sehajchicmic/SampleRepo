using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class CardController : MonoBehaviour
{
    public List<GameObject> cards;
    public Vector2[] range;
    //private List<int>[] rangeNumbers =new List<int>[20];
    ArrayList rangeNumbers = new ArrayList();
    //private int addPosition = 0;

    public void Start()
    {
        foreach(Vector2 i in range)
        {
            List<int> temp = new List<int>();
            for (int j = (int)i.x; j <= i.y; j++)
            {
                temp.Add(j);
            }
            rangeNumbers.Add(temp);
            //addPosition++;
        }

        List<int> temp1 = (List<int>)rangeNumbers[0];
        for (int i = 0; i < 5; i++)
        {
            int temp = Random.Range(0, temp1.Count);
            cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp1[temp].ToString();
            temp1.Remove(temp1[temp]);
        }
        List<int> temp2 = (List<int>)rangeNumbers[1];
        for (int i = 5; i < 10; i++)
        {
            int temp = Random.Range(0, temp2.Count);
            cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp2[temp].ToString();
            temp2.Remove(temp2[temp]);
        }
        List<int> temp3 = (List<int>)rangeNumbers[2];
        for (int i = 10; i < 15; i++)
        {
            int temp = Random.Range(0, temp3.Count);
            cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp3[temp].ToString();
            temp3.Remove(temp3[temp]);
        }
        List<int> temp4 = (List<int>)rangeNumbers[3];
        for (int i = 15; i < 20; i++)
        {
            int temp = Random.Range(0, temp4.Count);
            cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp4[temp].ToString();
            temp4.Remove(temp4[temp]);
        }
        List<int> temp5 = (List<int>)rangeNumbers[4];
        for (int i = 20; i < 25; i++)
        {
            int temp = Random.Range(0, temp5.Count);
            cards[i].GetComponentInChildren<TextMeshProUGUI>().text = temp5[temp].ToString();
            temp5.Remove(temp5[temp]);
        }
    }
    public void OnClick(GameObject gameObject)
    {
        int index = cards.IndexOf(gameObject);
        Debug.Log(index);
    }
}
