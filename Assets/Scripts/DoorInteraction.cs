using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com
{
    namespace interiorlighting
    {
        namespace interactable
        {
            public class DoorInteraction : MonoBehaviour
            {
                private bool doorIsOpen = false;
                private float doorOpenedTime = 0.0f;
                // Start is called before the first frame update
                void Start()
                {

                }

                // Update is called once per frame
                void Update()
                {
                    if (doorIsOpen && doorOpenedTime > 3.0)
                    {
                        doorIsOpen = false;
                        GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
                    }
                    doorOpenedTime += Time.deltaTime;
                }

                public void OpenDoor()
                {
                    doorIsOpen = true;
                    doorOpenedTime = 0.0f;
                    GetComponent<Transform>().rotation = Quaternion.Euler(0, 270, 0);
                }
            }

        }
    }
}
