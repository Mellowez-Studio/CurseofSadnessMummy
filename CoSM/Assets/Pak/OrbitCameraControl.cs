using UnityEngine;
using System.Collections;
//using UnityEditor;

public class OrbitCameraControl : MonoBehaviour {


    [SerializeField]
    Camera targetCamera;

    Transform cameraTransform;

    
    public Transform target;

    [SerializeField]
    float rotationSensitivity = 3;
    [SerializeField]
    float scrollSensitivity = 2;

    [SerializeField]
    float distanceFromTarget = 5f;
    [SerializeField]
    float minDistanceFromTarget = 2f;
    [SerializeField]
    float maxDistanceFromTarget = 8f;
	[SerializeField]
	float cameraDistanceSnapSpeed = 1.5f;


    [SerializeField]
    float minRotationY = -90f;
    [SerializeField]
    float maxRotationY = 20f;

    [SerializeField]
    Vector3 offsetPos = new Vector3(0,5,0);

    GameObject orbitObjHorizontal;
    Transform orbitObjHorizontalTransform;

    GameObject orbitObjVertical;
    Transform orbitObjVerticalTransform;

	[SerializeField]
	float tempRotationY;

    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = this.GetComponent<Camera>();
            if (targetCamera == null)
                targetCamera = Camera.main;
            cameraTransform = targetCamera.transform;
        }
        if (target == null)
        {
            cameraTransform = this.gameObject.transform;
            Debug.LogError("Error no target attach to OrbitCameraControl");
        }
        else
        {
            orbitObjHorizontal = new GameObject("OrbitObjHorizontal");
            orbitObjHorizontalTransform = orbitObjHorizontal.transform;

            orbitObjVertical = new GameObject("OrbitObjVertical");
            orbitObjVerticalTransform = orbitObjVertical.transform;

            cameraTransform.localPosition = new Vector3(0, 0, distanceFromTarget);
            orbitObjHorizontalTransform.localEulerAngles = new Vector3(0, 180, 0);
            orbitObjVerticalTransform.localEulerAngles = new Vector3(30, 0, 0);

            cameraTransform.SetParent(orbitObjVerticalTransform);
            orbitObjVerticalTransform.SetParent(orbitObjHorizontalTransform);
            orbitObjHorizontalTransform.SetParent(target);

            orbitObjHorizontalTransform.localPosition += offsetPos + target.position;

			cameraTransform.LookAt(orbitObjHorizontalTransform);
			tempRotationY = orbitObjVerticalTransform.localEulerAngles.y;
            StartCoroutine(OrbitCamera());
            StartCoroutine(ScrollCamera());
			StartCoroutine(DynamicMaxRotationYFromDistance());
        }
    }

    IEnumerator OrbitCamera()
    {
        float rotationX;
        float rotationY;

        while (true)
        {
			cameraTransform.LookAt(orbitObjHorizontalTransform);
            if (Input.GetKey(KeyCode.Mouse1))
            {
                rotationX = Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime * 100;
                rotationY = Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime * 100;

                //set rotationX
                orbitObjHorizontalTransform.Rotate(Vector3.up, rotationX);

                //set rotationY

                if (tempRotationY >= maxRotationY && rotationY > 0)
					tempRotationY = maxRotationY;
				else if (tempRotationY <= minRotationY && rotationY < 0)
					tempRotationY = minRotationY;
				else					
				{
					tempRotationY += rotationY;
					if (tempRotationY > maxRotationY)
						tempRotationY = maxRotationY;
					else if (tempRotationY < minRotationY)
						tempRotationY = minRotationY;
				}
				
				orbitObjVerticalTransform.localEulerAngles = new Vector3(tempRotationY,0,0);

            }

            yield return null;
        }
    }

    IEnumerator ScrollCamera()
    {
        float z;
		Vector3 targetCameraLocalPos = cameraTransform.localPosition;
        while (true)
        {
            if (Input.GetAxis("Mouse ScrollWheel")!=0)
            {
                z = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity * Time.deltaTime * 100;

                if (cameraTransform.localPosition.z <= minDistanceFromTarget && z < 0)
					distanceFromTarget = minDistanceFromTarget;
                else if (cameraTransform.localPosition.z >= maxDistanceFromTarget && z > 0)
					distanceFromTarget = maxDistanceFromTarget;
                else					
				{
					distanceFromTarget += z;
					if (distanceFromTarget > maxDistanceFromTarget)
						distanceFromTarget = maxDistanceFromTarget;
					else if (distanceFromTarget < minDistanceFromTarget)
						distanceFromTarget = minDistanceFromTarget;
				}
					
				targetCameraLocalPos = new Vector3(cameraTransform.localPosition.x, cameraTransform.localPosition.y, distanceFromTarget);
            }
			cameraTransform.localPosition = Vector3.Slerp(cameraTransform.localPosition, targetCameraLocalPos,cameraDistanceSnapSpeed * Time.deltaTime);
            yield return null;
        }
    }

	IEnumerator DynamicMaxRotationYFromDistance()
	{
		float startMaxRotationY = maxRotationY;
		while (true)
		{
			maxRotationY = startMaxRotationY*(maxDistanceFromTarget/distanceFromTarget); 
			if (tempRotationY > maxRotationY)
				tempRotationY = maxRotationY;
			else if (tempRotationY < minRotationY)
				tempRotationY = minRotationY;
			orbitObjVerticalTransform.localEulerAngles = new Vector3(tempRotationY,0,0);
			yield return null;
		}
	}

    public void RotateHorizontal(float amount)
    {
        orbitObjHorizontalTransform.Rotate(Vector3.up, amount);
        target.GetChild(0).Rotate(Vector3.up, amount);
    }
}
