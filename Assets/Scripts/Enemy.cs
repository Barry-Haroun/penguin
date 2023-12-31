using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color aggroColor;
    void Start()
    {
        EnemyManager.ThresholdReached += GoAggro;
    }

    private void GoAggro()
    {
        navMeshAgent.speed *= 2f;
        meshRenderer.material.color = aggroColor;
        EnemyManager.ThresholdReached -= GoAggro;
    }
}