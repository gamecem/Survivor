using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStateMachine : StateMachine
{
    [field:SerializeField]
    public EnemySO EnemyData { get; private set; }

    [field: SerializeField]
    public EnemyHealth Health { get; private set; }

    [field: SerializeField]
    public PlayerHealth Player { get; private set; }

    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField]
    public CharacterController Controller { get; private set; }

    [field: SerializeField]
    public ForceReceiver ForceReceiver { get; private set; }

    [field: SerializeField]
    public Image HealthBar { get; private set; }

    [field: SerializeField]
    public GameObject DieParticle { get; private set; }

    [field: SerializeField]
    public GameObject ExperiencePointPrefab { get; private set; }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag(nameof(Player)).GetComponent<PlayerHealth>();
        //Agent.updatePosition = false;
        //Agent.updateRotation = false;
        SwitchState(new EnemyChaseState(this));
    }

    private void OnEnable()
    {
        Health.OnDie += HandleDie;
        Health.OnTakeDamage += HandleTakeDamage;
    }

    private void OnDisable()
    {
        Health.OnDie -= HandleDie;
        Health.OnTakeDamage -= HandleTakeDamage;
    }
    private void HandleDie()
    {
        SwitchState(new EnemyDieState(this));
        GameObject particle = Instantiate(DieParticle, transform.position, Quaternion.identity);
        Destroy(particle, 1);
    }
    private void HandleTakeDamage()
    {
        SwitchState(new EnemyTakeDamageState(this));
    }
    public void DestroyEnemyObject()
    {
        Destroy(gameObject);
    }

    public void DropExperiencePoints()
    {
        GameObject experiencePoint = Instantiate(ExperiencePointPrefab, transform.position, Quaternion.identity);
        experiencePoint.GetComponent<ExperiencePoints>().experiencePoints = EnemyData.experiencePoints;
    }
}
