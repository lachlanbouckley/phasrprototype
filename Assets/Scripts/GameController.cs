using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public GameObject currentCheckpoint;
	private PlayerController player;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	private float gravityStore;
	private CameraController camera;
	public PlayerHealthManager playerHealthManager;
	
	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
		camera = FindObjectOfType<CameraController>();
		playerHealthManager = FindObjectOfType<PlayerHealthManager>();
	}
	
	void Update ()
	{
	
	}
	
	public void RespawnPlayer()
	{
		StartCoroutine("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo()
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
		player.knockbackCount = 0;
		//gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
		//player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ScoreManager.AddPoints(-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		//player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		playerHealthManager.FullHealth();
		playerHealthManager.isDead = false;
		camera.isFollowing = true;
		Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}