using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFps : MonoBehaviour
{
	public int fpsLimit;

	void Awake()
	{
#if UNITY_EDITOR
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = fpsLimit;
#endif
	}
}

namespace testNamespace
{
	struct testStruct1
	{
		public int test;
		public testStruct1(int a)
		{
			test = a;
		}
	}

	struct testStruct2
	{
		public int test2;
		public testStruct2(int a)
		{
			test2 = a;
		}
	}
}