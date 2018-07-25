using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [SerializeField] float xRange = 6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = Time.deltaTime * xThrow * xSpeed;
        float rawXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange); // transform.localPosition.x + xOffset is the new raw data, it will be limited by xRange

        transform.localPosition = new Vector3(rawXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
