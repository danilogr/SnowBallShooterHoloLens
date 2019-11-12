using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class WhiteSphereShooter : MonoBehaviour
{

    public Transform WhiteSpherePrefab;

    public void OnAirTap()
    {
        Transform newSphereTransform = Object.Instantiate(WhiteSpherePrefab);
        newSphereTransform.position = Camera.main.transform.position;
        Rigidbody r = newSphereTransform.GetComponent<Rigidbody>();

        if (r != null)
        {
            r.velocity = CoreServices.InputSystem.GazeProvider.GazeDirection.normalized * 10.0f;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnAirTap();
        }
    }

    
}
