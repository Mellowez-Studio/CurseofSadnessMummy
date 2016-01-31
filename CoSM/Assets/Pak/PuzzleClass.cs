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
                isWorking = false;
                myPuzzleController.CheckPuzzle();
            });
	}

    public void RequestNewPuzzle()
    {
        defaultScale = this.transform.localScale;
        if (!isWorking)
        {
            isWorking = true;

            thopframwork.ThopFW.TransformAll.ScaleTo(this.gameObject, Vector3.zero, 0.4f, null,
            () =>
            {
                print("OLO");
                RandomNewColor();
                Invoke("ScaleToNormal",0.2f);
            });
        }
    }

    void ScaleToNormal()
    {
        thopframwork.ThopFW.TransformAll.ScaleTo(this.gameObject, defaultScale, 0.4f, null,
                () =>
                {
                    isWorking = false;
                    myPuzzleController.CheckPuzzle();
                });
    }

    void RandomNewColor()
    {

    }
    




}
