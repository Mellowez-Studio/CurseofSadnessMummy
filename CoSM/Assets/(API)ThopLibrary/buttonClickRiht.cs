using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class buttonClickRiht : MonoBehaviour {

	public UnityEvent actions;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			actions.Invoke();
		}
	}
}
