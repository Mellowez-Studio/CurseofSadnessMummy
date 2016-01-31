using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleController : MonoBehaviour {

	[SerializeField]
	GameObject PuzzlePrefab;

	[SerializeField]
	public GameObject[,] Puzzles;

	[SerializeField]
	Vector2 dimention;

	[SerializeField]
	float instantOffset = 1;

	[SerializeField]
	int countToCorrect;
	[SerializeField]
	int correctCount;

	public enum PuzzleColor
	{
		Red,
		Blue,
		Green,
		Yellow
	}

	public void GeneratePuzzle(int dimentionX, int dimentionY)
	{
		for(int i = 0; i < dimentionX;i++)
		{
			for(int j = 0; j < dimentionY; j++)
			{
				Vector3 instantPos = new Vector3(
					transform.position.x - ((dimentionX-1)/2f) + (i*instantOffset),
					transform.position.y + ((dimentionY-1)/2f) - (j*instantOffset),
					transform.position.z);
				Puzzles[i,j] = Instantiate (PuzzlePrefab,instantPos,transform.rotation) as GameObject;
				Puzzles[i,j].transform.SetParent(this.transform);
				Puzzles[i,j].name = "Puzzles"+i+"_"+j;
                Puzzles[i, j].GetComponent<PuzzleClass>().myPuzzleController = this;              
			}
		}
	}

    public void CheckPuzzle()
    {
		correctCount = 0;

		for(int i = 0;i<dimention.x-1;i++)
		{
			for(int j = 0;j<dimention.y;j++)
			{
				if(Puzzles [i, j].GetComponent<PuzzleClass> ().slotRight == Puzzles [i+1, j].GetComponent<PuzzleClass> ().slotLeft) 
				{
					print (i+","+j+" == "+(i+1)+","+j);
					correctCount++;
				}
			}
		}

		for(int i = 0;i<dimention.x;i++)
		{
			for(int j = 0;j<dimention.y-1;j++)
			{
				if(Puzzles [i, j].GetComponent<PuzzleClass> ().slotDown == Puzzles [i, j+1].GetComponent<PuzzleClass> ().slotUp) 
				{
					print (i+","+j+" == "+i+","+(j+1));
					correctCount++;
				}
			}
		}

		/*
		if (Puzzles [0, 0].GetComponent<PuzzleClass> ().slotDown == Puzzles [0, 1].GetComponent<PuzzleClass> ().slotUp) 
		{
			print (" 0,0 == 0,1 ");
			correctCount++;
		} 
		if (Puzzles [0, 0].GetComponent<PuzzleClass> ().slotRight == Puzzles [1, 0].GetComponent<PuzzleClass> ().slotLeft) 
		{
			print (" 0,0 == 1,0 ");
			correctCount++;
		} 
		if (Puzzles [0, 1].GetComponent<PuzzleClass> ().slotRight == Puzzles [1, 1].GetComponent<PuzzleClass> ().slotLeft)
		{
			print (" 0,1 == 1,1 ");
			correctCount++;
		} 
		if (Puzzles [1, 0].GetComponent<PuzzleClass> ().slotDown == Puzzles [1, 1].GetComponent<PuzzleClass> ().slotUp)
		{
			print (" 1,0 == 1,1 ");
			correctCount++;
		} 		
*/
		if (correctCount == countToCorrect)
			print (" FINISH !!");
		else
			print (" NOT YET !!");
    }

	void Start()
	{
		Puzzles = new GameObject[(int)dimention.x,(int)dimention.y];
		GeneratePuzzle ((int)dimention.x, (int)dimention.y);
		countToCorrect = ((int)dimention.x * ((int)dimention.y - 1)) + (((int)dimention.x - 1) * (int)dimention.y);
		//print("(int)dimention.x * (int)dimention.y - 1) = " + ((int)dimention.x * ((int)dimention.y - 1)));
		//print("(int)dimention.x - 1 * (int)dimention.y) = " + (((int)dimention.x - 1) * (int)dimention.y));
	}
}
