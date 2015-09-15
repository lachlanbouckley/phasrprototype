using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
	public int maxPlayerHealth;
	public static int playerHealth;
	public bool isDead;
	
	Text text;
	
	private GameController gameController;
	
	void Start ()
	{
		text = GetComponent<Text>();
		playerHealth = maxPlayerHealth;
		gameController = FindObjectOfType<GameController>();
		isDead = false;
	}
	
	void Update ()
	{
		if(playerHealth <=0 && !isDead)
		{
			playerHealth = 0;
			gameController.RespawnPlayer();
			isDead = true;
		}
		
		text.text = "" + playerHealth + "/" + maxPlayerHealth;
	}
	
	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}
	
	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
