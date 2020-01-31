using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    // Player transform.
    private Transform _playerPos;

    void Start()
    {
        _playerPos = GameObject.Find("Body").GetComponent<Transform>();
    }

    void Update()
    {

        // Copy the player position to the current camera position;
        if (_playerPos)
        {
            transform.position = new Vector3(_playerPos.transform.position.x, _playerPos.transform.position.y, -10);
        }
    }
}
