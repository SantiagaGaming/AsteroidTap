using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpeedChanger : MonoBehaviour
{

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        ChangeAsteroidSpeed();

    }
    public float ChangeAsteroidSpeed()
    {
        if (_timer < 10)
        {
            return 2;
        }
        else if (_timer < 20)
            return 3;
        else if (_timer < 30)
            return 4;
        else if (_timer < 40)
            return 5;
        else if (_timer < 50)
            return 6;
        else if (_timer < 60)
            return 7;
        else return 9;
    }
}
