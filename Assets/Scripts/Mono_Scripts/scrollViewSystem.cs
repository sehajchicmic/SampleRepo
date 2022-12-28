using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scrollViewSystem : MonoBehaviour
{
    public GameObject scrollbar;
    bool temp1 = false;
    bool temp2 = false;
    bool temp3 = false;
    bool temp4 = false;
    public int card2 = 0;

    private void Start()
    {
        scrollbar.GetComponent<Scrollbar>().value = 0.0018f;
    }
    private void Update () {
        if(temp1) {
            scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.0018f, 0.15f );
        }
        if ( temp2 ) {
            if ( card2 == 2 ) {
                scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.6665f, 0.30f );
            } else if ( card2 == 3 ) {
                scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.445f, 0.20f );
            } else {
                scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.334f, 0.15f );
            }
        }
        if ( temp3 ) {
            if ( card2 == 3 ) {
                scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.886f, 0.20f );
            } else {
                scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.6665f, 0.15f );
            }
        }
        if ( temp4 ) {
            scrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp ( scrollbar.GetComponent<Scrollbar> ().value, 0.9985f, 0.15f );
        }
    }
    public void onClickfirstButton () {
        temp1 = true;
        temp2 = false;
        temp3 = false;
        temp4 = false;
    }
    public void onClickSecondButton () {
        temp1 = false;
        temp2 = true;
        temp3 = false;
        temp4 = false;
    }
    public void onClickThirdButton () {
        temp1 = false;
        temp2 = false;
        temp3 = true;
        temp4 = false;
    }
    public void onClickFourthButton () {
        temp1 = false;
        temp2 = false;
        temp3 = false;
        temp4 = true;
    }
}