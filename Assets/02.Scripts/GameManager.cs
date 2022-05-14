using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public PartyController _partyController { get; set; }
    public JoyStick _joyStick { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        _partyController = FindObjectOfType<PartyController>();
        _joyStick = FindObjectOfType<JoyStick>();
    }
}
