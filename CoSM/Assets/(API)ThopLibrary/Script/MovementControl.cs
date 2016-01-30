using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 0;
    [SerializeField]
    float maxMoveSpeed = 8f;

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
        float xMoveSpeedTemp;
        float zMoveSpeedTemp;
        while (true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (accelelation < maxAccelelation)
                    accelelation += accelelationGainRate * Time.deltaTime;
                else
                    accelelation = maxAccelelation;

                moveSpeed += accelelation * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (accelelation > minAccelelation)
                    accelelation += -accelelationGainRate * Time.deltaTime;
                else
                    accelelation = minAccelelation;

                moveSpeed += accelelation * Time.deltaTime;

            }
                
            //target.Translate(Vector3.forward * moveSpeed);
            //target.Translate(Vector3.forward * moveSpeed);
            yield return null;
        }
        
        yield return null;
    }

}
