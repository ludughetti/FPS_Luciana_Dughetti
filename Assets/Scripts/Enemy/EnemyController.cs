using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;

    private bool _isRunning = true;

    void Update()
    {
        agent.SetDestination(player.position);
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    public void CanMove(bool canMove)
    {
        agent.speed = canMove ? 2f : 0f;
        _isRunning = canMove;
    }

    public void RemoveCharacterOnDeath()
    {
        Debug.Log($"{name}: Character dead");

        Destroy(gameObject);
    }
}