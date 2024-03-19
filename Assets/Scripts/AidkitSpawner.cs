using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public AidKit aidkitPrefab;
    public float delayMin = 3;
    public float delayMax = 10;

    private List<Transform> _spawnerPoints;

    private AidKit _aidkit;

    private void Start()
    {
        //если в aidkitspawner созданы новые точки, они автоматом появляются здесь в списке

        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }
    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;

        Invoke("CreateAidKit", Random.Range(delayMin, delayMax));
    }

    private void CreateAidKit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = _spawnerPoints[Random.Range(0,_spawnerPoints.Count)].position;
    }
}
