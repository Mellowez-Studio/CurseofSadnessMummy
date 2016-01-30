using UnityEngine;
using System.Collections;

public class PuzzleClass : MonoBehaviour
{
	PuzzleController.PuzzleColor slotUp;
	PuzzleController.PuzzleColor slotLeft;
	PuzzleController.PuzzleColor slotDown;
	PuzzleController.PuzzleColor slotRight;
	
	public void TurnRight()
	{
		PuzzleController.PuzzleColor tempSlotUp = slotUp;
		slotUp = slotLeft;
		slotLeft = slotDown;
		slotDown = slotRight;
		slotRight = tempSlotUp;
		CheckPuzzle ();
	}
	
	public void TurnLeft()
	{
		PuzzleController.PuzzleColor tempSlotUp = slotUp;
		slotUp = slotRight;
		slotRight = slotDown;
		slotDown = slotLeft;
		slotLeft = tempSlotUp;
		CheckPuzzle ();
	}
	
	void CheckPuzzle()
	{
		//
	}

}
