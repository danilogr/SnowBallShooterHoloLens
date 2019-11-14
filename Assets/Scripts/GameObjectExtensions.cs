 // Update is calle// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extension methods for Unity's GameObject class
/// </summary>
public static class GameObjectExtensions
{


    /// <summary>
    /// Gets the GameObject's root Parent object.
    /// </summary>
    /// <param name="child">The GameObject we're trying to find the root parent for.</param>
    /// <returns>The Root parent GameObject.</returns>
    public static GameObject GetParentRoot(this GameObject child)
    {
        if (child.transform.parent == null)
        {
            return child;
        }
        else
        {
            return GetParentRoot(child.transform.parent.gameObject);
        }
    }
}
