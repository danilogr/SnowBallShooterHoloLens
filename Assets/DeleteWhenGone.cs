using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWhenGone : MonoBehaviour
{
    [Tooltip("How far down can it go before getting destroyed")]
    public float maxDistance = 100f;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -maxDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
