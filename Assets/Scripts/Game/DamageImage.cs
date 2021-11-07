using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageImage : MonoBehaviour
{
    [SerializeField] private GameObject _damageImage;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }


    private IEnumerator StartFlickCo()
    {
        _damageImage.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _damageImage.SetActive(false);

    }
    private void StartFlick(int value)
    {
        StartCoroutine(StartFlickCo());
    }
    private void OnEnable()
    {
        _player.HpChanger += StartFlick;
    }
    private void OnDisable()
    {
        _player.HpChanger -= StartFlick;
    }


}
