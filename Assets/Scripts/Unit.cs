using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
	Pathfinding pathfinding;

	public Transform target;
	public float currrentSpeed = 5f;
	Vector3[] path;
	int targetIndex;

	
	public int numberOfRays = 17;
	public float angle = 90;
	public float rayRange = 2;

	void Start()
	{
		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

		pathfinding = GetComponent<Pathfinding>();
	}

	//My Attempt at Reciprocal Collision Avoidance (It did not work how I envisioned, but "works" none the less)
	void Update()
	{
		var deltaPosition = Vector3.zero;
		for (int i = 0; i < numberOfRays; i++)
		{
			var rotation = this.transform.rotation;
			var rotationMode = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
			var direction = rotation * rotationMode * Vector3.zero; //change the Vector 3 to zero becuase it was coursing an issue when it was set to forward

			var ray = new Ray(this.transform.position, direction);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo, rayRange))
			{
				deltaPosition -= (1.0f / numberOfRays) * currrentSpeed * direction;
			}
			else
			{
				deltaPosition += (1.0f / numberOfRays) * currrentSpeed * direction;
			}
		}
		this.transform.position += deltaPosition * Time.deltaTime;
	}

	//On path found will do the coroutines
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	//Follows the path using waypoints
	IEnumerator FollowPath()
	{
		//Gets the current path and creates waypoints for the unit to follow
		Vector3 currentWaypoint = path[0];
		while (true)
		{

            if (transform.position == currentWaypoint)
			{
				targetIndex++;
				if (targetIndex >= path.Length)
				{
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, currrentSpeed * Time.deltaTime);
			yield return null;
		}
	}

	//Draws the path and waypoints
	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i++)
			{
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex)
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
				{
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}

		//Use to show the Reciprocal Collision Avoidance
		for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = this.transform.rotation;
            var rotationMode = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMode * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }
}