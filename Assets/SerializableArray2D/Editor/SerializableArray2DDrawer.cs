using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Array2DBool))] // This ties the Array2DDrawer to the Array2DBool
public class BoolArray2DDrawer : Array2DDrawer
{
	protected override int ElementWidth
	{
		// The Array2DDrawer class below does all the hard stuff; here we can just say how wide each element should be.
		// Try changing this number to see what happens to the drawer
		get { return 15; } 
	}
}

[CustomPropertyDrawer(typeof(Array2DInt))] // This ties the Array2DDrawer to the Array2DBool
public class Array2DIntDrawer : Array2DDrawer
{
	protected override int ElementWidth
	{
		// The Array2DDrawer class below does all the hard stuff; here we can just say how wide each element should be.
		// Try changing this number to see what happens to the drawer
		get { return 25; } 
	}
}
// Black editor tool magic; don't try this 1 week before an assessment
public abstract class Array2DDrawer : UnityEditor.PropertyDrawer
{
	protected abstract int ElementWidth { get; }
	protected virtual int ElementHeight
	{
		get { return (int)UnityEditor.EditorGUIUtility.singleLineHeight; }
	}
	private int setSizeX;
	private int setSizeY;
	
	
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		var sizeY = property.FindPropertyRelative("sizeY");
		return (ElementHeight * sizeY.intValue) + UnityEditor.EditorGUIUtility.singleLineHeight;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		position = UnityEditor.EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		var arrayProp = property.FindPropertyRelative("array");
		var sizeX = property.FindPropertyRelative("sizeX");
		var sizeY = property.FindPropertyRelative("sizeY");
		
		Rect setSizeXRect = new Rect(position.x, position.y, 20, UnityEditor.EditorGUIUtility.singleLineHeight);
		Rect setSizeYRect = new Rect(setSizeXRect.xMax, position.y, 20, UnityEditor.EditorGUIUtility.singleLineHeight);
		Rect setSizeButton = new Rect(setSizeYRect.xMax + 5, position.y, 100, UnityEditor.EditorGUIUtility.singleLineHeight);
		if (setSizeX == 0 && sizeX.intValue > 0) setSizeX = sizeX.intValue;
		if (setSizeY == 0 && sizeY.intValue > 0) setSizeY = sizeY.intValue;
		
		setSizeX = UnityEditor.EditorGUI.IntField(setSizeXRect, setSizeX);
		setSizeY = UnityEditor.EditorGUI.IntField(setSizeYRect, setSizeY);
		
		if (GUI.Button(setSizeButton, "Resize Array"))
		{
			SetArraySize(arrayProp, sizeX, sizeY, setSizeX, setSizeY);
		}
		
		position = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, position.height);
		
		int yOffset = 0;
		for (int y = 0; y < sizeY.intValue; y++)
		{
			int xOffset = 0;
			for (int x = 0; x < sizeX.intValue; x++)
			{
				Rect rect = new Rect(position.x + xOffset, position.y + yOffset, ElementWidth, ElementHeight);

				int index = XYToIndex(sizeX, sizeY, x, y);
				SerializedProperty prop = arrayProp.GetArrayElementAtIndex(index);
				
				
				EditorGUI.PropertyField(rect, prop, GUIContent.none);
				xOffset += ElementWidth;
			}

			yOffset += ElementHeight;
		}

		
		EditorGUI.EndProperty();
	}

	int XYToIndex(SerializedProperty sizeX, SerializedProperty sizeY, int x, int y)
	{
		// Todo: Bounds check here:
		return (x + y * sizeX.intValue);
	}

	void SetArraySize(SerializedProperty array, SerializedProperty xSize, SerializedProperty ySize, int x, int y)
	{
		xSize.intValue = x;
		ySize.intValue = y;
		array.arraySize = x * y;
	}
}
