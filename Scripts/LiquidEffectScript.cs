using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidEffectScript : MonoBehaviour
{
    public GameObject liquidMesh;
    public GameObject liquid;

    public int sloshSpeed;
    public int rotateSpeed;
    public int difference;


    // Update is called once per frame
    void Update()
    {
        // Motion
        Slosh();

        //Rotation
        liquid.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void Slosh()
    {
        // Inverse cup rotation
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        // Rotate to
        Vector3 finalRotation = Quaternion.RotateTowards(liquidMesh.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        // Clamp
        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        // Set
        liquidMesh.transform.localEulerAngles = finalRotation;

    }

    private void MoreSlosh()
    {

    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;

        if (value > 180)
        {
            // Clamp
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        } else
        {
            // Clamp
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;
    }
}
