
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float maxVisionDistance = 15f;
	public float listenDistance = 15f;
	public float minVisionDistance = 0.3f;
	public GameObject target;
	public Enemy enemyGFX;
	
	private FollowPath followPath;
	private AIPath aiPath;
	public bool isFollowing = false;

	void Follow()
	{
		followPath.isFollowing = false;
		isFollowing = true;
		aiPath.canMove = true;
		aiPath.canSearch = true;
	}
	
	void StopFollow()
	{
		isFollowing = false;
		aiPath.canMove = false;
		aiPath.canSearch = false;
	}
	
	// Use this for initialization
	void Start ()
	{
		var aiDestSetter = GetComponent<AIDestinationSetter>();
		aiDestSetter.target = target.transform;
		aiPath = GetComponent<AIPath>();
		followPath = GetComponent<FollowPath>();
		var player = target.GetComponent<Player>();
		if (player)
		{
			player.AddSoundListener(() =>
			{
				var distance = Vector2.Distance(target.transform.position, transform.position);
				Debug.Log(distance);
				if (distance < listenDistance)
				{
					Follow();
				}
			});
		}
	}

	bool canSeePlayer()
	{
		var distance = Vector2.Distance(target.transform.position, transform.position);
		if (distance > maxVisionDistance)
			return false;

		if (distance < minVisionDistance)
			return true;

		var layerMask = LayerMask.GetMask("Obstacle", "Player", "Wall", "Door");
		var obstacle = Physics2D.Linecast(transform.position, target.transform.position, layerMask);
		if (!obstacle || obstacle.collider.tag.Equals("Player"))
		{
			Vector3 targetDirection = target.transform.position - gameObject.transform.position;
			float angle = Vector3.Angle(transform.up, targetDirection);

			if (angle > 120) 
				return false;
			if (angle < 60)
				return true;
			if (maxVisionDistance / 2 > distance)
				return true;
		}

		return false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemyGFX.isDead)
			Destroy(gameObject);
		if (isFollowing)
		{
			if (canSeePlayer())
			{
				enemyGFX.Shoot();
			}
			return;
		}
		
		if (canSeePlayer()) Follow();
	}
}
