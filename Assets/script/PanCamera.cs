using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanCamera : MonoBehaviour
{
	Transform tr;
	float size;
	Vector3 lastMousePos;

	void Start()
	{
		tr = transform;
		size = Camera.main.orthographicSize;
	}

	// Update is called once per frame
	void Update()
	{
		if(EventSystem.current.IsPointerOverGameObject() == false)
		{
			/*if(Input.GetMouseButtonDown(1))
				lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			else if(Input.GetMouseButton(1) == true)
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector3 diff = lastMousePos - mousePos;
				tr.position += diff;
				lastMousePos = mousePos + diff;
			}*/

			if(Input.GetKey(KeyCode.A))
			{
				tr.position += new Vector3(-5, 0, 0) * Camera.main.orthographicSize * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.D))
			{
				tr.position += new Vector3(5, 0, 0) * Camera.main.orthographicSize * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.W))
			{
				tr.position += new Vector3(0, 5, 0) * Camera.main.orthographicSize * Time.deltaTime;
			}
			if(Input.GetKey(KeyCode.S))
			{
				tr.position += new Vector3(0, -5, 0) * Camera.main.orthographicSize * Time.deltaTime;
			}

			float scroll = Input.mouseScrollDelta.y;
			if(scroll != 0)
			{
				scroll = Mathf.Max(Mathf.Min(Camera.main.orthographicSize - scroll, 20), 1);
				Camera.main.orthographicSize = scroll;
			}
		}
	}
}