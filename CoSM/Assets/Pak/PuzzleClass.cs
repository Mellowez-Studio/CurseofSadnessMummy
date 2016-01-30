using UnityEngine;
using System.Collections;

public class PuzzleClass : MonoBehaviour
{
    public PuzzleController myPuzzleController;

    public PuzzleController.PuzzleColor slotUp;
    public PuzzleController.PuzzleColor slotLeft;
    public PuzzleController.PuzzleColor slotDown;
    public PuzzleController.PuzzleColor slotRight;

    bool isRotate = false;
	
	public void TurnRight()
	{
		PuzzleController.PuzzleColor tempSlotUp = slotUp;
		slotUp = slotLeft;
		slotLeft = slotDown;
		slotDown = slotRight;
		slotRight = tempSlotUp;

        if (!isRotate)
        {
            isRotate = true;
            SpinPuzzle(90);
        }
    }
	
	public void TurnLeft()
	{
		PuzzleController.PuzzleColor tempSlotUp = slotUp;
		slotUp = slotRight;
		slotRight = slotDown;
		slotDown = slotLeft;
		slotLeft = tempSlotUp;
	}
	
	public void SpinPuzzle(int rotationZ)
    {
        thopframwork.ThopFW.TransformAll.RotateTo(this.gameObject, new Vector3(0, 0, this.transform.localEulerAngles.z + rotationZ), 1.5f, null, 
            () => 
            {
                isRotate = false;
                myPuzzleController.CheckPuzzle();
            });
	}

   

}
