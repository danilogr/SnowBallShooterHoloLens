using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class GameStateChange : UnityEvent<GameState.States> { }
public class GameState : Singleton<GameState>
{

    public GameStateChange onGameStateChange;

    public enum States
    {
        Setup,
        Playing,
        GameOver
    }

    private void Start()
    {
        _currentState = States.Setup;
        if (onGameStateChange != null)
            onGameStateChange.Invoke(_currentState);
    }

    private States _currentState;
    public States currentState
    {
        set
        {
            if (value != _currentState)
            {
                _currentState = value;
                if (onGameStateChange != null)
                    onGameStateChange.Invoke(_currentState);
            }
        }

        get
        {
            return _currentState;
        }


    }

}
