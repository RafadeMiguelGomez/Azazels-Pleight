using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class EditorWithSubEditors<TEditor, TTarget>: Editor
    where TEditor : Editor
    where TTarget : Object
{

    protected TEditor[] subEditors;

    protected void CheckAndCreateSubEditors(TTarget[] subEditorTargets)
    {
        if (subEditors != null && subEditors.Length == subEditorTargets.Length)
        {
            return;
        }
        CleanupEditors();
        subEditors = new TEditor[subEditors.Length];
        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i] = CreateEditor(subEditorTargets[i]) as TEditor;
            SubEditorSetip(subEditors[i]);
        }
    }

    protected void CleanupEditors()
    {
        if(subEditors == null)
        {
            return;
        }
        for(int i = 0; i< subEditors.Length; i++)
        {
            DestroyImmediate(subEditors[i]);
        }
        subEditors = null;
    }

    protected abstract void SubEditorSetip(TEditor editor);

}
