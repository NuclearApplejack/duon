using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {


	GameObject generalCamera;
	float shakeTimer = 0f;
	float shakeFactor = 0f;
	float currentCameraAngle = 0f;




	// Use this for initialization
	void Start () {

		generalCamera = GameObject.Find ("GeneralCamera");
		
	}
	
	// Update is called once per frame
	void Update () {


		if (shakeTimer > 0) {
			shakeTimer = shakeTimer - Time.deltaTime;

			float randomAngle = Random.Range (0f, 180f);
			currentCameraAngle += randomAngle + 90f;

			float movX = 0f;
			float movY = 0f;

			movX = Mathf.Cos (Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;
			movY = Mathf.Sin (Mathf.Deg2Rad * currentCameraAngle) * shakeFactor;


			generalCamera.transform.position = new Vector3 (generalCamera.transform.position.x + movX, generalCamera.transform.position.y + movY, generalCamera.transform.position.z);


		}

		
	}

	public void ShakeScreen(float factor = 1, float time = 1) {

		shakeTimer = time;
		shakeFactor = factor;



	}
}
