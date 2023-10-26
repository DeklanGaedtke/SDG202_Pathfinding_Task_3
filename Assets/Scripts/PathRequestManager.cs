using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathRequestManager : MonoBehaviour
{
	Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
	PathRequest currentPathRequest;

	static PathRequestManager instance;
	//Creates an intance of the path request manger in the scene
	static PathRequestManager Instance
    {
        get
        {
			if(instance == null)
            {
				instance = FindObjectOfType<PathRequestManager>();
				if(instance == null)
                {
					GameObject go = new GameObject("PathRequestManager");
					instance = go.AddComponent<PathRequestManager>();
				}
            }
			return instance;
        }
    }
	Pathfinding pathfinding;

	bool isProcessingPath;


	void Awake()
	{
		instance = this;
		pathfinding = GetComponent<Pathfinding>();
	}

	//Requesting path form start to finish
	public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
	{
		PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
		Instance.pathRequestQueue.Enqueue(newRequest);
		Instance.TryProcessNext();
	}

	//Tries to find the path if the path is not found already
	void TryProcessNext()
	{
		if (!isProcessingPath && pathRequestQueue.Count > 0)
		{
			currentPathRequest = pathRequestQueue.Dequeue();
			isProcessingPath = true;
			pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
		}
	}
	
	//Checks to see if the path has been successful
	public void FinishedProcessingPath(Vector3[] path, bool success)
	{
		currentPathRequest.callback(path, success);
		isProcessingPath = false;
		TryProcessNext();
	}

	//Request for the paths creation
	struct PathRequest
	{
		public Vector3 pathStart;
		public Vector3 pathEnd;
		public Action<Vector3[], bool> callback;

		public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
		{
			pathStart = _start;
			pathEnd = _end;
			callback = _callback;
		}

	}
}