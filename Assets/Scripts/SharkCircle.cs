using UnityEngine;
using System.Collections;

public class SharkCircle : MonoBehaviour
{
	/*
	public float DistanceLimit = 0;
	
	private Vector3 previousPosition;
	
	public float chaseTimer;
	
	public float chasingSharkLerpSpeed;
	
	public float returningSharkLerpSpeed;
	
	private bool tweenIsPaused = false;
	
	private float timer = 0;
	
	public PlayerRespawnHandler PlayerRespawnHandler;
	
	public AudioClip sharkEat;
	
	private bool frenzy = false;
	
	public float frenzyTimer;
	
	public float diveDistance;
	
	void Start()
	{
		previousPosition = gameObject.transform.position;
		circle();
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.GetComponentInParent<BoatInformation>() != null)
		{
			PlayerRespawnHandler.RespawnPlayer(collider.GetComponentInParent<BoatInformation>().PlayerId);
			this.timer = 10000;
			
			GameState.Instance.GlobalAudioSource.PlayOneShot(sharkEat);
		}
		if (collider.GetComponent<CannonballBehaviour>() != null)
		{
			this.frenzy = true;
		}
	}
	
	void Update()
	{
		var nearestDist = 0f;
		BoatInformation nearestBoatInformation = null;
		GameObject nearestBoat = null;
		Vector3 downInitialPosition = new Vector3(previousPosition.x, diveDistance, previousPosition.z);
		
		// find nearest boat
		foreach (var player in GameState.Instance.AlivePlayers)
		{
			var otherBoatPos = player.BoatInformation.RigidBody.position;
			var dist = Vector3.Distance(this.gameObject.GetComponent<Rigidbody>().position, otherBoatPos);
			if (dist < nearestDist || nearestDist == 0f)
			{
				nearestBoat = player.BoatObject;
				nearestDist = dist;
				nearestBoatInformation = player.BoatInformation;
			}
		}
		
		// If the shark is in frenzy mode
		if (frenzy == true && this.timer < this.frenzyTimer)
		{
			//Triggers the first frame of frenzy mode to turn off pathing and start timer
			if (tweenIsPaused == false)
			{
				iTween.Pause(gameObject);
				tweenIsPaused = true;
				this.previousPosition = gameObject.transform.position;
				this.timer = 0;
			}
			
			this.timer++;
			
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nearestBoat.transform.position, this.chasingSharkLerpSpeed * 2);
			gameObject.transform.LookAt(nearestBoat.transform);
		}
		// if chasing a player
		else if (nearestDist < this.DistanceLimit && this.timer < this.chaseTimer && GameState.Instance[nearestBoatInformation.PlayerId].PlayerState == PlayerState.Alive)
		{
			//Triggers the first frame of chase mode to turn off pathing and start timer
			if (tweenIsPaused == false)
			{
				iTween.Pause(gameObject);
				tweenIsPaused = true;
				this.previousPosition = gameObject.transform.position;
				this.timer = 0;
			}
			
			this.timer++;
			
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, nearestBoat.transform.position, this.chasingSharkLerpSpeed);
			gameObject.transform.LookAt(nearestBoat.transform.position);
		}
		else
		{
			// If the shark is close enough to it's initial position on it's path
			if (tweenIsPaused == true && Vector3.Distance(gameObject.transform.position, downInitialPosition) < 3)
			{
				iTween.Resume(gameObject);
				tweenIsPaused = false;
				this.timer = 0;
				frenzy = false;
			}
			else
			{
				//Head back towards it's inital position
				if (tweenIsPaused == true)
				{
					//Dive down first then go back
					if (gameObject.transform.position.y < diveDistance + 3)
					{
						gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, downInitialPosition, this.returningSharkLerpSpeed);
						gameObject.transform.LookAt(previousPosition);
					}
					else
					{
						//Go back to the place underwater
						gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, diveDistance, gameObject.transform.position.z), this.returningSharkLerpSpeed);
						gameObject.transform.LookAt(downInitialPosition);
					}
				}
			}
		}
	}
	
	void moveComplete()
	{
		circle();
	}
	
	void circle()
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Circling"),
		                                      "time", 40.0f,
		                                      "easetype", iTween.EaseType.linear,
		                                      "orienttopath", true,
		                                      "lookahead", .1f,
		                                      "onComplete", "moveComplete"));
	}
	*/
}
