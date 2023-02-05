using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;

	//public float shakeDuration = 0f;
	public bool isShaking = false;

	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	public float maxDelay = 0.5f;
	private float currentDelay = 0f;

	Vector3 originalPos;

	void Awake()
	{
		camTransform = GetComponent<Transform>();
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (isShaking)
		{
			currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
				currentDelay = maxDelay;
			}
			//shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			//shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}