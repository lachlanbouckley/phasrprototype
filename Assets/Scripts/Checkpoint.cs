using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

	public GameController gameController;
	
	void Start ()
	{
		gameController = FindObjectOfType<GameController>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			gameController.currentCheckpoint = gameObject;
		}
	}
}