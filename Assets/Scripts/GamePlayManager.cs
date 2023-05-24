using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    private static GamePlayManager _instance = null;
    public static GamePlayManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindFirstObjectByType<GamePlayManager>();

            }

            return _instance;
        }

    }


    public List<int> reslist;
}
