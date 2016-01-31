using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using thopframwork;
public class PlayerEvent : MonoBehaviour {

    public UnityEvent eventA;
    GameObject sprite;
    Vector3 ScaleOp = new Vector3(0.25f,0.25f,0.25f);
    viewborad myViewBorad;
    private bool isCilckOk = false; 
    // Use this for initialization
    void Start()
    {
        sprite = Instantiate(Resources.Load("ProjectAssets/image/E_btn") as GameObject);
        sprite.transform.SetParent(gameObject.transform);
        myViewBorad = sprite.GetComponent<viewborad>();
        sprite.transform.localPosition = new Vector3(-1.1f,1.6f,-0.5f);
    }
	   
    private Coroutine startEvent;
    void OnTriggerEnter(Collider other)
    {     
        if (other.tag == "Player")
        {
            iswork = true;
            myViewBorad.startViewBorad();
            ThopFW.TransformAll.ScaleTo(sprite,ScaleOp,0.25f,null,()=>{ startEvent = StartCoroutine(isWork()); });
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isCilckOk)
            {
                iswork = false;
                StopCoroutine(isWork());
                ThopFW.TransformAll.ScaleTo(sprite, Vector3.zero, 0.25f, null, () => { myViewBorad.endViewBorad(); });
            }
        }
    }
    bool iswork = true;
    IEnumerator isWork()
    {
        while (iswork)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ThopFW.TransformAll.ScaleTo(sprite, Vector3.zero, 0.25f, null, () => { eventA.Invoke(); StopCoroutine(isWork()); isCilckOk = true; });
            }
            yield return null ;
        }
    }
    public void testinveoke()
    {
        ThopFW.TransformAll.ScaleTo(this.gameObject,Vector3.zero,0.25f);
    }

}
