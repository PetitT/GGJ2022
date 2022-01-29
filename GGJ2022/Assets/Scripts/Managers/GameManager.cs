using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject Character;
    public GameObject Laser;

    private GameData data;
    public GameData Data => data ??= GameData.GetGameData();

    private List<BaseManager> managers = new List<BaseManager>();
    public InputManager InputManager = new InputManager();
    public HealthManager HealthManager = new HealthManager();
    public CameraBorderManager CameraBordermanager = new CameraBorderManager();
    public MovementManager MovementManager = new MovementManager();
    public TeamManager TeamManager = new TeamManager();
    public CharacterCollisionManager CharacterCollisionManager = new CharacterCollisionManager();
    public TeamDisplayManager TeamDisplayManager = new TeamDisplayManager();
    public CombatManager CombatManager = new CombatManager();

    private void Awake()
    {
        managers.Add(InputManager);
        managers.Add(HealthManager);
        managers.Add(CameraBordermanager);
        managers.Add(MovementManager);
        managers.Add(CharacterCollisionManager);
        managers.Add(TeamManager);
        managers.Add(TeamDisplayManager);
        managers.Add(CombatManager);

        managers.ForEach(t => t.OnAwake());
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
