using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Portal : MonoBehaviour
{
    PlayerController controller;

    public GameModes.Gamemodes Gamemode;
    public Speeds.Speed Speed;
    public bool Gravity;
    public int State;

    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (controller != null)
            {
                controller.ChangeBehaviourPlayerThroughPortal(Gamemode, Speed, Gravity ? 1 : -1, State);
            }
            else
            {
                Debug.Log("player missing");
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
