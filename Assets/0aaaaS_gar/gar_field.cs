using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Shader))]
public class gar_field : Editor
{
    public override void OnInspectorGUI()
    {
        Shader shader = (Shader)target;

        // ตรวจสอบว่า Shader เป็น Shader ที่เราต้องการ
        if (shader.name == "2D/Sprite-Lit-Default")
        {
            // แสดงข้อมูลพื้นฐานของ Shader
            EditorGUILayout.LabelField("Shader Name", shader.name);

            // ใช้ SerializedObject สำหรับการควบคุมพารามิเตอร์ของ Shader
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
            // ใช้ Inspector ปกติถ้าไม่ใช่ Shader ที่เราต้องการ
            DrawDefaultInspector();
        }
    }
}