using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {
	[HideInInspector]
	public GameObject[] waypoints;
	private int currentWaypoint;
	private float lastWaypointSwitchTime;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		lastWaypointSwitchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 startPos = waypoints [currentWaypoint].transform.position;
		Vector3 endPos = waypoints [currentWaypoint + 1].transform.position;
		float pathLenght = Vector3.Distance (startPos, endPos);
		float totalTimeForPath = pathLenght / speed;
		float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
		gameObject.transform.position = Vector3.Lerp (startPos, endPos, currentTimeOnPath / totalTimeForPath);
		if (gameObject.transform.position.Equals (endPos)) {
			if(currentWaypoint < waypoints.Length - 2){
				currentWaypoint++;
				lastWaypointSwitchTime = Time.time;
				//TODO Rotate
			}else{
				Destroy (gameObject);
				AudioSource auS = GetComponent<AudioSource> ();
				AudioSource.PlayClipAtPoint (auS.clip, gameObject.transform.position);
				//TODO Minus health
			}
		}
	}
}
