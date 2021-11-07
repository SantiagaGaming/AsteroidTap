using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private float _speed = 2f;
    private float _minYposition = -13.1f;
    private float _maxYposition = 18f;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        CheckYposition();
    }
    private void CheckYposition()
    {
        if (transform.position.y < _minYposition)
        {
            transform.position = new Vector2(transform.position.x, _maxYposition);
        }
    }
}
