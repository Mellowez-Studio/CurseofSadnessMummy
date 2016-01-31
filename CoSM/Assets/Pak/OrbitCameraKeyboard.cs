using UnityEngine;
using System.Collections;

public class OrbitCameraKeyboard : MonoBehaviour {
    
    [SerializeField]
    float rotationSensitivity = 3;

    public Transform target;
       
    OrbitCameraControl orbitCameraScript;

    void Start()
    {
        orbitCameraScript = target.GetComponent<OrbitCameraControl>();
        if (orbitCameraScript != null)
            StartCoroutine(CameraRotateController());
        else
            Debug.LogError("Error no orbitCamera on target!!!");
    }

    IEnumerator CameraRotateController()
    {
        float rotationAmount;
        rotationAmount = rotationSensitivity * Time.deltaTime * 30;
        while (true)
        {
            if (GameManger.isPlayGame)
            {
                if (Input.GetKey(KeyCode.Q))
                    orbitCameraScript.RotateHorizontal(-rotationAmount);
                if (Input.GetKey(KeyCode.E))
                    orbitCameraScript.RotateHorizontal(rotationAmount);
            }
            yield return null;
        }

    }

}
