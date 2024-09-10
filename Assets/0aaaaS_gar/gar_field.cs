using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Shader))]
public class gar_field : Editor
{
    public override void OnInspectorGUI()
    {
        Shader shader = (Shader)target;

        // ��Ǩ�ͺ��� Shader �� Shader �����ҵ�ͧ���
        if (shader.name == "2D/Sprite-Lit-Default")
        {
            // �ʴ������ž�鹰ҹ�ͧ Shader
            EditorGUILayout.LabelField("Shader Name", shader.name);

            // �� SerializedObject ����Ѻ��äǺ�������������ͧ Shader
            SerializedObject serializedObject = new SerializedObject(shader);

            SerializedProperty color = serializedObject.FindProperty("_Color");
            SerializedProperty mainTex = serializedObject.FindProperty("_MainTex");
            SerializedProperty specColor = serializedObject.FindProperty("_SpecColor");
            SerializedProperty glossiness = serializedObject.FindProperty("_Glossiness");

            EditorGUILayout.PropertyField(color, new GUIContent("Color"));
            EditorGUILayout.PropertyField(mainTex, new GUIContent("Base (RGB)"));
            EditorGUILayout.PropertyField(specColor, new GUIContent("Specular Color"));
            EditorGUILayout.PropertyField(glossiness, new GUIContent("Smoothness"));

            serializedObject.ApplyModifiedProperties();
        }
        else
        {
            // �� Inspector ���Զ������� Shader �����ҵ�ͧ���
            DrawDefaultInspector();
        }
    }
}