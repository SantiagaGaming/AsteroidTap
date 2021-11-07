using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private SoundListener _soundListener;

    private int _asteroidScore = 25;
    private int _damage = -1;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _soundListener = FindObjectOfType<SoundListener>();
        _player = FindObjectOfType<Player>();

    }
    public void DeactivateAsteroid()
    {
        StartCoroutine(Deactivator());
    }
    private IEnumerator Deactivator ()
    {
        _player.RecountScore(_asteroidScore);
        _soundListener.PlayBangSound();
        _animator.SetBool(Helper.ASTEROID_DIE, true);
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Damage damage))
        {
            _player.RecountHP(_damage);
            _soundListener.PlayFailSound();
            gameObject.SetActive(false);

        }
    }
    public void ChangeScore()
    {
        _asteroidScore = Random.Range(5, 35);
    }
}
