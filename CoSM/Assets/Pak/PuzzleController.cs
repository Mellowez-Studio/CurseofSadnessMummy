﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour {

	[SerializeField]
	GameObject PuzzlePrefab;

	[SerializeField]
	public GameObject[,] Puzzles;

    List<PuzzleClass> PuzzlesClass = new List<PuzzleClass>();
    PuzzleClass targetPuzzleClass;

    [SerializeField]
	Vector2 dimention;

	[SerializeField]
	float instantOffset = 1;

	[SerializeField]
	int countToCorrect;
	[SerializeField]
	int correctCount;

    public UnityEvent OnFinish;
    [SerializeField]
    string OnFinish2;

    public enum PuzzleColor
	{
		Red,
		Blue,
		Green,
		Yellow
	}

	public void GeneratePuzzle()
	{
        Puzzles = new GameObject[(int)dimention.x, (int)dimention.y];
        countToCorrect = ((int)dimention.x * ((int)dimention.y - 1)) + (((int)dimention.x - 1) * (int)dimention.y);
        int dimentionX = (int)dimention.x;
        int dimentionY = (int)dimention.y;

        for (int i = 0; i < dimentionX; i++)
		{
			for(int j = 0; j < dimentionY; j++)
			{
				Vector3 instantPos = new Vector3(
					transform.position.x - ((dimentionX - 1)/2f) + (i*instantOffset),
					transform.position.y + ((dimentionY - 1)/2f) - (j*instantOffset),
					transform.position.z);
				Puzzles[i,j] = Instantiate (PuzzlePrefab,instantPos,transform.rotation) as GameObject;
				Puzzles[i,j].transform.SetParent(this.transform);
				Puzzles[i,j].name = "Puzzles"+i+"_"+j;
                targetPuzzleClass = Puzzles[i, j].GetComponent<PuzzleClass>();
                targetPuzzleClass.myPuzzleController = this;
                PuzzlesClass.Add(targetPuzzleClass);
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
        if (correctCount == countToCorrect)
        {
            print(" FINISH !!");
            data_Key_tresure.addNameKey(OnFinish2);
            PopUpBase.PopUpText("Puzzle Clear!!", () => OnFinish.Invoke());
            Invoke("ClosePuzzle", 1f);
        }
        else
            print(" NOT YET !!");
    }

    void ClosePuzzle()
    {
        foreach (PuzzleClass puzzle in PuzzlesClass)
        {
            thopframwork.ThopFW.TransformAll.RotateTo(puzzle.gameObject, new Vector3(0, 0, puzzle.transform.localEulerAngles.z + 90), 1.5f, null,null);
            thopframwork.ThopFW.TransformAll.ScaleTo(puzzle.gameObject, Vector3.zero, 1.5f, null, null);
        }
    }
    
}
