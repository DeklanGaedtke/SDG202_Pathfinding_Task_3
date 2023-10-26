using UnityEngine;

public class UnitDistance : MonoBehaviour
{

	//I used this for the creation of the Reciprocal Collision Avoidance system (just a reference script)

	//public int numberOfRays = 17;
	//public float angle = 90;
	//public float rayRange = 2;

	//void Update()
	//{
	//	var deltaPosition = Vector3.zero;
	//	for (int i = 0; i < numberOfRays; i++)
	//	{
	//		var rotation = this.transform.rotation;
	//		var rotationMode = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
	//		var direction = rotation * rotationMode * Vector3.forward;

	//		var ray = new Ray(this.transform.position, direction);
	//		RaycastHit hitInfo;
	//		if (Physics.Raycast(ray, out hitInfo, rayRange))
	//        {
	//			deltaPosition -= (1.0f / numberOfRays) * currentSpeed * direction;
	//        }
	//		else
	//		{
	//			deltaPosition += (1.0f / numberOfRays) * currentSpeed * direction;
	//		}
	//	}
	//	this.transform.position += deltaPosition * Time.deltaTime;
	//}

	//   private void OnDrawGizmos()
	//   {
	//	for (int i = 0; i < numberOfRays; i++) 
	//	{
	//		var rotation = this.transform.rotation;
	//		var rotationMode = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
	//		var direction = rotation * rotationMode * Vector3.forward;
	//		Gizmos.DrawRay(this.transform.position, direction);
	//	}
	//}
}
