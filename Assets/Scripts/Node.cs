using UnityEngine;
using System.Collections;

public class Node : IHeapItem<Node>
{

	public bool walkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public Node parent;
	int heapIndex;

	//Used to classify the nodes
	public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
	{
		walkable = _walkable;
		worldPosition = _worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}
	
	//Creates the cost of f
	public int fCost
	{
		get
		{
			return gCost + hCost;
		}
	}

	//Returns the heap index value
	public int HeapIndex
	{
		get
		{
			return heapIndex;
		}
		set
		{
			heapIndex = value;
		}
	}

	//Compares the cost of each node for path creation
	public int CompareTo(Node nodeToCompare)
	{
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if (compare == 0)
		{
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}