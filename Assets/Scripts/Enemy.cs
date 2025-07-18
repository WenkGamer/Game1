using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.autoRepath = true;

        if (target != null)
        {
            Vector3 hitPosition;
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                // Ép enemy về đúng vị trí trên NavMesh nếu lệch
                transform.position = hit.position;
                agent.SetDestination(target.position);
                Debug.Log("Enemy snapped to NavMesh.");
            }
            else
            {
                Debug.LogError("Enemy is not on NavMesh!");
            }
        }
    }
}
