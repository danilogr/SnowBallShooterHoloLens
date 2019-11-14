// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!IsInitialized && searchForInstance)
            {
                searchForInstance = false;
                T[] objects = FindObjectsOfType<T>();
                if (objects.Length == 1)
                {

                    instance = objects[0];
                    DontDestroyOnLoad(instance.gameObject.GetParentRoot());
                }
                else if (objects.Length > 1)
                {
                    Debug.LogErrorFormat("Expected exactly 1 {0} but found {1}.", typeof(T).Name, objects.Length);
                }
            }
            return instance;
        }
    }

    private static bool searchForInstance = true;

    public static void AssertIsInitialized()
    {
        Debug.Assert(IsInitialized, string.Format("The {0} singleton has not been initialized.", typeof(T).Name));
    }

    public static bool IsInitialized
    {
        get
        {
            return instance != null;
        }
    }

    public static bool ConfirmInitialized()
    {
        T access = Instance;
        return IsInitialized;
    }

    protected virtual void Awake()
    {
        if (IsInitialized && instance != this)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(this);
            }
            else
            {
                Destroy(this);
            }

            Debug.LogErrorFormat("Trying to instantiate a second instance of singleton class {0}. Additional Instance was destroyed", GetType().Name);
        }
        else if (!IsInitialized)
        {
            instance = (T)this;
            searchForInstance = false;
            DontDestroyOnLoad(gameObject.GetParentRoot());
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            searchForInstance = true;
        }
    }
}
