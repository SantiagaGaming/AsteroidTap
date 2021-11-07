using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityAction<int> ScoreChangerEvent;
    public UnityAction<int> HpChanger;
    public UnityAction EndGameEvent;

    private int _score;
    private int _hp = 3;

    public void RecountScore(int value)
    {
        _score += value;
        ScoreChangerEvent.Invoke(_score);

    }
    public void RecountHP(int value)
    {
        _hp += value;
        HpChanger.Invoke(_hp);
        if(_hp<=0)
        {
            EndGameEvent.Invoke();
        }
    }
    public int GetScore()
    {
        return _score;
    }

}
