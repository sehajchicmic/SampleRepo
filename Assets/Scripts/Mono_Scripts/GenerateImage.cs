using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public GameObject BackgroundImage;
    public GameObject content;
    int count = 0;




    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        AddImage();
    }


    void AddImage()
    {
        if(count<10)
        {
            GameObject clone = Instantiate(BackgroundImage, new Vector3(0, 0, 0), Quaternion.identity,transform) as GameObject;
            var rect = clone.GetComponent<RectTransform>();
            rect.pivot = new Vector2(0.5f, 0.5f);

            clone.transform.parent = transform;
            //rect.localScale = new Vector3(1, 1, 1);
            count++;

        }
        //if(BackgroundImage != null)
        //{
        //    BackgroundImage.transform.parent = content.transform;
        //}
    }




}
