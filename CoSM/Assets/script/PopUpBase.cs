using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class PopUpBase : MonoBehaviour
{
     static GameObject popImg;
     static GameObject poptext;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        popImg = transform.FindChild("PopUpImg").gameObject;
        poptext = transform.FindChild("PopUpText").gameObject;
        popImg.SetActive(false);
        poptext.SetActive(false);
    }
    public static void PopUpImg(Sprite img, Action OnFinish = null)
    { 
        StaticCoroutine.instance.StartCoroutine(startPopImg(img, OnFinish));
    }
    public static void PopUpText(string textShow, Action OnFinish = null)
    {
        StaticCoroutine.instance.StartCoroutine(startPopText(textShow, OnFinish));
    }
    static IEnumerator startPopImg(Sprite img,Action OnFinish = null)
    {
        popImg.GetComponent<Image>().sprite = img;
        popImg.SetActive(true);
        GameManger.isPlayGame = false;
        popImg.GetComponent<Animator>().Play("Image");
        yield return new WaitForSeconds(1f);
        popImg.GetComponent<Animator>().Stop();
        if (OnFinish != null)
            OnFinish();
        //poptext.SetActive(false);
    }
    static IEnumerator startPopText(string textShow,Action OnFinish=null)
    {
        
        poptext.GetComponent<Text>().text = textShow;
        poptext.SetActive(true);
        poptext.GetComponent<Animator>().Play("PopUpText");      
        yield return new WaitForSeconds(2f);
        poptext.SetActive(false);
        if (OnFinish != null)
            OnFinish();
    }

    public void ExitPopUpImg()
    {
        GameManger.isPlayGame = true;
        popImg.SetActive(false);
    }
}
