using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Transform Player;
    [SerializeField] float speed = 1.0f;

    private Vector3 playerPos;
    private Quaternion lookRotation;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MeowthWalk();
        MeowthRotarion();
    }

    private void MeowthWalk()
    {
        playerPos = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    private void MeowthRotarion()
    {
        direction = (Player.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);
    }
}
