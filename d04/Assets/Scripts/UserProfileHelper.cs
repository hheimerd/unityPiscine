using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileHelper : MonoBehaviour {

	public void ResetProgress()
	{
		PlayerPrefs.DeleteAll();
	}

}
