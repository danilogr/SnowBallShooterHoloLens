using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChangeHandler : MonoBehaviour
{
    protected virtual void OnGameStateChange(GameState.States currentState)
    {
        Debug.LogError(gameObject.name + " did not implement OnGameStateChange");
    }

    private void OnEnable()
    {
        GameState.Instance.onGameStateChange.AddListener(OnGameStateChange);
    }

    private void OnDisable()
    {
        GameState.Instance.onGameStateChange.RemoveListener(OnGameStateChange);
    }

}
