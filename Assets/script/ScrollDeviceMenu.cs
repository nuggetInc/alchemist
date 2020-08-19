using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollDeviceMenu : MonoBehaviour
{
	public float height;
	public Transform tr;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(EventSystem.current.IsPointerOverGameObject())
		{
			tr.position += new Vector3(0, -Input.mouseScrollDelta.y * 10, 0);
		}
	}

	public void ScrollbarChanged()
	{

	}
}
