using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateTerrains;

namespace Technica.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMotor : MonoBehaviour
    {
        private UltimateTerrain Terrain;
        private Camera Camera;
        private Rigidbody Rigidbody;
        private CharacterController Controller;
        private float Speed;
        public float WalkSpeed;
        public float RunSpeed;
        public float JumpHeight;
        public float LookSpeed;
        public float GravitationalConstant;
        private Vector3 GravityVelocity;
        public VoxelType type;

        private UI.UImanager UImanager;

        private bool Jumped;

        private void Start()
        {
            Init();         
        }

        private void Init()
        {
            UImanager = GameObject.Find("Controller").GetComponent<UI.UImanager>();
            Terrain = GameObject.Find("uTerrain").GetComponent<UltimateTerrain>() as UltimateTerrain;
            Camera = transform.GetChild(0).GetComponent<Camera>();
            Rigidbody = GetComponent<Rigidbody>();
            Controller = GetComponent<CharacterController>();
            
            Cursor.lockState = CursorLockMode.Locked;

            Speed = WalkSpeed;
            Jumped = false;
        }
          
        private void Update()
        {
            if (Terrain.IsLoaded == true)
            {
                float yRot = Input.GetAxis("Mouse X");
                float xRot = Input.GetAxis("Mouse Y");
                float xInput = Input.GetAxisRaw("Horizontal");
                float zInput = Input.GetAxisRaw("Vertical");

                Vector3 xMovement = transform.right * xInput;
                Vector3 yMovement = transform.forward * zInput;

                Vector3 Rotation = new Vector3(0, yRot, 0) * LookSpeed;
                Vector3 CameraRotation = new Vector3(-xRot, 0, 0) * LookSpeed;

                Vector3 Movement = (xMovement + yMovement).normalized * Speed;

                if (Controller.isGrounded != true)
                {
                    GravityVelocity.y -= GravitationalConstant * Time.deltaTime;
                }
                else if (Jumped == true)
                {
                    GravityVelocity.y += JumpHeight;
                    Jumped = false;
                }
                else
                {
                    GravityVelocity.y = -1f;
                }

                UImanager.Debugtext2.text = "VerticalVelocity: " + GravityVelocity.y.ToString();

                Rotate(Rotation, CameraRotation);
                Move(Movement, GravityVelocity);
            }

            if (Controller.isGrounded == true)
            {
                UImanager.DebugText1.text = "Grounded: True";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
            else
            {
                UImanager.DebugText1.text = "Grounded: False";
            }

            if(Input.GetKey(KeyCode.LeftShift))
            {
                Speed = RunSpeed;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                Speed = WalkSpeed;
            }

            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Button Clicked");

                RaycastHit Hit;
                Ray Ray = Camera.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(Ray, out Hit, 5f, Terrain.Params.ChunkLayerMask);

                var Position = Hit.point + Hit.normal * 0.01f;
                    
                Vector3 Size = new Vector3(1, 1, 1);
                
                if (Terrain.OperationsManager.IsReadyToComputeAsync)
                {
                        Debug.Log("Added Operation");

                        Terrain.OperationsManager.Add(AxisAlignedCube.CreateFromUnityWorld(Terrain, true, Position, Size, type),true).PerformAll(true);
                }
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Button Clicked");

                RaycastHit Hit;
                Ray Ray = Camera.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(Ray, out Hit, 5f, Terrain.Params.ChunkLayerMask);

                var Position = Hit.point + Hit.normal * 0.01f;

                Vector3 Size = new Vector3(1, 1, 1);

                if (Terrain.OperationsManager.IsReadyToComputeAsync)
                {
                    Debug.Log("Added Operation");

                    Terrain.OperationsManager.Add(AxisAlignedCube.CreateFromUnityWorld(Terrain, false, Position, Size, type), true).PerformAll(true);
                }

            }
        }

        private void Move(Vector3 Move, Vector3 GravitationalVelocity)
        {
            // Character Movement
            Controller.Move(Move);
            
            // Apply gravity
            Controller.Move(GravitationalVelocity * Time.deltaTime);         
        }
            
        private void Rotate(Vector3 Rotation, Vector3 CameraRotation)
        {
            transform.Rotate(transform.rotation * Rotation);
            Camera.transform.Rotate(CameraRotation);
        }

        private void Jump()
        {
            Jumped = true;             
        }     
    }
}