using UnityEngine;
using System.Collections;

public class tresure_E2 : MonoBehaviour {


    public bool notChack = true;
    public string nameChack = "";

    public void Events()
    {
        if (!notChack)
            Debug.Log(data_Key_tresure.chackKey(nameChack));
        else
            Debug.Log(true);
    }
}
