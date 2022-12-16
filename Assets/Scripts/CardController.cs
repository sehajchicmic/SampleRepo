using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public List <GameObject> cards;

    public void OnClick(GameObject gameObject)
    {
        int index = cards.IndexOf(gameObject);
        Debug.Log(index);
    }
}
