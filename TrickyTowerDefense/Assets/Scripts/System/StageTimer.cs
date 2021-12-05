using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    PanelInfoTexts _info = null;
    GameManager _gameManager = null;

    public Action _onStageStart = () => { };
    public Action _onStageEnd = () => { };

    float _stageTime = 60f;
    float _readyTime = 20f;

    float _timer = 0f;

    bool _isClearRound = false;
    bool _isFirstRound = false;

    public void SetStageTimer(float stageTime, float readyTime)
    {
        _stageTime = stageTime;
        _readyTime = readyTime;
    }

    private void Start()
    {
        _info = FindObjectOfType<PanelInfoTexts>();
        _gameManager = GameManager.Instance;
        if(_gameManager.GetData().Round <= 0)
        {
            _isFirstRound = true;
            _isClearRound = true;
        }

        _onStageEnd += _gameManager.SaveGame;
        _onStageEnd += _info.UpdateStageTextOnEndStage;
        _onStageStart += _info.UpdateStageTextOnStartStage;
    }

    private void Update()
    {
        if(_isFirstRound)
        {
            if (_timer >= _readyTime && _isClearRound && _gameManager.GetData().Round <= 0)
            {
                _isClearRound = false;
                _onStageStart();
            }
            else if (_timer >= _readyTime + _stageTime && !_isClearRound)
            {
                _gameManager.GetData().Round++;
                _isClearRound = true;
                _onStageEnd();
            }
            else if (_timer >= (_readyTime * 2) + _stageTime && _isClearRound)
            {
                _isClearRound = false;
                _isFirstRound = false;
                _onStageStart();
                _timer = 0f;
            }
        }

        if (_timer >= _stageTime && !_isClearRound)
        {
            _gameManager.GetData().Round++;
            _isClearRound = true;
            _onStageEnd();
        }
        else if (_timer >= _stageTime + _readyTime && _isClearRound)
        {
            _isClearRound = false;
            _onStageStart();
            _timer = 0f;
        }

        _timer += Time.deltaTime * _gameManager.gameSpeed;
        Debug.Log(_timer);
    }

}
