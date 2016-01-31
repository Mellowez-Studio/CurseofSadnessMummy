using UnityEngine;
using System.Collections;
using System;

public class PuzzleClass : MonoBehaviour
{
    public PuzzleController myPuzzleController;

    public PuzzleController.PuzzleColor slotUp;
    public PuzzleController.PuzzleColor slotLeft;
    public PuzzleController.PuzzleColor slotDown;
    public PuzzleController.PuzzleColor slotRight;

    public bool isWorking = false;

    Vector3 defaultScale;
    
    [SerializeField]
    GameObject[] jewel;

    public void TurnRight()
	{
        if (!isWorking)
        {
            isWorking = true;
            PuzzleController.PuzzleColor tempSlotUp = slotUp;			
			slotUp = slotLeft;
			slotLeft = slotDown;
			slotDown = slotRight;
			slotRight = tempSlotUp;            
            SpinPuzzle(-90);
        }
    }
    /*
	public void TurnLeft()
	{
	 	if (!isRotate)
        {
			PuzzleController.PuzzleColor tempSlotUp = slotUp;
			slotUp = slotRight;
			slotRight = slotDown;
			slotDown = slotLeft;
			slotLeft = tempSlotUp;
			isWorking = true;
        	SpinPuzzle(90);
		}
	}*/

    void SpinPuzzle(int rotationZ)
    {
        thopframwork.ThopFW.TransformAll.RotateTo(this.gameObject, new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z + rotationZ), 0.8f, null, 
            () => 
            {                
                myPuzzleController.CheckPuzzle();
                isWorking = false;
            });
	}

    public void RequestNewPuzzle()
    {        
        if (!isWorking)
        {
            isWorking = true;
            defaultScale = this.transform.localScale;            

            thopframwork.ThopFW.TransformAll.ScaleTo(this.gameObject, Vector3.zero, 0.4f, null,
            () =>
            {
                print("OLO");
                transform.localEulerAngles = Vector3.zero;
                RandomNewColor();
                Invoke("ScaleToNormal",0.1f);
            });
        }
    }

    void ScaleToNormal()
    {
        thopframwork.ThopFW.TransformAll.ScaleTo(this.gameObject, defaultScale, 0.4f, null,
                () =>
                {                    
                    myPuzzleController.CheckPuzzle();
                    isWorking = false;
                });
    }

    public void RandomNewColor()
    {
        int[] x= new int[4];
        x[0] = 0;
        x[1] = 1;
        x[2] = 2;
        x[3] = 3;
        Vector4 newColorValue = Shuffle(x);
        slotUp = GetColor((int)newColorValue.x);
        slotLeft = GetColor((int)newColorValue.y);
        slotDown = GetColor((int)newColorValue.z);
        slotRight = GetColor((int)newColorValue.w);

        SetJewelColor();
    }

    public Vector4 Shuffle(int[] alpha)
    {
        Vector4 newValue;
        for (int i = 0; i < alpha.Length; i++)
        {
            int temp = alpha[i];
            int randomIndex = UnityEngine.Random.Range(i, alpha.Length);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
        newValue.x = alpha[0];
        newValue.y = alpha[1];
        newValue.z = alpha[2];
        newValue.w = alpha[3];
        return newValue;
    }

    PuzzleController.PuzzleColor GetColor(int x)
    {
        PuzzleController.PuzzleColor y = PuzzleController.PuzzleColor.Blue;
        switch (x)
        {
            case 0: y = PuzzleController.PuzzleColor.Red;
                break;
            case 1:y = PuzzleController.PuzzleColor.Blue;
                break;
            case 2:y = PuzzleController.PuzzleColor.Green;
                break;
            case 3:y = PuzzleController.PuzzleColor.Yellow;
                break;
        }
        return y;
    }

    void SetJewelColor()
    {
        jewel[0].GetComponentInChildren<MeshRenderer>().material.color = GetColor(slotUp);
        jewel[1].GetComponentInChildren<MeshRenderer>().material.color = GetColor(slotRight);
        jewel[2].GetComponentInChildren<MeshRenderer>().material.color = GetColor(slotDown);
        jewel[3].GetComponentInChildren<MeshRenderer>().material.color = GetColor(slotLeft);
    }

    Color GetColor(PuzzleController.PuzzleColor slot)
    {
        Color c = Color.red;

        switch(slot)
        {
            case PuzzleController.PuzzleColor.Blue: c = Color.blue;
                break;
            case PuzzleController.PuzzleColor.Green: c = Color.green;
                break;
            case PuzzleController.PuzzleColor.Red: c = Color.red;
                break;
            case PuzzleController.PuzzleColor.Yellow: c = Color.yellow;
                break;
        }
        return c;
    }



}
