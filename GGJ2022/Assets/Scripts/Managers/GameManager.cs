using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject Character;

    private GameData data;
    public GameData Data => data ??= GameData.GetGameData();

    private List<BaseManager> managers = new List<BaseManager>();
    public InputManager InputManager = new InputManager();
    public CameraBorderManager CameraBordermanager = new CameraBorderManager();
    public MovementManager MovementManager = new MovementManager();

    private void Awake()
    {
        managers.Add(InputManager);
        managers.Add(CameraBordermanager);
        managers.Add(MovementManager);
    }

    private void Start()
    {
        managers.ForEach(t => t.OnBegin());
    }

    private void Update()
    {
        managers.ForEach(t => t.OnUpdate());
    }

}
