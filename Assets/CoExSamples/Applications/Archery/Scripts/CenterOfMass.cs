using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class CenterOfMass : MonoBehaviour {

    [FormerlySerializedAs("center")] public Vector3 Center = new Vector3(0f, 0f, 5f);

    private Rigidbody _rb;

    private void Start () {
        _rb = GetComponent<Rigidbody> ();
        _rb.centerOfMass = Center;
    }

    private void Update () {
        Debug.DrawLine (transform.position , transform.position + transform.rotation * Center);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere (transform.position + transform.rotation * Center, 0.1f);
    }

}