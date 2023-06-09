using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _respawnInterval;

    private Vector3[] _points;
    private IEnumerator _coroutineRespawner;
    private bool _isCreating = true;

    private void Start()
    {
        _coroutineRespawner = CreateEnemy();
        _points = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i).position;
        }

        StartCoroutine(_coroutineRespawner);
    }

    private IEnumerator CreateEnemy()
    {
        var waitTime = new WaitForSeconds(_respawnInterval);
        int numberOfPoint = 0;

        while (_isCreating)
        {
            Instantiate(_enemy, _points[numberOfPoint], Quaternion.identity);
            numberOfPoint++;

            if (numberOfPoint == _points.Length)
            {
                numberOfPoint = 0;
            }

            yield return waitTime;
        }
    }
}