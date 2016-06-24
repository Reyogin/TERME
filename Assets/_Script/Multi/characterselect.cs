using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterselect : MonoBehaviour
{
    public int sellected;

    public Text text1;
    public Text text2;
    public Text text3;
    //public Transform per;


    // Use this for initialization
    void Start()
    {
        this.sellected = -1;
        text1.text = "";
        text2.text = "";
        text3.text = "";

    }




    // Update is called once per frame

    public void change()
    {
        text2.text = "";
        text1.text = "Selected ✔";
        text3.text = "";
        this.sellected = 0;


    }
    public void change2()
    {
        text1.text = "";
        text2.text = "Selected ✔";
        text3.text = "";
        this.sellected = 1;
    }
    public void change3()
    {
        text2.text = "";
        text3.text = "Selected ✔";
        text1.text = "";
        this.sellected = 2;
    }


}

