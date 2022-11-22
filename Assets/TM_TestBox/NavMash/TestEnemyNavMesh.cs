using UnityEngine;
using UnityEngine.AI;

public class TestEnemyNavMesh : MonoBehaviour
{
    [Header("NavMesh")]
    [SerializeField] private GameObject target;
    [SerializeField] private PretoAnimationController pretoAC;
    private NavMeshAgent navMeshAgent;
    private float speedPlaying;
    [SerializeField] private Vector3 randomWayPoint;
    [Header("RoomDistance")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float Y = 0.022f;
    //[SerializeField] private GameObject[] wayPoint;

    [Header("Speed")]
    [SerializeField] private float idelSpeed = 0;
    [SerializeField] private float walkSpeed = 1.2f;
    [SerializeField] private float runSpeed = 5;

    [Header("CastBox")]
    RaycastHit[] hitBoxs;
    public LayerMask selectionMask;
    [SerializeField] private float r_BoxDistance;
    [SerializeField] private Vector3 r_Box;

    [Header("TimerCheck")]
    float timerCheckPlayer = 0;
    float timerReRandomPosition = 0;
    float delayReRandomPosition = 15;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pretoAC = gameObject.GetComponent<PretoAnimationController>();
        speedPlaying = navMeshAgent.speed;
    }
    private void Update()
    {
        hitBoxs = Physics.BoxCastAll(transform.position + Vector3.back * 3, r_Box, transform.forward, transform.rotation, r_BoxDistance, selectionMask);
        if (timerReRandomPosition < Time.time)
        {
            timerReRandomPosition = Time.time + delayReRandomPosition;
            randomWayPoint = RandomLocationTarget();
        }

        if (!CheckPlayer())
        {
            timerCheckPlayer -= Time.deltaTime;
            if (timerCheckPlayer < 0)
            {
                Debug.Log("walking");
                navMeshAgent.SetDestination(randomWayPoint);
            }
        }
        else
        {
            navMeshAgent.destination = target.transform.position;
        }
        if (navMeshAgent.speed != speedPlaying)
        {
            switch (navMeshAgent.speed)
            {
                case 0://idelSpeed
                    pretoAC.numClip = 0;
                    break;
                case 1.2f://walkSpeed
                    pretoAC.numClip = 1;
                    break;
                case 5://runSpeed
                    pretoAC.numClip = 2;
                    break;
            }
        }
        speedPlaying = navMeshAgent.speed;
    }
    bool CheckPlayer()
    {
        foreach (RaycastHit h in hitBoxs)
        {
            if (h.collider.tag == "Player")
            {
                timerCheckPlayer = 10;
                target = h.collider.gameObject;
                return true;
            }
        }
        return false;
    }
    Vector3 RandomLocationTarget()
    {
        Vector3 A = new Vector3(Random.Range(minX, maxX), Y, Random.Range(minZ, maxZ));
        return A;
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * r_BoxDistance);
        Gizmos.DrawWireCube(transform.position + transform.forward * r_BoxDistance, r_Box);

    }
}
