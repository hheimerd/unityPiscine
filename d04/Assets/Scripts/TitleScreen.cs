﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.anyKey && !Input.GetKey(KeyCode.Mouse0))
		{
			SceneManager.LoadScene("DataSelect");
		}
	}
}
