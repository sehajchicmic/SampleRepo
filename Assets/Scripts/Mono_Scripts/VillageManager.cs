using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VillageManager : MonoBehaviour
{
    public Image VillagePrefab;
    public Transform content;
    public GameObject contentView;
    public Sprite lockedVillageImage;
    public Sprite unlockedVillageImage;


    public List<Village> villages;


    public void Awake()
    {   
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
        LoadImageMap();
    }

    private void Init()
    {
        villages = new List<Village>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadImageMap()
    {
        foreach (Village v in villages)
        {
            Image village = Instantiate(VillagePrefab, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
            village.sprite = lockedVillageImage;

            if (!v.isLocked)
            {
                village.sprite = unlockedVillageImage;
            }

        }
    }
}
