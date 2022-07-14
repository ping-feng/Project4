using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com
{
    namespace interiorlighting
    {
        namespace controls
        {
            public class KeyboardHandler : MonoBehaviour
            {
                CharacterController characterController;
                public float MovementSpeed = 3;
                public float Gravity = 9.8f;
                private float velocity = 0;
                public float jumpHeight = 0.1f;

                private Camera cam;
                // Start is called before the first frame update
                void Start()
                {
                    characterController = GetComponent<CharacterController>();
                    cam = Camera.main;
                }

                // Update is called once per frame
                void Update()
                {   
                    float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
                    float vertical = Input.GetAxis("Vertical") * MovementSpeed;
                    Vector3 xzMovement = (cam.transform.forward * vertical) + (cam.transform.right * horizontal);
                    characterController.Move(xzMovement * Time.deltaTime);

                    if(characterController.isGrounded){
                        velocity = 0;
                    }

                    if(Input.GetButtonDown("Jump")){
                        velocity = jumpHeight;
                        // string message = string.Format("Velocity: {0}, Jump Height: {1}, Gravity:{2}", velocity, jumpHeight, Gravity);
                        // Debug.Log(message);
                    }
                    else{            
                        velocity -= Gravity * 0.5f * Time.deltaTime;   
                    }
                    characterController.Move(new Vector3(0, velocity, 0));
                }
            }
        }
    }    
}