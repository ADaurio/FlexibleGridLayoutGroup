#if UNITY_EDITOR
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(FlexibleGridLayoutGroup), true)]
    public class FlexibleGridLayoutGroupEditor : Editor
    {
        SerializedProperty m_Padding;
        SerializedProperty m_CellSize;
        SerializedProperty m_Spacing;
        SerializedProperty m_StartCorner;
        SerializedProperty m_StartAxis;
        SerializedProperty m_ChildAlignment;
        SerializedProperty m_Constraint;
        SerializedProperty m_ConstraintCount;
        SerializedProperty m_OffAxisScaling;
        SerializedProperty m_OffAxisCount;
        SerializedProperty m_OffAxisAspectRatio;

        protected virtual void OnEnable()
        {
            m_Padding = serializedObject.FindProperty("m_Padding");
            m_CellSize = serializedObject.FindProperty("m_CellSize");
            m_Spacing = serializedObject.FindProperty("m_Spacing");
            m_StartCorner = serializedObject.FindProperty("m_StartCorner");
            m_StartAxis = serializedObject.FindProperty("m_StartAxis");
            m_ChildAlignment = serializedObject.FindProperty("m_ChildAlignment");
            m_Constraint = serializedObject.FindProperty("m_Constraint");
            m_ConstraintCount = serializedObject.FindProperty("m_ConstraintCount");
            m_OffAxisScaling = serializedObject.FindProperty("m_OffAxisScaling");
            m_OffAxisCount = serializedObject.FindProperty("m_OffAxisCount");
            m_OffAxisAspectRatio = serializedObject.FindProperty("m_OffAxisAspectRatio");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_Padding, true);
            EditorGUILayout.PropertyField(m_Spacing, true);
            EditorGUILayout.PropertyField(m_StartCorner, true);
            EditorGUILayout.PropertyField(m_StartAxis, true);
            EditorGUILayout.PropertyField(m_ChildAlignment, true);
            EditorGUILayout.PropertyField(m_Constraint, true);
            EditorGUI.indentLevel++;

            if (m_Constraint.enumValueIndex > 0)
            {
                EditorGUILayout.PropertyField(m_ConstraintCount, true);
                EditorGUILayout.PropertyField(m_OffAxisScaling, true);

                if (m_OffAxisScaling.enumValueIndex == 1)
                {
                    EditorGUILayout.PropertyField(m_OffAxisCount, true);
                }
                else if ((m_OffAxisScaling.enumValueIndex == 2))
                {
                    EditorGUILayout.PropertyField(m_OffAxisAspectRatio, true);
                }
            }
            else
            {
                EditorGUILayout.PropertyField(m_CellSize, true);
            }

            EditorGUI.indentLevel--;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
