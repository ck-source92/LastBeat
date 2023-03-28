using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Portal : MonoBehaviour
{
    public GameModes.Gamemodes Gamemode;
    public Speeds.Speed Speed;
    public bool Gravity;
    public int State;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.ChangeBehaviourPlayerThroughPortal(Gamemode, Speed, Gravity ? 1 : -1, State);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
