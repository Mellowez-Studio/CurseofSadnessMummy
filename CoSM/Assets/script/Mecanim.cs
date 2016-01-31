using UnityEngine;
using System.Collections;

public class Mecanim : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManger.isPlayGame)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("IsWalk", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("IsWalk", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Direction", -1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("Direction", 1);
            }
            else {
                anim.SetInteger("Direction", 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Pick");
            }

        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
	}
}
