using UnityEngine;

namespace TopDown.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        public static bool speedon;
        [SerializeField] private float movementSpeed;
        private Rigidbody2D body;
        protected Vector3 currentInput;

        public Vector3 CurrentInput => currentInput;


        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
           
            if (speedon == true)
            {
                body.linearVelocity = movementSpeed * currentInput * Time.fixedDeltaTime * 2;
            }
            if (speedon == false)
            {
                body.linearVelocity = movementSpeed * currentInput * Time.fixedDeltaTime ;
            }
        }

         void Start()
        {
            speedon = false;
        }
         void Update()
        {
            
        } 

    }
}
