using UnityEngine;
using System.Collections;
using thopframwork;
public class welcomeToMySadStory : MonoBehaviour
{
    public string toSence;
    GameObject backgoundLoad;
    GameObject canvas;
    public void loadAys()
    {
        print("toSence");
        canvas = GameObject.Find("canvas");
        backgoundLoad = canvas.transform.Find("FateLoad_2").gameObject;
        StartCoroutine(startLoadS());
    }

    IEnumerator startLoadS()
    {
        
        backgoundLoad.GetComponent<Animator>().Play("FateLoad_2");
        yield return new WaitForSeconds(1f);
        backgoundLoad.GetComponent<Animator>().Stop();
        Application.LoadLevel(toSence);
    } 
}
