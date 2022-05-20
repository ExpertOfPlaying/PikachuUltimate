using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindHunter : MonoBehaviour
{

    public Transform Hunted;

    private NavMeshAgent NavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 targetVector = Hunted.position;
        NavMeshAgent.SetDestination(targetVector);
        MeowthRotarion();

    }

    private void MeowthRotarion()
    {
        Vector3 direction = (Hunted.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 2 * Time.deltaTime);
    }
}
