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
				Vector3 instantPos = new Vector3(transform.position.x + (i*dimentionX/2),transform.position.y +(j*dimentionY/2),transform.position.z);
				Puzzles[i,j] = Instantiate (PuzzlePrefab,instantPos,transform.rotation) as GameObject;
				Puzzles[i,j].transform.SetParent(this.transform);
				Puzzles[i,j].name = "Puzzles"+i+"_"+j;
                Puzzles[i, j].GetComponent<PuzzleClass>().myPuzzleController = this;              
			}
		}
	}

    public void CheckPuzzle()
    {

    }

	void Start()
	{
		Puzzles = new GameObject[(int)dimention.x,(int)dimention.y];
		GeneratePuzzle ((int)dimention.x, (int)dimention.y);
	}
}
