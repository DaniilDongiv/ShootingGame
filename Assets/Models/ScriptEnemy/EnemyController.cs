using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        [SerializeField]
        private EnemySpawn _enemySpawn;
        
        public Rigidbody[] Rigidbodies;
        public bool _isDeath = true;
        private Animator _animator;
        private static readonly int _hit = Animator.StringToHash("hit");
        
        void Start()
        {
            foreach(var rigidbody in Rigidbodies)
            {
                rigidbody.isKinematic = true;
            }
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
    
        public void ShowDeath()
        {
            foreach(var rigidbody in GetComponentsInChildren<Rigidbody>())
            {
                rigidbody.isKinematic = false;
            }
            gameObject.GetComponentInParent<Animator>().enabled = false;
            if (_isDeath)
            {
                GetComponent<NavMeshAgent>().enabled = false;
            }
            _isDeath = false;
            _enemySpawn.QuantityEnemy--;
        }
        
        void Update()
        {
            if (_isDeath)
            {
                _navMeshAgent.SetDestination(_player.transform.position);
            }
        }
    }
}