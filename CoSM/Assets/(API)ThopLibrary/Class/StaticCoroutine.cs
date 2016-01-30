using UnityEngine;
using System.Collections;

public class StaticCoroutine : MonoBehaviour {

    static GameObject backgoundLoad;
    static GameObject canvas;
    static public StaticCoroutine instance;
    void Awake()
    { 
        instance = this; 
    }
    IEnumerator PerformCoroutine()
    { 
        while (true)
        {
            yield return 0;
        }
    }
    /*
    public static void loadSyncS(string toSences)
    {
        if (backgoundLoad == null)
        {
            canvas = GameObject.Find("popUpCavas");
            backgoundLoad = canvas.transform.Find("FateLoad_2").gameObject;
            instance.StartCoroutine(startLoadS(toSences));
        }
    }
    static IEnumerator startLoadS(string toSences)
    {
        backgoundLoad.SetActive(true);
        backgoundLoad.GetComponent<Animator>().Play("FateLoad_2");
        yield return new WaitForSeconds(1f);
        backgoundLoad.GetComponent<Animator>().Stop();
        thopframwork.ThopFW.LoadLevelAsync.ToLevel(backgoundLoad, toSences, true);
        thopframwork.ThopFW.LoadLevelAsync.StartLoadLevelAsync(() => { backgoundLoad.SetActive(false); });
    }

    static IEnumerator EndLoadS()
    {
        backgoundLoad.GetComponent<Animator>().Play("FateOutLoad");
        yield return new WaitForSeconds(1f);
        backgoundLoad.GetComponent<Animator>().Stop();
    }
    */
}
