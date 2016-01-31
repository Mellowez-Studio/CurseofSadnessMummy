using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4;
    [SerializeField]
    float maxMoveSpeed = 4f;

    [SerializeField]
    float accelelation = 0f;
    [SerializeField]
    float accelelationGainRate = 4f;
    [SerializeField]
    float maxAccelelation = 2f;
    [SerializeField]
    float minAccelelation;

    public Transform target;

    OrbitCameraControl orbitCameraScript;

    void Start()
    {
        minAccelelation = maxAccelelation * -1;
        if (target!=null)
            StartCoroutine(TransformControl());
        else
            Debug.LogError("Error no orbitCamera on target!!!");
    }

    IEnumerator TransformControl()
    {        
        while (true)
        {
            if (GameManger.isPlayGame)
            {
                if (Input.GetAxis("Vertical") > 0)
                    target.Translate(target.GetChild(0).forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
                else
                    target.Translate(target.GetChild(0).forward * moveSpeed / 2 * Input.GetAxis("Vertical") * Time.deltaTime);
                target.Translate(target.GetChild(0).right * moveSpeed * 2 / 3 * Input.GetAxis("Horizontal") * Time.deltaTime);
            }
            yield return null;
        }        
    }

}
