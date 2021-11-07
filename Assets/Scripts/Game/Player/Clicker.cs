using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Player _player;

    private bool _canClick = true;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canClick)
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider.gameObject.TryGetComponent( out Asteroid asteroid))
            {
                asteroid.DeactivateAsteroid();
            }
            else { return; }

        }

    }
    private void OnEnable()
    {
        _player.EndGameEvent += DeactivateCLick;
    }
    private void OnDisable()
    {
        _player.EndGameEvent -= DeactivateCLick;
    }
    private void DeactivateCLick()
    {
        _canClick = false;
    }
}