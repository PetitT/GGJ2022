using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject Character;
    public GameObject Laser;

    private GameData data;
    public GameData Data => data ??= GameData.GetGameData();

    private FeedbackData _feedbackData;
    public FeedbackData feedbackData => _feedbackData ??= FeedbackData.GetFeedbackData();

    private List<BaseManager> managers = new List<BaseManager>();
    public InputManager InputManager = new InputManager();
    public HealthManager HealthManager = new HealthManager();
    public CameraBorderManager CameraBordermanager = new CameraBorderManager();
    public MovementManager MovementManager = new MovementManager();
    public TeamManager TeamManager = new TeamManager();
    public CharacterCollisionManager CharacterCollisionManager = new CharacterCollisionManager();
    public TeamDisplayManager TeamDisplayManager = new TeamDisplayManager();
    public CombatManager CombatManager = new CombatManager();
    public EnemySpawnManager EnemySpawnManager = new EnemySpawnManager();
    public WallsSpawnManager WallsSpawnManager = new WallsSpawnManager();
    public ScoreManager ScoreManager = new ScoreManager();

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
        managers.Add(EnemySpawnManager);
        managers.Add(WallsSpawnManager);
        managers.Add(ScoreManager);

        managers.ForEach(t => t.OnAwake());

        HealthManager.onDeath += EndGame;
    }

    private void OnDestroy()
    {
        HealthManager.onDeath -= EndGame;
    }

    private void Start()
    {
        managers.ForEach(t => t.OnBegin());
    }

    private void Update()
    {
        managers.ForEach(t => t.OnUpdate());
    }

    private async void EndGame()
    {
        managers.Remove(InputManager);
        managers.Remove(CombatManager);
        Character.SetActive(false);
        Laser.SetActive(false);
        await Task.Delay(2000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
