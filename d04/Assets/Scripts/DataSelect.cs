using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataSelect : MonoBehaviour {
	
	[SerializeField] private TMP_Text dies;
	[SerializeField] private TMP_Text rings;
	// [SerializeField] private LevelSelect[] levels;

	void LoadGame()
	{
		dies.text = PlayerPrefs.GetString("UserLives", "0");
		rings.text = PlayerPrefs.GetString("UserRings", "0");
	}
	
	// Use this for initialization
	void Start ()
	{
		LoadGame();
	}

}
