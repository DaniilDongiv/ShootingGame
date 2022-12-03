using System.Collections;
using Script;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private Transform _oneSpawn;
    [SerializeField]
    private Transform _twoSpawn;
    [SerializeField]
    private Transform _threeSpawn;

    private Vector3 oneSpawn;
    private Vector3 twoSpawn;
    private Vector3 threeSpawn;
    public int QuantityEnemy;
    private int _quantityEnemy;
    void Start()
    {
        oneSpawn = _oneSpawn.transform.position;
        twoSpawn = _twoSpawn.transform.position;
        threeSpawn = _threeSpawn.transform.position;
        for (int i = 0; i < QuantityEnemy; i++)
        {
            var random = new Random();
            var randomEnemy = random.Next(0, 3);
            var enemy = Instantiate(_enemy);
            
            if (randomEnemy == 0)
            {
                enemy.transform.position = oneSpawn;
            }
            
            if (randomEnemy == 1)
            {
                enemy.transform.position = twoSpawn;
            }
            
            if (randomEnemy == 2)
            {
                enemy.transform.position = threeSpawn;
            }
        }
        
        _quantityEnemy = QuantityEnemy;
    }

    private void Update()
    {
        if (QuantityEnemy < _quantityEnemy)
        {
            var random = new Random();
            var randomEnemy = random.Next(0, 3);
            var enemy = Instantiate(_enemy);
            enemy.GetComponent<Animator>().enabled = true;
            enemy.GetComponent<NavMeshAgent>().enabled = true;
            enemy.GetComponent<EnemyController>()._isDeath = true;
            foreach(var rigidbody in enemy.GetComponentsInChildren<Rigidbody>())
            {
                rigidbody.isKinematic = true;
            }
            if (randomEnemy == 0)
            {
                enemy.transform.position = oneSpawn;
            }
            
            if (randomEnemy == 1)
            {
                enemy.transform.position = twoSpawn;
            
            }
            
            if (randomEnemy == 2)
            {
                enemy.transform.position = threeSpawn;
            }
            QuantityEnemy++;
        }
    }
}
