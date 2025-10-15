using UnityEngine;

namespace SplatterSystem.Isometric {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class UserCharacterController : MonoBehaviour {
        public float speed = 14f;
        public float acceleration = 6f;

        protected Rigidbody rb;
        protected Vector3 input;

        protected virtual void Awake() {
            rb = GetComponent<Rigidbody>();
            input = Vector3.zero;
        }

        protected virtual void Update() {
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        }

        void FixedUpdate() {
            #if UNITY_2023_2_OR_NEWER
            rb.AddForce(((input*speed) - rb.linearVelocity) * acceleration);
            #else
            rb.AddForce(((input*speed) - rb.velocity) * acceleration);
            #endif
            //rb.velocity = ((input*speed) - rb.velocity) * acceleration;
        }
    }
}