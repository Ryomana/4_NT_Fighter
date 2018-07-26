using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [SerializeField] float positionPitchFactor = 10f;
    [SerializeField] float controlPitchFactor = 30f;
    [SerializeField] float positionYawFactor = 6.5f;
    [SerializeField] float positionRollFactor = 10f;
    [SerializeField] float controlRollFactor = -30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 2.5f;

    float xThrow, yThrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = Time.deltaTime * xThrow * xSpeed;
        float yOffset = Time.deltaTime * yThrow * ySpeed;
        float rawXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange); // transform.localPosition.x + xOffset is the new raw data, it will be limited by xRange
        float rawYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(rawXPos, rawYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;

        float yRollRaw = positionRollFactor * transform.localPosition.x; // rotates the ship inwards

        float roll = xThrow * controlRollFactor + yRollRaw;
        transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);
    }
}
