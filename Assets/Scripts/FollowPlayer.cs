using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

	private GameObject player;
	public float speed;
	public float chaseSpeed;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
	{
		if(player.layer == 11 && Vector2.Distance(this.transform.position, player.transform.position) < 6)
		{
			//this.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, 0));
			Vector3 dir = this.transform.position - player.transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speed);
			
			//this.transform.Translate(Vector2.MoveTowards(player.transform.position, this.transform.position, (speed * Time.deltaTime * 0.01f)));
			
			this.transform.position += this.transform.forward * speed * Time.deltaTime;
		}
		//else get the missile to go forward in whatever direction it was going
	}
}