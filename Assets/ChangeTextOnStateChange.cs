using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextOnStateChange : GameStateChangeHandler
{
    protected override void OnGameStateChange(GameState.States currentState)
    {
        GetComponent<TextMesh>().text = currentState.ToString();
        //Debug.Log(" State changed!! ");
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
