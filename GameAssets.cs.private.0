using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _I;

    public static GameAssets i
    {
        get
        {
            if (_I == null)
                _I = Instantiate(Resources.Load("GameAssets") as GameObject).GetComponent<GameAssets>();
            return _I;
        }
    }

}
