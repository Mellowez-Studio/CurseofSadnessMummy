﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class buttonClickRiht : MonoBehaviour {

	public UnityEvent actions;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.name == this.gameObject.name)
                {
                    actions.Invoke();
                }
            }
        }
    }
  

    
}
