using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovementPath : MonoBehaviour {

	public enum PathType
	{
		LINEAR,
		LOOP
	}
	
	public enum Direction
	{
		FORVARD = 1,
		BACK = -1
	}

	public PathType pathType;
	public Direction movementDirection;
	public int movingToIndex = 0;
	public Transform[] pathElements;

	private IEnumerator<Transform> pathEnumerator;
	
	public Transform GetNextPoint()
	{
		if (pathEnumerator == null)
		{
			pathEnumerator = GetPathPointIterator();
			if (pathEnumerator == null)
			{
				return null;
			}
		}
		pathEnumerator.MoveNext();
		return pathEnumerator.Current;
	}
	public void OnDrawGizmos()
	{
		if (pathElements == null || pathElements.Length < 2) return;

		for (var i = 1; i < pathElements.Length; i++)
		{
			Gizmos.DrawLine(pathElements[i-1].position, pathElements[i].position);
		}

		if (pathType == PathType.LOOP)
		{
			Gizmos.DrawLine(pathElements[0].position, pathElements[pathElements.Length - 1].position);
		}
	}

	public IEnumerator<Transform> GetPathPointIterator()
	{
		if (pathElements == null || pathElements.Length < 1)
		{
			yield break;
		}

		for(;;)
		{
			var nextPath = pathElements[movingToIndex];
			yield return nextPath;
			
			if (pathElements.Length == 1) continue;

			if (pathType == PathType.LINEAR)
			{
				if (movingToIndex <= 0)
					movementDirection = Direction.FORVARD;
				else if (movingToIndex >= pathElements.Length - 1)
					movementDirection = Direction.BACK;
			}

			movingToIndex += (int)movementDirection;
			movingToIndex %= pathElements.Length;
			Debug.Log(movingToIndex);
		}
	}
	
	
}
