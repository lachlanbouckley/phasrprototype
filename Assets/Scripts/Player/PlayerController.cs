using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	
	public Transform weakCheck;
	public float weakCheckRadius;
	public LayerMask whatIsWeak;
	//public Transform strongCheck;
	//public float strongCheckRadius;
	//public LayerMask whatIsStrong;
	private bool grounded;
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	
	private Animator anim;

		void Start ()
	{
		anim = GetComponent<Animator>();
	}
		
		void FixedUpdate()
		{
			grounded = (Physics2D.OverlapCircle(weakCheck.position, weakCheckRadius, whatIsWeak));
		}
		
		void Update ()
	{
		if (Input.GetButtonDown("Jump") && grounded)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			grounded = false;
		}
		
		anim.SetBool("Grounded", grounded);
		
		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal"); //makes the player walk left and right
		
		if (Input.GetButton ("Phase"))
		{
			gameObject.layer = 12;
		}
		
		else
		{
			gameObject.layer = 11;
		}
		
		
		if(knockbackCount <= 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}
		
		else
		{
			if(knockFromRight)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
			}
			if(!knockFromRight)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
			}
			knockbackCount -= Time.deltaTime;
			
			if(knockbackCount < 0)
			{
				knockbackCount = 0;
			}
		}

		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		if(GetComponent<Rigidbody2D>().velocity.x > 0)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if(GetComponent<Rigidbody2D>().velocity.x < 0)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		
		/*
		if(Input.GetKeyDown(KeyCode.C))
		{
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}
		
		if(Input.GetKey(KeyCode.C))
		{
			shotDelayCounter -= Time.deltaTime;
			
			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
		*/
	}
}