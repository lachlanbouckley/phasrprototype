using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

	public GameController gameController;

	void Start ()
	{
		gameController = FindObjectOfType<GameController>();
	}
	
	void Update ()
	{
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player" && other.gameObject.layer == 11)
		{
			gameController.RespawnPlayer();
		}
	}
}
