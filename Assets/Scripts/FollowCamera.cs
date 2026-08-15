using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class FollowCamera : MonoBehaviour
{

	public GameObject player;

	public Vector3 offset;
	public float offsetDistance;

	public Transform Obstruction;

	void Start()
	{
		offset = transform.position - player.transform.position;
		offsetDistance = Vector3.Distance(transform.position, player.transform.position);
		Obstruction = null;
		transform.LookAt(player.transform);
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
		ViewObstructed();
	}

	void ViewObstructed()
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, offsetDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
		{
			if (hit.collider.gameObject.tag != "Player")
			{
				if (Obstruction == null)
				{
					Obstruction = hit.transform;
					//Debug.Log("Make " + Obstruction.transform.gameObject.name + " transparent");
					MeshRenderer obstructMeshRenderer = Obstruction.gameObject.GetComponent<MeshRenderer>();
					if (obstructMeshRenderer != null)
					{
						obstructMeshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
					}
				}
			}
			else
			{
				if (Obstruction != null)
				{
					//Debug.Log("Make " + Obstruction.transform.gameObject.name + " opaque");
					MeshRenderer obstructMeshRenderer = Obstruction.gameObject.GetComponent<MeshRenderer>();
					if (obstructMeshRenderer != null)
					{
						obstructMeshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
					}
					Obstruction = null;
				}
			}
		}
		//else
		//{
		//	Debug.Log("No Raycast Hit");
		//}
	}
}
