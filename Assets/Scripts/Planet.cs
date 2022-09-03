using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float speed = 50f;

    public void Attract(Transform characterTransform)
    {
        Vector3 gravityUp = (characterTransform.position - transform.position).normalized;
        Vector3 localUp = characterTransform.up;

        characterTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * characterTransform.rotation;
        characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
