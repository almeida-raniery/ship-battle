using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveData))]
public class WaveDataEditor : Editor
{
    SerializedProperty enemyTypes;
    SerializedProperty enemyAmounts;

    void OnEnable()
    {
        enemyTypes   = serializedObject.FindProperty("enemies");
        enemyAmounts = serializedObject.FindProperty("enemyAmounts");
    } 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Amount of enemies", EditorStyles.boldLabel);

        enemyAmounts.arraySize = enemyTypes.arraySize;

        for(int i = 0; i < enemyTypes.arraySize; i++)
        {
            string objectName = enemyTypes.GetArrayElementAtIndex(i).objectReferenceValue?.name;
            SerializedProperty enemyAmount = enemyAmounts.GetArrayElementAtIndex(i);

            enemyAmount.intValue = EditorGUILayout.IntField(objectName, enemyAmount.intValue);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
