using UnityEngine;
using System.Collections;
using System;

public class Heap<T> where T : IHeapItem<T>
{

	T[] items;
	int currentItemCount;

	public Heap(int maxHeapSize)
	{
		items = new T[maxHeapSize];
	}

	//Adds count to the sqaure
	public void Add(T item)
	{
		item.HeapIndex = currentItemCount;
		items[currentItemCount] = item;
		SortUp(item);
		currentItemCount++;
	}

	//Removes the lowest F cost
	public T RemoveFirst()
	{
		T firstItem = items[0];
		currentItemCount--;
		items[0] = items[currentItemCount];
		items[0].HeapIndex = 0;
		SortDown(items[0]);
		return firstItem;
	}

	//Used updates the node
	public void UpdateItem(T item)
	{
		SortUp(item);
	}


	public int Count
	{
		get
		{
			return currentItemCount;
		}
	}


	public bool Contains(T item)
	{
		return Equals(items[item.HeapIndex], item);
	}

	//Used to calculate if the parent node is less than its child
	void SortDown(T item)
	{
		while (true)
		{
			int childIndexLeft = item.HeapIndex * 2 + 1;
			int childIndexRight = item.HeapIndex * 2 + 2;
			int swapIndex = 0;

			if (childIndexLeft < currentItemCount)
			{
				swapIndex = childIndexLeft;

				if (childIndexRight < currentItemCount)
				{
					if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
					{
						swapIndex = childIndexRight;
					}
				}

				if (item.CompareTo(items[swapIndex]) < 0)
				{
					Swap(item, items[swapIndex]);
				}
				else
				{
					return;
				}

			}
			else
			{
				return;
			}

		}
	}

	//Checks if child is less than parent and will swap it
	void SortUp(T item)
	{
		int parentIndex = (item.HeapIndex - 1) / 2;

		while (true)
		{
			T parentItem = items[parentIndex];
			if (item.CompareTo(parentItem) > 0)
			{
				Swap(item, parentItem);
			}
			else
			{
				break;
			}

			parentIndex = (item.HeapIndex - 1) / 2;
		}
	}

	//If its lower than its parent its will swap it with its parent until it is not
	void Swap(T itemA, T itemB)
	{
		items[itemA.HeapIndex] = itemB;
		items[itemB.HeapIndex] = itemA;
		int itemAIndex = itemA.HeapIndex;
		itemA.HeapIndex = itemB.HeapIndex;
		itemB.HeapIndex = itemAIndex;
	}



}

public interface IHeapItem<T> : IComparable<T>
{
	int HeapIndex
	{
		get;
		set;
	}
}