using UnityEngine;
using System.Collections;

public class PuzzleClass : MonoBehaviour
{
    public PuzzleController myPuzzleController;

    public PuzzleController.PuzzleColor slotUp;
    public PuzzleController.PuzzleColor slotLeft;
    public PuzzleController.PuzzleColor slotDown;
    public PuzzleController.PuzzleColor slotRight;

    public bool isRotate = false;
	
	public void TurnRight()
	{
        if (!isRotate)
        {
			PuzzleController.PuzzleColor tempSlotUp = slotUp;			
			slotUp = slotLeft;
			slotLeft = slotDown;
			slotDown = slotRight;
			slotRight = tempSlotUp;
            isRotate = true;
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
			isRotate = true;
        	SpinPuzzle(90);
		}
	}*/
	
	public void SpinPuzzle(int rotationZ)
    {
        thopframwork.ThopFW.TransformAll.RotateTo(this.gameObject, new Vector3(0, 0, this.transform.localEulerAngles.z + rotationZ), 0.8f, null, 
            () => 
            {
                isRotate = false;
                myPuzzleController.CheckPuzzle();
            });
	}

   

}
