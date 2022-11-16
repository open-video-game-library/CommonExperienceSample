using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing
{
    public class FishingString : MonoBehaviour
    {
        public GameObject[] vertices = new GameObject[20];
        private LineRenderer line;

        private void Start () 
        {		
            line = GetComponent<LineRenderer>();
            line.material =  new Material(Shader.Find("Unlit/Color"));
            line.positionCount = vertices.Length;

            foreach (GameObject v in vertices)
            {            
                v.GetComponent<MeshRenderer> ().enabled = false;
            }

            vertices[vertices.Length - 1].GetComponent<MeshRenderer>().enabled = true;
        }
	
        private void Update () 
        {
            int idx = 0;
            foreach (GameObject v in vertices)
            {
                line.SetPosition(idx, v.transform.position);
                idx++;
            }
        }
    }

}
