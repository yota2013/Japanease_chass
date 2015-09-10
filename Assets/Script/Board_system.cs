using UnityEngine;
using System.Collections;

public class Board_system : MonoBehaviour {
	private int[,] board;
	// Use this for initialization
	void Start () {
		board = new int[9,9];
		for (int i = 0; i < board.GetLength(0); i++)
		{
			
			for (int j = 0; j < board.GetLength(1); j++)
			{
				board[i,j] = 0;
				Debug.Log(board[i,j]);
			}            
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Bard()
	{

	}
}
