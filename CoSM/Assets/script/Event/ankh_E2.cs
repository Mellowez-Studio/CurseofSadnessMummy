using UnityEngine;
using System.Collections;
using thopframwork;
public class ankh_E2 : MonoBehaviour {

    public string nameChack ="";
    public float time = 0.25f;
 
    // Use this for initialization
    public void Events()
    {
        ThopFW.TransformAll.ScaleTo(this.gameObject,Vector3.zero,time,null,()=> { data_Key_tresure.addNameKey(nameChack); });
    }
}
