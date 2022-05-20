using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefeber : MonoBehaviour
{
    public Transform Hunted;
    public Transform BallPrefab;
    public Transform MauziPrefab;
    [SerializeField] float startPosY = 1.214343f;
    [SerializeField] float posRange = 50;
    [SerializeField] float eulerRange = 360;
    [SerializeField] float maxBalls = 20;
    [SerializeField] float maxMauzis = 3;

    private Vector3 posPrefab;
    private Quaternion rotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxBalls; i++)
        {
            posPrefab = new Vector3(Random.Range(-posRange, posRange), startPosY, Random.Range(-posRange, posRange));
            rotPrefab = Quaternion.Euler(0, Random.Range(-eulerRange, eulerRange), 0);
            Transform tmpPokeball = Instantiate(BallPrefab, posPrefab, rotPrefab);
        }

        for (int i = 0; i < maxMauzis; i++)
        {
            posPrefab = new Vector3(Random.Range(-posRange, posRange), startPosY, Random.Range(-posRange, posRange));
            rotPrefab = Quaternion.Euler(0, Random.Range(-eulerRange, eulerRange), 0);
            Transform tmpMauzi = Instantiate(MauziPrefab, posPrefab, MauziPrefab.rotation);
            tmpMauzi.GetComponent<PathfindHunter>().Hunted = Hunted;
        }

    }
}
