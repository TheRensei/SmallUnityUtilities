using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<State> statesList = new List<State>();
    public State StartingState;
    protected State currentState;

    public void Start()
    {
        SetState(StartingState, null);
    }

    public State GetCurrentState { get { return currentState; } }

    /// <summary>
    /// Switch the currentState to a specific State object
    /// </summary>
    /// <param name="state">
    /// The state object to set as the currentState</param>
    /// <returns>Whether the state was changed</returns>
    public virtual bool SetState(State state, object args)
    {
        bool success = false;
        if (state && state != currentState)
        {
            State oldState = currentState;
            currentState = state;
            if (oldState)
                oldState.StateExit();
            currentState.StateEnter(args);
            success = true;
        }
        return success;
    }

    public void setState(State state, object args)
    {
        SetState(state, args);
    }

    /// <summary>
    /// Switch the currentState to a State of a the given type.
    /// </summary>
    /// <typeparam name="StateType">
    /// The type of state to use for the currentState</typeparam>
    /// <returns>Whether the state was changed</returns>
    public virtual bool SetState<StateType>(object args = null) where StateType : State
    {
        bool success = false;
        //if the state can be found in the list of states 
        //already created, switch to the existing version
        foreach (State state in statesList)
        {
            if (state is StateType)
            {
                success = SetState(state, args);
                return success;
            }
        }
        //if the state is not found in the list,
        //see if it is on the gameobject.
        State stateComponent = GetComponent<StateType>();
        if (stateComponent)
        {
            stateComponent.Initialize(this);
            statesList.Add(stateComponent);
            success = SetState(stateComponent, args);
            return success;
        }
        //if it is not on the gameobject,
        //make a new instance
        State newState = gameObject.AddComponent<StateType>();
        newState.Initialize(this);
        statesList.Add(newState);
        success = SetState(newState, args);

        return success;
    }
}