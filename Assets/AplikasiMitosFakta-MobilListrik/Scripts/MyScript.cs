using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEditor;
// using ConditionalHideAttribute;


 public class MyScript : MonoBehaviour
 {
     public bool hideBool;
     public bool disableBool;
     public string someString;
     public Color someColor = Color.white;
     public int someNumber = 0;

     [Header("Auto Aim")] public bool EnableAutoAim = false;

     [ConditionalHide("EnableAutoAim", true)] public float Range = 0.0f;
 }
//  [CustomEditor(typeof(MyScript))]
//  public class MyScriptEditor : Editor
//  {
//      override public void OnInspectorGUI()
//      {
//          var myScript = target as MyScript;
 
//          myScript.hideBool = EditorGUILayout.Toggle("Hide Fields", myScript.hideBool);
 
//          using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(myScript.hideBool)))
//          {
//              if (group.visible == false)
//              {
//                  EditorGUI.indentLevel++;
//                  EditorGUILayout.PrefixLabel("Color");
//                  myScript.someColor = EditorGUILayout.ColorField(myScript.someColor);
//                  EditorGUILayout.PrefixLabel("Text");
//                  myScript.someString = EditorGUILayout.TextField(myScript.someString);
//                  EditorGUILayout.PrefixLabel("Number");
//                  myScript.someNumber = EditorGUILayout.IntSlider(myScript.someNumber, 0, 10);
//                  EditorGUI.indentLevel--;
//              }
//          }
 
//          myScript.disableBool = GUILayout.Toggle(myScript.disableBool, "Disable Fields");
 
//          using (new EditorGUI.DisabledScope(myScript.disableBool))
//          {
//              myScript.someColor = EditorGUILayout.ColorField("Color", myScript.someColor);
//              myScript.someString = EditorGUILayout.TextField("Text", myScript.someString);
//              myScript.someNumber = EditorGUILayout.IntField("Number", myScript.someNumber);
//          }
//      }
//  }
