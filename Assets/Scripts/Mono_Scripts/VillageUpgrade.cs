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
        LoadVillage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Village


    public void LoadVillage()
    {
        villageManager.currentVillage = villageManager.data_SO.villageList[villageManager.currentVillagenumber];
        villageManager.villageImage.sprite = villageManager.currentVillage.villageBackgroundSprite;
        for (int i = 0; i < villageManager.currentVillage.items.Length; i++)
        {
            Image item = Instantiate(villageManager.itemImage, villageManager.villageImage.transform);
            item.transform.localPosition = villageManager.currentVillage.items[i].spawnPoint;
            if(villageManager.currentDestroyLevel[i] == 0)
            {
                item.sprite = villageManager.currentVillage.items[i].upgradeLevel[villageManager.itemsUpgradeLevel[i]].upgradeItem;
            }
            else
            {
                item.sprite = villageManager.currentVillage.items[i].upgradeLevel[villageManager.itemsUpgradeLevel[i]].destroyLevel[villageManager.currentDestroyLevel[i]].destroyItem;
            }
            int index = i;
            currentItems.Add(item);

            item.GetComponentInChildren<Button>().onClick.AddListener(delegate { villageManager.Attack(index); });
        }
        //UpgradeItem();
    }
    public void UpgradeItem(Sprite item, int index)
    {
        //villageManager.itemsUpgradeLevel[index] += 1;
        currentItems[index].transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        StartCoroutine(RegainScale(item, 0.5f, index));


    }

    IEnumerator RegainScale(Sprite item, float time, int index)
    {
        yield return new WaitForSeconds(time);
        currentItems[index].sprite = item;
        currentItems[index].transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        //item = villageManager.currentVillage.items[index].upgradeLevel[villageManager.itemsUpgradeLevel[index]].upgradeItem;
        //item.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
    #endregion Village
}
