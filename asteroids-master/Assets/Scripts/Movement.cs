using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Camera cameraGame; 

        void Awake()
        {
            cameraGame = GameObject.FindObjectOfType<Camera>();
        }
        private void Update()
        {
            float movement = Input.GetAxis("Vertical");
			transform.Translate(Vector3.forward * speed * movement * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                Vector3 destinoClick = cameraGame.ScreenToWorldPoint(Input.mousePosition) + Vector3.one;
                destinoClick.z = transform.position.z;
                transform.position = Vector2.Lerp(transform.position, destinoClick, speed*Time.deltaTime);
            }
            
        }
    }
}