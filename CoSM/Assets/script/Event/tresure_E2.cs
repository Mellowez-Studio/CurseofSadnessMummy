using UnityEngine;
using System.Collections;

public class tresure_E2 : MonoBehaviour {


    public bool notChack = true;
    public string nameChack = "";
    public Sprite sprite;
    public string DialogOpen = "";
    public string DialogDont = "";
    public void Events()
    {
        if (!notChack)
        {
            if (data_Key_tresure.chackKey(nameChack))
                PopUpBase.PopUpImg(sprite,()=>{ PopUpBase.PopUpText(DialogOpen); });
            else
                PopUpBase.PopUpText(DialogDont);
        }
        else
            PopUpBase.PopUpImg(sprite, () => { PopUpBase.PopUpText(DialogOpen); });
        
    }
}
