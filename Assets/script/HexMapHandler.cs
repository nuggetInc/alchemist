using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapHandler : MonoBehaviour
{
	public int mapRadius;
	List<Hex> map;
	public Layout layout;

	Dictionary<Hex, GameObject> objectsOnMap;

	void Start()
	{
		objectsOnMap = new Dictionary<Hex, GameObject>();

		GenerateMap();
		GenerateMesh();

		layout.UVPolygonCorners(new Hex(0, 0, 0));
	}

	void GenerateMesh()
	{
		List<Vector2> vertices2d = new List<Vector2>();
		List<Vector2> UVCoordinates = new List<Vector2>();
		List<int> indices = new List<int>();
		//List<Vector3> normals = new List<Vector3>();

		layout = new Layout(Layout.pointy, new Vector2(.5775f, .5775f), new Vector2(0, 0));
		int hexIndex = 0;
		foreach(Hex hex in map)
		{
			Vector2[] polygonCorners = layout.PolygonCorners(hex);
			vertices2d.AddRange(polygonCorners);

			Vector2[] UVCorners = layout.UVPolygonCorners(hex);
			UVCoordinates.AddRange(UVCorners);

			Triangulator triangulator = new Triangulator(polygonCorners);
			foreach(int indice in triangulator.Triangulate())
			{
				indices.Add(hexIndex + indice);
			}
			hexIndex += 6;

			/*normals.Add(new Vector3(0, 0, 1));
			normals.Add(new Vector3(0, 0, 1));
			normals.Add(new Vector3(0, 0, 1));
			normals.Add(new Vector3(0, 0, 1));
			normals.Add(new Vector3(0, 0, 1));
			normals.Add(new Vector3(0, 0, 1));*/
		}

		Vector3[] vertices3d = System.Array.ConvertAll<Vector2, Vector3>(vertices2d.ToArray(), v => v);

		Mesh mesh = new Mesh();
		mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = vertices3d;
		mesh.uv = UVCoordinates.ToArray();
		mesh.triangles = indices.ToArray();
		//mesh.normals = normals.ToArray();
		//mesh.RecalculateNormals();

		//GetComponent<MeshRenderer>().materials[0].SetColor("_Color", Color.white);
	}

	void GenerateMap()
	{
		map = new List<Hex>();

		for(int q = -mapRadius; q <= mapRadius; q++)
		{
			int r1 = Mathf.Max(-mapRadius, -q - mapRadius);
			int r2 = Mathf.Min(mapRadius, -q + mapRadius);
			for(int r = r1; r <= r2; r++)
			{
				map.Add(new Hex(q, r, -q - r));
			}
		}
	}

	public void PlaceObject(Hex hex, Object requestedObject)
	{
		if(!objectsOnMap.ContainsKey(hex) && hex.Length() <= mapRadius)
		{
			GameObject gameObject = new GameObject("device");

			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = requestedObject.sprite;

			gameObject.transform.SetParent(transform);
			gameObject.transform.position = layout.HexToPixel(hex);

			objectsOnMap.Add(hex, gameObject);
		}
	}

	public void RemoveObject(Hex hex)
	{
		if(objectsOnMap.ContainsKey(hex))
		{
			Destroy(objectsOnMap[hex]);
			objectsOnMap.Remove(hex);
		}
	}
}