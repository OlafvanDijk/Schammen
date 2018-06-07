using UnityEngine;

public class Array2DExample : MonoBehaviour
{
	public Array2DBool MySerializableArray2D = new Array2DBool(5, 5);

	public void SetSomeValues()
	{
		for (int i = 0; i < MySerializableArray2D.sizeX; i++)
		{
			for (int j = 0; j < MySerializableArray2D.sizeY; j++)
			{
				MySerializableArray2D.SetValue(i, j, true); // Set entire array to true.
			}
		}
		
	}
	// Use this for initialization
	void Start () 
	{
		SetSomeValues();
	}
	
}
