﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("musicTag");
		if (objs.Length > 1)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
