using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class PlayerEnnt_01 : MonoBehaviour {

    public UnityEvent evnets;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (evnets != null)
                evnets.Invoke();
        }
    }
}
