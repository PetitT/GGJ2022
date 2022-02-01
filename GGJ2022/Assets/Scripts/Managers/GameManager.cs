using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject Character;
    public GameObject Laser;
    public SpriteRenderer Fade;
    public Button SwapButton;

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
    public TouchInputManager TouchInputManager = new TouchInputManager();
    public TouchMovementManager TouchMovementManager = new TouchMovementManager();

    private bool hasGameStarted;

    private void Awake()
    {
        managers.Add(HealthManager);
        managers.Add(CameraBordermanager);
        managers.Add(CharacterCollisionManager);
        managers.Add(TeamManager);
        managers.Add(TeamDisplayManager);
        managers.Add(CombatManager);
        managers.Add(EnemySpawnManager);
        managers.Add(WallsSpawnManager);
        managers.Add(ScoreManager);

#if !UNITY_ANDROID
        managers.Add(MovementManager);
        managers.Add(InputManager);
#else
        managers.Add(TouchMovementManager);
        managers.Add(TouchInputManager);
#endif

        managers.ForEach(t => t.OnAwake());

        HealthManager.onDeath += EndGame;
        SwapButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        HealthManager.onDeath -= EndGame;
    }

    private void Start()
    {
        StartBeginAnimation();
    }

    private void StartGame()
    {
        managers.ForEach(t => t.OnBegin());
        SwapButton.gameObject.SetActive(true);
        hasGameStarted = true;
    }

    private void Update()
    {
        if (hasGameStarted)
        {
            managers.ForEach(t => t.OnUpdate());
        }
    }

    private void EndGame()
    {
        managers.Remove(InputManager);
        managers.Remove(CombatManager);
        Character.SetActive(false);
        Laser.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartBeginAnimation()
    {
        Fade.color = new Color(Fade.color.r, Fade.color.g, Fade.color.b, 1);
        Fade.DOColor(new Color(Fade.color.r, Fade.color.g, Fade.color.b, 0), 2f);
        Character.GetComponent<TrailRenderer>().Clear();
        Character.GetComponent<TrailRenderer>().enabled = false;
        Character.GetComponent<TrailRenderer>().enabled = true;

        Character.transform.position = new Vector2(0, -7);
        Character.transform.DOMoveY(0, 3).OnComplete(StartGame);
    }

}
