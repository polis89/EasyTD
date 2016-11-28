using UnityEngine;
using System.Collections;

public class PlaceMonster : MonoBehaviour {
	public GameObject monsterPrefab;

	private GameObject monster;
	private GameManagerBehavior gameManagerBehavior;

	// Use this for initialization
	void Start () {
		gameManagerBehavior = GameObject.Find ("GameManager").GetComponent<GameManagerBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (canPlaceMonster ()) {
			monster = Instantiate (monsterPrefab, transform.position, Quaternion.identity) as GameObject;
			AudioSource audioSource = GetComponent<AudioSource> ();
			audioSource.PlayOneShot (audioSource.clip);
			gameManagerBehavior.Gold -= monster.GetComponent<MonsterData> ().CurrentLevel.cost;
		} else if (canUpgradeMonster ()) {
			monster.GetComponent<MonsterData> ().IncreaseLevel();
			AudioSource audioSource = GetComponent<AudioSource> ();
			audioSource.PlayOneShot (audioSource.clip);
			gameManagerBehavior.Gold -= monster.GetComponent<MonsterData> ().CurrentLevel.cost;
		}
	}

	private bool canPlaceMonster(){
		int cost = monsterPrefab.GetComponent<MonsterData> ().levels [0].cost;
		return monster == null && gameManagerBehavior.Gold >= cost;
	}

	private bool canUpgradeMonster(){
		if (monster != null) {
			MonsterData mData = monster.GetComponent<MonsterData> ();
			MonsterLevel mLevel = mData.GetNextLevel ();
			if (mLevel != null) {
				return gameManagerBehavior.Gold >= mLevel.cost;
			}
		}
		return false;
	}
}
