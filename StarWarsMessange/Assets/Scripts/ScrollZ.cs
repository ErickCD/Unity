﻿using System.Collections;
using UnityEngine;

public class ScrollZ : MonoBehaviour {

    public float scrollSpeed = 15;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 localvectorUp = transform.TransformDirection(0, 1, 0);
        pos += localvectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;
	}
}
