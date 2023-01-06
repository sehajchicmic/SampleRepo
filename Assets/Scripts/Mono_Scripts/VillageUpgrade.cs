using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class VillageUpgrade : MonoBehaviour
{
    public VillageManager villageManager;
    public List<Image> currentItems;
    public Sprite DemoSprite;
    // Start is called before the first frame update
    void Start()
    {
        //LoadVillage();
        villageManager.currentVillage = villageManager.data_SO.villageList[villageManager.currentVillagenumber];
        villageManager.villageImage.sprite = villageManager.currentVillage.villageBackgroundSprite;
        currentItems = new List<Image>();
        //Debug.Log($"{villageManager.currentVillage.items.Length}");
        for (int i = 0; i<villageManager.currentVillage.items.Length; i++)
        {
            //Debug.Log("0");
            InstatiateItem(i);
        }
    }

    public void InstatiateItem(int index)
    {
        //Debug.Log($"1 {currentItems.Count}");
        

        if(villageManager.currentDestroyLevel[index] == 0)
        {
            //Debug.Log("2");
            SpawnUpgradedImage(index);
        }
        else
        {
            //Debug.Log("2");
            SpawnDamagedImage(index);
        }
    }

    public void SpawnUpgradedImage(int index)
    {
        //Debug.Log("3");
        Image item = Instantiate(villageManager.itemImage, villageManager.villageImage.transform);
        item.transform.localPosition = villageManager.currentVillage.items[index].spawnPoint;
        item.sprite = villageManager.currentVillage.items[index].upgradeLevel[villageManager.itemsUpgradeLevel[index]].upgradeItem;
        if (currentItems.Count + 1 > villageManager.currentVillage.items.Length)
        {
            Destroy(currentItems[index].gameObject);
            currentItems[index] = item;
        }
        else
        {
            currentItems.Add(item);
        }
        item.transform.DOScale(new Vector3(2, 2, 2), 0f);
        item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        item.gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { villageManager.Attack(index); });
    }

    public void SpawnDamagedImage(int index)
    {
        //Debug.Log("3");
        Image item = Instantiate(villageManager.itemImage, villageManager.villageImage.transform);
        item.transform.localPosition = villageManager.currentVillage.items[index].spawnPoint;
        item.sprite = villageManager.currentVillage.items[index].upgradeLevel[villageManager.itemsUpgradeLevel[index]].destroyLevel[villageManager.currentDestroyLevel[index]].destroyItem;
        if (currentItems.Count  +1 > villageManager.currentVillage.items.Length)
        {
            Destroy(currentItems[index].gameObject);
            currentItems[index] = item;
        }
        else
        {
            currentItems.Add(item);
        }
        item.transform.DOScale(new Vector3(2, 2, 2), 0f);
        item.transform.DOScale(new Vector3(1, 1, 1), 1f);
        item.GetComponentInChildren<Button>().onClick.AddListener(delegate { villageManager.Attack(index); });
    }
}
