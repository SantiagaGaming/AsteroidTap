using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    private AsteroidSpeedChanger _asteroidSpeedChanger;

    private void Start()
    {
        _asteroidSpeedChanger = FindObjectOfType<AsteroidSpeedChanger>();
    }
    private void Update()
    {
        transform.Translate(Vector3.down * _asteroidSpeedChanger.ChangeAsteroidSpeed() * Time.deltaTime);
    }

}
