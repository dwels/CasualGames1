﻿using UnityEngine;
using System.Collections;
/*
//This camera smoothes out rotation around the y-axis and height.
//Horizontal Distance to the target is always fixed.
//For every of those smoothed values we calculate the wanted value and the current value.
//Then we smooth it using the Lerp function.
//Then we apply the smoothed values to the transform's position.
*/
public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 3.0f;
    //height above target
    public float height = 1.50f;
    //distance before camera moves
    public float heightBuffer = 2.0f;
    public float heightDamping = 2.0f;
    public float positionDamping = 2.0f;
    public float rotationDamping = 2.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;

        float wantedHeight = target.position.y + height;
        float currentHeight = transform.position.y;

        float yDist = Mathf.Abs(wantedHeight - currentHeight);
        
        if (yDist > heightBuffer)
        {
            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Set the position of the camera 
            Vector3 wantedPosition = new Vector3(transform.position.x, target.position.y - target.forward.y * distance, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * positionDamping);

        }


        //////x and z settings//////
        /*// Set the position of the camera 
		Vector3 wantedPosition = target.position - target.forward * distance;
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * positionDamping);
		
		// adjust the height of the camera
		transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
		
		//transform.forward = Vector3.Lerp (transform.forward, target.position - transform.position, Time.deltaTime * rotationDamping);
		transform.forward = Vector3.Lerp (transform.forward, target.forward , Time.deltaTime * rotationDamping);*/

    }
}