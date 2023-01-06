using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMap : MonoBehaviour
{
    public VillageManager villageManager;
    public Image VillagePrefab;
    public Transform content;
    public GameObject map;

    public void LoadImageMap()
    {
        map.SetActive(true);
        foreach (Village v in villageManager.villages)
        {
            Image village = Instantiate(VillagePrefab, content.transform);
            village.sprite = v.villageMapSprite;
            if (v.isLocked)
            {
                village.color = Color.gray;
            }
        }
    }
    public void CloseMap()
    {
        map.SetActive(false);
    }
}
