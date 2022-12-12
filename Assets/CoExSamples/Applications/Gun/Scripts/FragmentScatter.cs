using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentScatter : MonoBehaviour
{
    [SerializeField] private Transform _center;
    
    // Start is called before the first frame update
    private void Start()
    {
        Scatter();
    }
    private void Scatter()
    {
        Vector3 direction = (gameObject.transform.position - _center.position).normalized;
        float force = 50 * Random.Range(0.9f, 1.1f);
        gameObject.GetComponent<Rigidbody>().AddForce(direction * force);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
