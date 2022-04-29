using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefeber : MonoBehaviour
{

    public Transform BallPrefab;
    [SerializeField] float startPosY = 1.214343f;
    [SerializeField] float posRange = 50;
    [SerializeField] float eulerRange = 360;
    [SerializeField] float maxBalls = 20;

    private Vector3 posPrefab;
    private Quaternion rotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxBalls; i++)
        {
            posPrefab = new Vector3(Random.Range(-posRange, posRange), startPosY, Random.Range(-posRange, posRange));
            rotPrefab = Quaternion.Euler(0, Random.Range(-eulerRange, eulerRange), 0);
            Transform tmppokeball = Instantiate(BallPrefab, posPrefab, rotPrefab);
        }
    }
}
