using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackActivate : MonoBehaviour
{
    private GameObject _player;
    private Quaternion _playerStartRotation;
    private bool _trigger;

    private void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _playerStartRotation = _player.transform.rotation;
        _trigger = true;
    }

    public void ButtonActivateJetPack()
    {
        if(_trigger)
        {
            _player.GetComponent<Player>().enabled = false;
            _player.GetComponent<Controller2D>().enabled = false;
            _player.GetComponent<JetPack>().enabled = true;
            _player.GetComponent<JetPack>().CheckMouseClamp = false;

            _trigger = false;
        }
        else
        {
            _player.GetComponent<Player>().enabled = true;
            _player.GetComponent<Controller2D>().enabled = true;
            _player.GetComponent<JetPack>().enabled = false;
            _player.transform.rotation = _playerStartRotation;

            _trigger = true;
        }
    }
}
