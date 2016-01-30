using UnityEngine;
using System.Collections;
using thopframwork;
public class Door1 : MonoBehaviour {
    public Vector2 min_Max;
    public string ToSence = "";
    public string DontEnter = "";

    GameObject backgoundLoad;
    GameObject canvas;
    public void loadAys()
    {
          canvas = GameObject.Find("popUpCavas");
          backgoundLoad = canvas.transform.Find("FateLoad_2").gameObject;
        if (min_Max.x >= UIControl.hour && UIControl.hour <= min_Max.y)
            StartCoroutine(startLoadS());
        else
            PopUpBase.PopUpText(min_Max + DontEnter + UIControl.hour);
            
        
    }

    IEnumerator startLoadS()
    {
        backgoundLoad.SetActive(true);
        backgoundLoad.GetComponent<Animator>().Play("FateLoad_2");
        yield return new WaitForSeconds(1f);
        backgoundLoad.GetComponent<Animator>().Stop();
        ThopFW.LoadLevelAsync.ToLevel(this.gameObject, ToSence, true);
        ThopFW.LoadLevelAsync.StartLoadLevelAsync(() => { backgoundLoad.SetActive(false); });
    }
    
}
