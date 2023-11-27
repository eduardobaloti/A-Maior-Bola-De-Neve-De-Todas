using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : Singleton<Menu>
{
    public TransitionSettings transition;

    void Start()
    {
        
    }

    public void LoadGame()
    {
        TransitionManager.Instance().Transition(1, transition, 0);
    }

    public void LoadGameInd(int ind)
    {
        TransitionManager.Instance().Transition(ind, transition, 0);
    }


}
