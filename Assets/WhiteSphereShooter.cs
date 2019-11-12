using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class WhiteSphereShooter : MonoBehaviour, IMixedRealityInputHandler
{

    public Transform WhiteSpherePrefab;



    public void OnEnable()
    {
        CoreServices.InputSystem.RegisterHandler<IMixedRealityInputHandler>(this);
    }

    public void OnDisable()
    {
        CoreServices.InputSystem.UnregisterHandler<IMixedRealityInputHandler>(this);
    }

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

    public void OnInputDown(InputEventData eventData)
    {
        OnAirTap();
    }

    public void OnInputUp(InputEventData eventData)
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnAirTap();
        }
    }

    
}
