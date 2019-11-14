using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSnowBallChangeState : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snowball"))
        {
            if (GameState.Instance.currentState != GameState.States.GameOver)
                GameState.Instance.currentState++;
            else
                GameState.Instance.currentState = GameState.States.Setup;


            Object.Destroy(other.gameObject);

            Debug.Log("Snowballed!");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
