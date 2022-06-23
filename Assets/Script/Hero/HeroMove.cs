using Script.Infrastructure;
using Script.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [FormerlySerializedAs("CharacterController")] public CharacterController characterController;
        [FormerlySerializedAs("MovementSpeed")] public float movementSpeed = 0.2f;
        private IInputServices inputService;
        private Camera _camera;
        public float gravity = 20.0F; //Сила гравитации

        private void Awake()
        {
            inputService = Game.InputServices;
        }
        
        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                //Трансформируем экранныые координаты вектора в мировые
                movementVector = _camera.transform.TransformDirection(inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }
            
            /*movementVector.y -= gravity*Time.deltaTime;*/
            movementVector += Physics.gravity;
            
            characterController.Move(  movementSpeed* movementVector * Time.deltaTime);
        }
    }
}