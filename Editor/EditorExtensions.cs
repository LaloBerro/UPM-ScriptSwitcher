using UnityEditor;
using UnityEngine;

namespace ScriptSwitchers.Core
{
    public static class EditorExtensions
    {
        public static bool DrawDefaultInspectorWithoutScriptField(this Editor Inspector)
        {
            EditorGUI.BeginChangeCheck();

            GUILayout.BeginVertical("Box");

            MonoScript script = (MonoScript)Inspector.serializedObject.FindProperty("m_Script").objectReferenceValue;
            script = EditorGUILayout.ObjectField("Script", script, typeof(MonoScript), false) as MonoScript;

            GUILayout.EndVertical();

            GUILayout.Space(3);

            Inspector.serializedObject.Update();

            SerializedProperty Iterator = Inspector.serializedObject.GetIterator();

            Iterator.NextVisible(true);

            while (Iterator.NextVisible(false))
            {
                EditorGUILayout.PropertyField(Iterator, true);
            }

            Undo.RecordObject(script, "BackScript");

            Inspector.serializedObject.FindProperty("m_Script").objectReferenceValue = script;

            Inspector.serializedObject.ApplyModifiedProperties();

            return (EditorGUI.EndChangeCheck());
        }
    }
}