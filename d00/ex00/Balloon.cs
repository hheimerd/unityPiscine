using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

	[SerializeField] private GameObject baloonPlane;
	private bool _userLoose = false;
	private long _gameMs = 0;
	private int _blowIntoCount = 15;

	const int BLOW_INTO_MAX = 7;
	private double sizeToBlow;

	private const int FPS = 60;
	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = FPS;
		sizeToBlow = baloonPlane.transform.localScale.x * 1.5;
	}

	void inflate()
	{
		_blowIntoCount--;
		var scale = baloonPlane.transform.localScale;
		scale.x += 0.1f;
		scale.y += 0.1f;
		baloonPlane.transform.localScale = scale;
	}

	private void blowOff()
	{
		var scale = baloonPlane.transform.localScale;
		if (scale.x < 0)
		{
			Debug.Log(("Balloon life time: " + Mathf.RoundToInt((float)_gameMs / FPS)) + "s");
			Destroy(baloonPlane);
			return;
		}
		
		scale.x -= _userLoose ? 0.1f : 0.01f;
		scale.y -= _userLoose ? 0.1f : 0.01f;
		baloonPlane.transform.localScale = scale;
	}

	void checkScale()
	{
		var scale = baloonPlane.transform.localScale;
		if (scale.x > sizeToBlow || scale.x < 0)
		{
			_userLoose = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_gameMs % FPS == 0)
		{
			_blowIntoCount = BLOW_INTO_MAX;
		}

		_gameMs++;
		if (Input.GetKeyUp(KeyCode.Space) && _blowIntoCount > 0 && !_userLoose)
			inflate();
		else
			blowOff();

		checkScale();
	}
}
