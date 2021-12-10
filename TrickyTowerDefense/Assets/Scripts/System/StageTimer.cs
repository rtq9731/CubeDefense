using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTimer : MonoBehaviour
{
    private BtnSkipBreak skipBreakBtn = null;

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
        skipBreakBtn = FindObjectOfType<BtnSkipBreak>();
        _gameManager = GameManager.Instance;
        if(_gameManager.GetData().Round <= 0)
        {
            _isFirstRound = true;
            _isClearRound = true;
        }

        skipBreakBtn.ShowSkipBtn();

        //_onStageEnd += _gameManager.SaveGame;
        _onStageStart += _info.UpdateStageTextOnStartStage;
        _onStageEnd += _info.UpdateStageTextOnEndStage;

        _onStageEnd += skipBreakBtn.ShowSkipBtn;
        _onStageStart += skipBreakBtn.RemoveSkipBtn;
    }

    private void Update()
    {
        _timer += Time.deltaTime * _gameManager.gameSpeed;
        if (_isFirstRound)
        {
            if (_timer >= _readyTime && _isClearRound && _gameManager.GetData().Round <= 0)
            {
                _isClearRound = false;
                _onStageStart();
            }
            else if (_timer >= _readyTime + _stageTime && !_isClearRound)
            {
                _isClearRound = true;
                _gameManager.GetData().Round++;
                _onStageEnd();
            }
            else if (_timer >= (_readyTime * 2) + _stageTime && _isClearRound)
            {
                _isClearRound = false;
                _isFirstRound = false;
                _timer = 0f;
                _onStageStart();
            }
            return;
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

    }

    public void SkipBreak()
    {
        _isClearRound = false;
        _onStageStart();
        _timer = 0f;

        if (_gameManager.GetData().Round <= 0)
        {
            _timer = _readyTime;
        }
    }

    public void SkipStage()
    {
        _timer = _stageTime;
        _gameManager.GetData().Round++;
        _isClearRound = true;
        _onStageEnd();
        _info.UpdateTexts();

        if (_isFirstRound)
        {
            _timer = _readyTime + _stageTime;
        }
    }

}
