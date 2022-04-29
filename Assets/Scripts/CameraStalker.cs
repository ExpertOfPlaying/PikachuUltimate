using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStalker : MonoBehaviour
{

    public Transform Target;
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offsetVector;

    private Quaternion playerRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CamLerp();
        CamSlerp();
    }

    //Camera movement for translation
    private void CamLerp()
    {
        playerRotation = Target.transform.rotation;
        Vector3 offsetRotated = playerRotation * offsetVector;
        Vector3 desiredPos = Target.transform.position + offsetRotated;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }

    //Camera movement for rotation
    private void CamSlerp()
    {
        playerRotation = Target.transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, smoothSpeed * Time.deltaTime);
    }
}
