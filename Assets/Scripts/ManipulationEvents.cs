using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationEvents : MonoBehaviour
{

    public Transform capsule;
    Color restoreColor;


    public void OnTouchStart(HandTrackingInputEventData e)
    {
        Debug.Log("Touched");
    }

    public void OnDragStart(ManipulationEventData e)
    {
        restoreColor = capsule.GetComponent<MeshRenderer>().material.color;
        capsule.GetComponent<MeshRenderer>().material.color = Color.yellow;

        Debug.Log("Started!");
    }

    public void OnDragEnd(ManipulationEventData e)
    {
        capsule.GetComponent<MeshRenderer>().material.color = restoreColor;
        Debug.Log("Ended!!");
    }


}
