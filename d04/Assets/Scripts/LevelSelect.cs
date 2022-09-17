using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
	[SerializeField] private TMP_Text bestRun;
	public int id = 0;
	public bool isAvable = false;
	private Image image;


	// Use this for initialization
	void Start ()
	{
		image = GetComponent<Image>();
		isAvable = PlayerPrefs.GetFloat("LevelAvailable_" + id, isAvable ? 1 : 0) > 0 || isAvable;
		SetAvable(isAvable);
		bestRun.text = GetBestRun().ToString();
		if (!isAvable) bestRun.alpha = 0;
	}

	int GetBestRun()
	{
		return PlayerPrefs.GetInt("LevelBest_" + id, 0);
	}

	public void SetAvable(bool newValue)
	{
		isAvable = newValue;
		PlayerPrefs.SetFloat("LevelAvailable_" + id, isAvable ? 1 : 0);
		image.color = isAvable ? Color.white : Color.gray;
	}
}
