
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public sealed class GameCycle : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private GameState _mainState;
    [SerializeField, ReadOnly]
    private GameSubState _subState;

    //Публичные поля для проверки текущего состояния из других классов
    public GameState MainState { get { return _mainState; } }
    public GameSubState SubState { get { return _subState; } }

    #region INIT LISTENERS
    private List<IGameListener> _gameListeners = new();
    private List<IEventListener> _eventListeners = new();
    private List<IDayListener> _dayListeners = new();

    private List<ITickable> _tickableListeners = new();

    private List<IGameTickable> _gameTickableListeners = new();
    private List<IGameFixedTickable> _gameFixedTickableListeners = new();
    private List<IGameLateTickable> _gameLateTickableListeners = new();

    private List<IEventTickable> _gameEventTickableListeners = new();
    private List<IEventFixedTickable> _gameEventFixedTickableListeners = new();
    private List<IEventLateTickable> _gameEventLateTickableListeners = new();

    private List<IDayOneTickable> _dayOneTickableListeners = new();
    private List<IDayOneFixedTickable> _dayOneFixedTickableListeners = new();
    private List<IDayOneLateTickable> _dayOneLateTickableListeners = new();

    private List<IDayTwoTickable> _dayTwoTickableListeners = new();
    private List<IDayTwoFixedTickable> _dayTwoFixedTickableListeners = new();
    private List<IDayTwoLateTickable> _dayTwoLateTickableListeners = new();

    private List<IDayThreeTickable> _dayThreeTickableListeners = new();
    private List<IDayThreeFixedTickable> _dayThreeFixedTickableListeners = new();
    private List<IDayThreeLateTickable> _dayThreeLateTickableListeners = new();

    #endregion

    public static GameCycle Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
        _mainState = GameState.OFF;
        _subState = GameSubState.NONE;
    }

    //Это знать не нужно.
    #region ADD AND REMOVE LISTENERS
    public void AddListener(IListener listener)
    {
        if (listener is IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);
        }
        if (listener is IEventListener eventListener)
        {
            _eventListeners.Add(eventListener);
        }
        if (listener is IDayListener dayListener)
        {
            _dayListeners.Add(dayListener);
        }
    }

    public void RemoveListener(IListener listener)
    {
        if (listener is IGameListener gameListener)
        {
            _gameListeners.Remove(gameListener);
        }
        if (listener is IEventListener eventListener)
        {
            _eventListeners.Remove(eventListener);
        }
        if (listener is IDayListener dayListener)
        {
            _dayListeners.Remove(dayListener);
        }
    }

    public void AddTickableListener(ITickable listener)
    {
        if (listener is IGameTickable gameTickableListener)
        {
            _gameTickableListeners.Add(gameTickableListener);
        }
        if (listener is IGameFixedTickable gameFixedTickableListener)
        {
            _gameFixedTickableListeners.Add(gameFixedTickableListener);
        }
        if (listener is IGameLateTickable gameLateTickableListener)
        {
            _gameLateTickableListeners.Add(gameLateTickableListener);
        }

        if (listener is IEventTickable gameEventTickableListener)
        {
            _gameEventTickableListeners.Add(gameEventTickableListener);
        }
        if (listener is IEventFixedTickable gameEventFixedTickableListener)
        {
            _gameEventFixedTickableListeners.Add(gameEventFixedTickableListener);
        }
        if (listener is IEventLateTickable gameEventLateTickableListener)
        {
            _gameEventLateTickableListeners.Add(gameEventLateTickableListener);
        }

        if (listener is IDayOneTickable dayOneTickableListener)
        {
            _dayOneTickableListeners.Add(dayOneTickableListener);
        }
        if (listener is IDayOneFixedTickable dayOneFixedTickableListener)
        {
            _dayOneFixedTickableListeners.Add(dayOneFixedTickableListener);
        }
        if (listener is IDayOneLateTickable dayOneLateTickableListener)
        {
            _dayOneLateTickableListeners.Add(dayOneLateTickableListener);
        }

        if (listener is IDayTwoTickable dayTwoTickableListener)
        {
            _dayTwoTickableListeners.Add(dayTwoTickableListener);
        }
        if (listener is IDayTwoFixedTickable dayTwoFixedTickableListener)
        {
            _dayTwoFixedTickableListeners.Add(dayTwoFixedTickableListener);
        }
        if (listener is IDayTwoLateTickable dayTwoLateTickableListener)
        {
            _dayTwoLateTickableListeners.Add(dayTwoLateTickableListener);
        }

        if (listener is IDayThreeTickable dayThreeTickableListener)
        {
            _dayThreeTickableListeners.Add(dayThreeTickableListener);
        }
        if (listener is IDayThreeFixedTickable dayThreeFixedTickableListener)
        {
            _dayThreeFixedTickableListeners.Add(dayThreeFixedTickableListener);
        }
        if (listener is IDayThreeLateTickable dayThreeLateTickableListener)
        {
            _dayThreeLateTickableListeners.Add(dayThreeLateTickableListener);
        }


    }

    public void RemoveTickableListener(ITickable listener)
    {
        if (listener is IGameTickable gameTickableListener)
        {
            _gameTickableListeners.Remove(gameTickableListener);
        }
        if (listener is IGameFixedTickable gameFixedTickableListener)
        {
            _gameFixedTickableListeners.Remove(gameFixedTickableListener);
        }
        if (listener is IGameLateTickable gameLateTickableListener)
        {
            _gameLateTickableListeners.Remove(gameLateTickableListener);
        }

        if (listener is IEventTickable gameEventTickableListener)
        {
            _gameEventTickableListeners.Remove(gameEventTickableListener);
        }
        if (listener is IEventFixedTickable gameEventFixedTickableListener)
        {
            _gameEventFixedTickableListeners.Remove(gameEventFixedTickableListener);
        }
        if (listener is IEventLateTickable gameEventLateTickableListener)
        {
            _gameEventLateTickableListeners.Remove(gameEventLateTickableListener);
        }

        if (listener is IDayOneTickable dayOneTickableListener)
        {
            _dayOneTickableListeners.Remove(dayOneTickableListener);
        }
        if (listener is IDayOneFixedTickable dayOneFixedTickableListener)
        {
            _dayOneFixedTickableListeners.Remove(dayOneFixedTickableListener);
        }
        if (listener is IDayOneLateTickable dayOneLateTickableListener)
        {
            _dayOneLateTickableListeners.Remove(dayOneLateTickableListener);
        }

        if (listener is IDayTwoTickable dayTwoTickableListener)
        {
            _dayTwoTickableListeners.Remove(dayTwoTickableListener);
        }
        if (listener is IDayTwoFixedTickable dayTwoFixedTickableListener)
        {
            _dayTwoFixedTickableListeners.Remove(dayTwoFixedTickableListener);
        }
        if (listener is IDayTwoLateTickable dayTwoLateTickableListener)
        {
            _dayTwoLateTickableListeners.Remove(dayTwoLateTickableListener);
        }

        if (listener is IDayThreeTickable dayThreeTickableListener)
        {
            _dayThreeTickableListeners.Remove(dayThreeTickableListener);
        }
        if (listener is IDayThreeFixedTickable dayThreeFixedTickableListener)
        {
            _dayThreeFixedTickableListeners.Remove(dayThreeFixedTickableListener);
        }
        if (listener is IDayThreeLateTickable dayThreeLateTickableListener)
        {
            _dayThreeLateTickableListeners.Remove(dayThreeLateTickableListener);
        }
    }
    #endregion

    /*
      Функции вызова игровых событий
      Пример вызова из другого класса:
      GameCycle.Instance.StartGame();
    */
    #region GAME
    /// <summary>
    /// Старт игры. Когда игра загрузила все объекты и ресурсы и начинается игровой процесс.
    /// Состояние = PLAY;
    /// </summary>
    [Button("Start Game")]
    public void StartGame()
    {
        if (_mainState == GameState.OFF)
        {
            _mainState = GameState.PLAY;

            foreach (var it in _gameListeners)
            {
                if (it is IGameStartListener listener)
                {
                    listener.OnGameStart();
                } 
            }
        }
    }

    /// <summary>
    /// Когда во время игрового процесса нужно вызвать паузу.
    /// Состояние = PAUSE;
    /// </summary>
    [Button("Pause Game")]
    public void PauseGame()
    {
        if (_mainState == GameState.PLAY)
        {
            _mainState = GameState.PAUSE;

            foreach (var it in _gameListeners)
            {
                if (it is IGamePauseListener listener)
                {
                    listener.OnGamePause();
                }
            }
        }
    }
    /// <summary>
    /// Когда во время паузы нужно продолжить игру.
    /// Состояние = PLAY;
    /// </summary>
    [Button("Resume Game")]
    public void ResumeGame()
    {
        if (_mainState == GameState.PAUSE)
        {
            _mainState = GameState.PLAY;

            foreach (var it in _gameListeners)
            {
                if (it is IGameResumeListener listener)
                {
                    listener.OnGameResume();
                }
            }
        }
    }
    /// <summary>
    /// Когда нужно полностью завершить игровой процесс.
    /// Состояние = FINISH;
    /// </summary>
    [Button("Finish Game")]
    public void FinishGame()
    {
        if (_mainState == GameState.PLAY)
        {
            _mainState = GameState.FINISH;

            foreach (var it in _gameListeners)
            {
                if (it is IGameFinishListener listener)
                {
                    listener.OnGameFinish();
                }
            }
        }
    }
    #endregion

    #region EVENT
    /// <summary>
    /// Когда начинается любой особый ивент (например QTE).
    /// Состояние = EVENT;
    /// </summary>
    [Button("Start Event (NOT work)")]
    public void StartEvent(EventType eventType) //+номер сценария?
    {
        if (_mainState == GameState.PLAY)
        {
            _mainState = GameState.EVENT;

            foreach (var it in _eventListeners)
            {
                if (it is IEventStartListener listener)
                {
                    listener.OnEventStart(eventType);
                }
            }
        }
    }
    /// <summary>
    /// Когда заканчивается любой особый ивент (например QTE).
    /// Состояние = PLAY;
    /// </summary>
    [Button("Finish Event")]
    public void FinishEvent()
    {
        if (_mainState == GameState.EVENT)
        {
            _mainState = GameState.PLAY;

            foreach (var it in _eventListeners)
            {
                if (it is IEventFinishListener listener)
                {
                    listener.OnEventFinish();
                }
            }
        }
    }
    #endregion

    #region DAYS
    /// <summary>
    /// Когда во время игрового процесса нужно вызвать День 1.
    /// Саб-состояние = DAY ONE;
    /// </summary>
    [Button("Start Day One")]
    public void StartDayOne()
    {
        if (_mainState == GameState.PLAY && _subState != GameSubState.DAY_ONE)
        {
            _subState = GameSubState.DAY_ONE;

            foreach (var it in _dayListeners)
            {
                if (it is IDayOneStartListener listener)
                {
                    listener.OnDayOneStart();
                }
            }
        }
    }
    /// <summary>
    /// Когда во время игрового процесса нужно вызвать День 2.
    /// Саб-состояние = DAY TWO;
    /// </summary>
    [Button("Start Day Two")]
    public void StartDayTwo()
    {
        if (_mainState == GameState.PLAY && _subState != GameSubState.DAY_TWO)
        {
            _subState = GameSubState.DAY_TWO;

            foreach (var it in _dayListeners)
            {
                if (it is IDayTwoStartListener listener)
                {
                    listener.OnDayTwoStart();
                }
            }
        }
    }
    /// <summary>
    /// Когда во время игрового процесса нужно вызвать День 3.
    /// Саб-состояние = DAY THREE;
    /// </summary>
    [Button("Start Day Three")]
    public void StartDayThree()
    {
        if (_mainState == GameState.PLAY && _subState != GameSubState.DAY_THREE)
        {
            _subState = GameSubState.DAY_THREE;

            foreach (var it in _dayListeners)
            {
                if (it is IDayThreeStartListener listener)
                {
                    listener.OnDayThreeStart();
                }
            }
        }
    }
    #endregion

    //Это знать не нужно.
    #region UPDATES
    private void Update()
    {
        float time = Time.deltaTime;

        if (_mainState == GameState.PLAY)
        {
            foreach (IGameTickable gameTickable in _gameTickableListeners)
            {
                gameTickable.Tick(time);
            }
            if (_subState == GameSubState.DAY_ONE)
            {
                foreach (IDayOneTickable dayOneTickable in _dayOneTickableListeners)
                {
                    dayOneTickable.Tick(time);
                }
            }
            else if (_subState == GameSubState.DAY_TWO)
            {
                foreach (IDayTwoTickable dayTwoTickable in _dayTwoTickableListeners)
                {
                    dayTwoTickable.Tick(time);
                }
            }
            else if (_subState == GameSubState.DAY_THREE)
            {
                foreach (IDayThreeTickable dayThreeTickable in _dayThreeTickableListeners)
                {
                    dayThreeTickable.Tick(time);
                }
            }
        }
        else if (_mainState == GameState.EVENT)
        {
            foreach (IEventTickable eventTickable in _gameEventTickableListeners)
            {
                eventTickable.Tick(time);
            }
        }

    }

    private void FixedUpdate()
    {
        float time = Time.fixedDeltaTime;

        if (_mainState == GameState.PLAY)
        {
            foreach (IGameFixedTickable gameTickable in _gameFixedTickableListeners)
            {
                gameTickable.FixedTick(time);
            }

            if (_subState == GameSubState.DAY_ONE)
            {
                foreach (IDayOneFixedTickable dayOneTickable in _dayOneFixedTickableListeners)
                {
                    dayOneTickable.FixedTick(time);
                }
            }
            else if (_subState == GameSubState.DAY_TWO)
            {
                foreach (IDayTwoFixedTickable dayTwoTickable in _dayTwoFixedTickableListeners)
                {
                    dayTwoTickable.FixedTick(time);
                }
            }
            else if (_subState == GameSubState.DAY_THREE)
            {
                foreach (IDayThreeFixedTickable dayThreeTickable in _dayThreeFixedTickableListeners)
                {
                    dayThreeTickable.FixedTick(time);
                }
            }
        }
        else if (_mainState == GameState.EVENT)
        {
            foreach (IEventFixedTickable eventTickable in _gameEventFixedTickableListeners)
            {
                eventTickable.FixedTick(time);
            }
        }
    }

    private void LateUpdate()
    {
        float time = Time.deltaTime;

        if (_mainState == GameState.PLAY)
        {
            foreach (IGameLateTickable gameTickable in _gameLateTickableListeners)
            {
                gameTickable.LateTick(time);
            }

            if (_subState == GameSubState.DAY_ONE)
            {
                foreach (IDayOneLateTickable dayOneTickable in _dayOneLateTickableListeners)
                {
                    dayOneTickable.LateTick(time);
                }
            }
            else if (_subState == GameSubState.DAY_TWO)
            {
                foreach (IDayTwoLateTickable dayTwoTickable in _dayTwoLateTickableListeners)
                {
                    dayTwoTickable.LateTick(time);
                }
            }
            else if (_subState == GameSubState.DAY_THREE)
            {
                foreach (IDayThreeLateTickable dayThreeTickable in _dayThreeLateTickableListeners)
                {
                    dayThreeTickable.LateTick(time);
                }
            }
        }
        else if (_mainState == GameState.EVENT)
        {
            foreach (IEventLateTickable eventTickable in _gameEventLateTickableListeners)
            {
                eventTickable.LateTick(time);
            }
        }
    }
    #endregion


    #region DEBUG
    [Button("Start HeartBeat Event")]
    public void StartHeartBeatEvent()
    {
        StartEvent(EventType.HEARTH_BEAT);
    }
    #endregion

    }
