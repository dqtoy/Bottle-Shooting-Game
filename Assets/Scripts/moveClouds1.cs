using UnityEngine;

public class moveClouds1 : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform transfB;

	private Vector3 posA;

	private Vector3 posCloudSmall;

	private Vector3 posB;

	private Vector3 nextPosition;

	[SerializeField]
	private Transform childTransf;

	[SerializeField]
	private Transform cloudSmall;

	private void Start()
	{
		posA = childTransf.localPosition;
		posCloudSmall = cloudSmall.localPosition;
		posB = transfB.localPosition;
		nextPosition = posB;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		childTransf.localPosition = Vector3.MoveTowards(childTransf.localPosition, nextPosition, speed * Time.deltaTime);
		cloudSmall.localPosition = Vector3.MoveTowards(cloudSmall.localPosition, nextPosition, speed * Time.deltaTime);
		if ((double)Vector3.Distance(childTransf.localPosition, nextPosition) <= 0.1)
		{
			childTransf.localPosition = posA;
		}
		if ((double)Vector3.Distance(cloudSmall.localPosition, nextPosition) <= 0.1)
		{
			cloudSmall.localPosition = posCloudSmall;
		}
	}

	private void changeDestination()
	{
		nextPosition = ((!(nextPosition != posA)) ? posB : posA);
	}
}
