﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script depends on the SpriteRenderer component attached to this object
[RequireComponent(typeof(SpriteRenderer))]

public class ScreenWrap : MonoBehaviour
{
    //sprite
    private SpriteRenderer spriteRenderer;
    //camera
    private Bounds camBounds;
    private float camWidth;
    private float camHeight;
        
    // Use this for initialization
	void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    void UpdateCameraBounds()
    {
        //Calculate camera bounds
        Camera cam = Camera.main;
        camHeight = 2F * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
    }

	// LateUpdate is called out at the end of a frame
	void LateUpdate ()
    {
        UpdateCameraBounds();
        //Store position and size in a shorter variable names
        Vector3 pos = transform.position;
        Vector3 size = spriteRenderer.bounds.size;
        //Calculate the sprites half width and half height
        float halfWidth = size.x / 2;
        float halfHeight = size.y / 2;
        float halfCamWidth = camWidth / 2;
        float halfCamHeight = camHeight / 2;
        //check Left
        if (pos.x + halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.max.x + halfWidth;
        }
        //check Right
        if (pos.x - halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.min.x - halfWidth;
        }
        //check Top
        if (pos.y - halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.min.y - halfHeight;
        }
        //check Bottom
        if (pos.y + halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.max.y + halfHeight;
        }
        //move the enemy back around
        transform.position = pos;
    }
}
