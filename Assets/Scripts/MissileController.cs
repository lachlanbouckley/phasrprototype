using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
	public float speed;
	//public MissileLauncherController missileLauncher;
	public GameObject impactEffect;
	public int damageToGive;
	
	void Start ()
	{
		
		/*player = FindObjectOfType<PlayerController>();
		if(player.transform.localScale.x <0)
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
		*/
	}
	
	void Update ()
	{
		//GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	
	//destory object when it hits something
	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}