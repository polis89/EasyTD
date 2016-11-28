using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MonsterLevel{
	public int cost;
	public GameObject visualisation;
}

public class MonsterData : MonoBehaviour {
	public List<MonsterLevel> levels;

	private MonsterLevel currentLevel;
	public MonsterLevel CurrentLevel{
		set{ 
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf (currentLevel);
			GameObject levelVisualisation = levels [currentLevelIndex].visualisation;
			for (int i = 0; i < levels.Count; i++) {
				if (levelVisualisation != null) {
					if (currentLevelIndex == i) {
						levels [i].visualisation.SetActive (true);
					} else {
						levels [i].visualisation.SetActive (false);
					}
				}
			}
		}
		get{
			return currentLevel;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		CurrentLevel = levels [0];
	}

	public MonsterLevel GetNextLevel(){
		int currentLevelIndex = levels.IndexOf (currentLevel);
		if (currentLevelIndex < levels.Count - 1) {
			return levels [currentLevelIndex + 1];
		} else {
			return null;
		}
	}

	public void IncreaseLevel(){
		int currentLevelIndex = levels.IndexOf (currentLevel);
		if (currentLevelIndex < levels.Count - 1) {
			CurrentLevel = levels [currentLevelIndex + 1];
		}
	}
}
