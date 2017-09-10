using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper3D
{
    public class DeactivateBlock : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.collider.tag == "Block")
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}