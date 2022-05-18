using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public PlayerController _playerController { get; set; }

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();

        if (_instance == null)
            _instance = this;
    }

}
