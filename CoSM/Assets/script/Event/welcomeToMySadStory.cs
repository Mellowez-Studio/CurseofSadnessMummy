using UnityEngine;
using System.Collections;
using thopframwork;
public class welcomeToMySadStory : MonoBehaviour
{
    public string toSence;
    GameObject backgoundLoad;
    GameObject canvas;
    public int toPosIns = 0;
    public void loadAys()
    {
        canvas = GameObject.Find("popUpCavas");
        backgoundLoad = canvas.transform.Find("FateLoad_2").gameObject;
        StartCoroutine(startLoadS());
    }

    IEnumerator startLoadS()
    {
        backgoundLoad.SetActive(true);
        backgoundLoad.GetComponent<Animator>().Play("FateLoad_2");
        yield return new WaitForSeconds(1f);
        backgoundLoad.GetComponent<Animator>().Stop();
        GameManger.PreLoad();
        ThopFW.LoadLevelAsync.ToLevel(this.gameObject, toSence, true);
        ThopFW.LoadLevelAsync.StartLoadLevelAsync(() => { backgoundLoad.SetActive(false); GameManger.NextDoor(toPosIns); });
    } 
}
