using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ConditionCollection))]
public class ConditionCollectionEditor : EditorWithSubEditors<ConditionEditor,Condition> {

    public SerializedProperty collectionsProperty;


    private SerializedProperty descriptionProperty;
    private SerializedProperty conditionsProperty;
    private SerializedProperty reactionCollectionProperty;
    private ConditionCollection conditionCollection;

    private const float conditionButtonWidth = 30f;
    private const float colectionButtonWidth = 125f;
    private const string conditionCollectionPropDescriptionName = "description";
    private const string conditionCollectionPropRequiredConditionsName = "requieredConditions";
    private const string conditionCollectionPropReactionCollectionName = "reactionCollection";

    private void OnEnable()
    {
        if(target == null)
        {
            DestroyImmediate(this);
            return;
        }
        descriptionProperty = serializedObject.FindProperty(conditionCollectionPropDescriptionName);
        conditionsProperty = serializedObject.FindProperty(conditionCollectionPropRequiredConditionsName);
        descriptionProperty = serializedObject.FindProperty(conditionCollectionPropDescriptionName);
        reactionCollectionProperty = serializedObject.FindProperty(conditionCollectionPropReactionCollectionName);

        conditionCollection = (ConditionCollection)target;
        CheckAndCreateSubEditors(conditionCollection.requiredConditions);
    }

    private void OnDisable()
    {
        CleanupEditors();
    }

    protected override void SubEditorSetip (ConditionEditor editor)
    {
        editor.editorType = ConditionEditor.EditorType.ConditionCollection;
        editor.conditionsProperty = conditionsProperty;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //CheckAndCreateSubEditors();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        EditorGUILayout.BeginHorizontal();

        descriptionProperty.isExpanded = EditorGUILayout.Foldout(descriptionProperty.isExpanded, descriptionProperty.stringValue);

        //if(GUILayout.Button("Remove Collection", GUILayout.Width(collectionButtonWidth)))

        EditorGUILayout.EndHorizontal();

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }

    private void ExpandedGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.Space();
        float space = EditorGUIUtility.currentViewWidth / 3f;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Condition", GUILayout.Width(space));
        EditorGUILayout.LabelField("Satisfied", GUILayout.Width(space));
        EditorGUILayout.LabelField("Add/Remove", GUILayout.Width(space));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        for (int i = 0; i < subEditors.Length; i++)
        {
            //subEditors[i].OnIspectorGUI();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("+", GUILayout.Width(conditionButtonWidth)))
        {
            Condition newCondition = ConditionEditor.CreateCondition();
            //conditionsProperty.AddToObjectArray(newCondition);
        }
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(reactionCollectionProperty);
    }

    public static ConditionCollection CreateConditionCollection()
    {
        ConditionCollection newConditionCollection = CreateInstance<ConditionCollection>();
        return newConditionCollection;

    }

}
