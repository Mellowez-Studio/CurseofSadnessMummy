using UnityEngine;
using System.Collections;
using thopframwork;
public class Door1 : MonoBehaviour {
    public Vector2 min_Max;
    public string keyPuzzle = "";
    public bool chackMinMax = false;
    public bool ChackPuzzle = false;
    public string ToSence = "";
    public int toPosIns = 0;
    public string DontEnter = "";
	public bool isExitGame = false;
    GameObject backgoundLoad;
    GameObject canvas;
    public void loadAys()
    {
          canvas = GameObject.Find("popUpCavas");
          backgoundLoad = canvas.transform.Find("FateLoad_2").gameObject;
		if (!isExitGame) {
			if (chackMinMax) {
				if (min_Max.x >= UIControl.hour && UIControl.hour <= min_Max.y)
					StartCoroutine (startLoadS ());
				else
					PopUpBase.PopUpText (DontEnter);
			} else {
				if (!ChackPuzzle)
					StartCoroutine (startLoadS ());
				else
                if (data_Key_tresure.chackKey (keyPuzzle))
					StartCoroutine (startLoadS ());
				else
					PopUpBase.PopUpText (DontEnter);
			}
		} else
			PopUpBase.PopUpText ("SO SAD........",()=>Application.Quit());
        
    }

    IEnumerator startLoadS()
    {
        backgoundLoad.SetActive(true);
       // backgoundLoad.GetComponent<Animator>().Play("FateLoad_2");
        yield return new WaitForSeconds(1f);
       // backgoundLoad.GetComponent<Animator>().Stop();
        GameManger.PreLoad();
        ThopFW.LoadLevelAsync.ToLevel(this.gameObject, ToSence, true);
        ThopFW.LoadLevelAsync.StartLoadLevelAsync(() => { backgoundLoad.SetActive(false);GameManger.NextDoor(toPosIns); });
    }
    
}
