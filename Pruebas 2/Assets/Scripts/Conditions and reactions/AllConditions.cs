using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllConditions : ResettableScriptableObject {

    public Condition[] conditions;

    private static AllConditions instance;

    private const string loadpath = "AllConditions";

    public static AllConditions Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<AllConditions>();
            if (!instance)
                instance = Resources.Load<AllConditions>(loadpath);
            if (!instance)
                Debug.LogError("AllConditions has not been created yet. Go to Assets Create Allconditions. ");
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public override void Reset()
    {
        if(conditions == null)
        {
            return;
        }
        for(int i = 0; i< conditions.Length; i++)
        {
            conditions[i].satisfied = false;
        }
    }

    public static bool CheckCondition (Condition requiredCondition)
    {
        Condition[] allConditions = Instance.conditions;
        Condition globalConditions = null;

        if(allConditions != null && allConditions[0] != null)
        {
            for(int i = 0; i < allConditions.Length; i++)
            {
                if (allConditions[i].hash == requiredCondition.hash)
                    globalConditions = allConditions[i];
            }
        }
        if (!globalConditions)
            return false;

        return globalConditions.satisfied == requiredCondition.satisfied;
    }
}
