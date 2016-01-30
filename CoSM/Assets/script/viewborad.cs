using UnityEngine;
using System.Collections;

public class viewborad : MonoBehaviour
{
    Coroutine mycorutine;
    public void startViewBorad()
    {
        mycorutine = StartCoroutine(startView());
    }
    public void endViewBorad()
    {
        StopCoroutine(mycorutine);
    }

    IEnumerator startView()
    {
        while (true)
        {
            this.transform.rotation = Camera.main.transform.rotation;
            yield return null;
        }
    }
   
}
