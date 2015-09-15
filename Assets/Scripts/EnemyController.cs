using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	public int enemyHealth;
	public GameObject deathEffect;
	public int pointsOnDeath;

	void Start ()
	{
	
	}

	void Update ()
	{
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		
		if(hittingWall)
		{
			moveRight = !moveRight;
		}
	
		if(moveRight)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		
		if(enemyHealth <=0)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(pointsOnDeath);
			Destroy(gameObject);
		}
	}
	
	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;
	}
}