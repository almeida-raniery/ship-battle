using UnityEditor;

[CustomEditor(typeof(ShipMovement), true)]
public class ShipSpeedEditor : Editor
{
  SerializedProperty fullSpeed;
  SerializedProperty midSpeed;
  SerializedProperty lowSpeed;
  SerializedProperty sailPosition;
  SerializedProperty acceleration;
  SerializedProperty steeringSpeed;
  SerializedProperty driftCompRate;

  void OnEnable()
  {
    fullSpeed = serializedObject.FindProperty("fullSpeed");
    midSpeed = serializedObject.FindProperty("midSpeed");
    lowSpeed = serializedObject.FindProperty("lowSpeed");
    sailPosition = serializedObject.FindProperty("sailPosition");
    acceleration = serializedObject.FindProperty("acceleration");
    steeringSpeed = serializedObject.FindProperty("steeringSpeed");
    driftCompRate = serializedObject.FindProperty("driftCompRate");
  }

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();

    Undo.RecordObject(this, "Set Value");

    float lastFullSpeed = fullSpeed.floatValue;
    EditorGUILayout.Space(10);

    EditorGUILayout.LabelField("Speed Controls", EditorStyles.boldLabel);
    EditorGUILayout.Space(3);

    fullSpeed.floatValue = EditorGUILayout.DelayedFloatField("Full Speed", fullSpeed.floatValue);

    EditorGUILayout.Slider(midSpeed, lowSpeed.floatValue, fullSpeed.floatValue);
    EditorGUILayout.Slider(lowSpeed, 0, midSpeed.floatValue);
    EditorGUILayout.PropertyField(sailPosition);
    EditorGUILayout.PropertyField(acceleration);

    if (fullSpeed.floatValue < midSpeed.floatValue)
      midSpeed.floatValue = fullSpeed.floatValue;

    if (fullSpeed.floatValue < lowSpeed.floatValue)
      lowSpeed.floatValue = fullSpeed.floatValue;

    EditorGUILayout.Space(10);

    EditorGUILayout.LabelField("Steering Controls", EditorStyles.boldLabel);
    EditorGUILayout.Space(3);
    EditorGUILayout.PropertyField(steeringSpeed);
    EditorGUILayout.Slider(driftCompRate, 0, 1, "Drift Compensation");

    serializedObject.ApplyModifiedProperties();
  }

}
