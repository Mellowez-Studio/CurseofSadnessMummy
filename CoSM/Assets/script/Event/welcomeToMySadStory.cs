using UnityEngine;
using System.Collections;
public class welcomeToMySadStory : MonoBehaviour
{
    public string toSence;
    GameObject canvas;
    GameObject backgoundLoad;

    public void loadAys()
    {
        print("toSence");
        canvas = GameObject.FindObjectOfType<Canvas>().gameObject;
        backgoundLoad = canvas.transform.GetChild(0).gameObject;
    /*    backgoundLoad = Instantiate(Resources.Load("ProjectAssets/Prefab/FateLoad") as GameObject);
        backgoundLoad.transform.SetParent(canvas.transform);*/
        StartCoroutine(startLoadS());
    }

    IEnumerator startLoadS()
    {
        Color newTrp = backgoundLoad.GetComponent<UnityEngine.UI.Image>().color;
        while (newTrp.a < 255)
        {
            Debug.Log(backgoundLoad.GetComponent<UnityEngine.UI.Image>().color);
            newTrp.a++;
            backgoundLoad.GetComponent<UnityEngine.UI.Image>().color = newTrp;
            yield return new WaitForSeconds(0.2f);
        }
    } 
}
