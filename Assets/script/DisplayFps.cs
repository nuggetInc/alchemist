using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFps : MonoBehaviour
{
	public Text text;
	float deltaTime = 0f;

	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		text.text = (1 / deltaTime).ToString();
	}
}
