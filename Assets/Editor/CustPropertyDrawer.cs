using UnityEngine;
using UnityEditor;
using System.Collections;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

[CustomPropertyDrawer(typeof(BingoPattern))]
public class CustPropertyDrawer : PropertyDrawer
{


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);

        Rect newposition = position;
        newposition.y += 25f;
        SerializedProperty data = property.FindPropertyRelative("cells");

        data.arraySize = 25;
        //Debug.LogError("ongui");
        //data.rows[0][]
        //int num = 1;
        for (int j = 0; j < 25; j++)
        {

            SerializedProperty cell = data.GetArrayElementAtIndex(j);
            newposition.height = 18f;

            if (j % 5 == 0)
            {
                newposition.x = position.x;
                newposition.y += 18;
            }
            //if(row.arraySize != 5)
            //	row.arraySize = 5;
            newposition.width = position.width / 10;
            EditorGUI.PropertyField(newposition, cell, GUIContent.none);

            newposition.x += newposition.width;
        }

    }


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}
