using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float playerAcceleration;
        private Rigidbody2D _rb;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private LayerMask borderLayer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                _rb.AddForce(Vector2.up * (playerAcceleration * Time.deltaTime));
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (enemyLayer.Contains(col.gameObject.layer) ||
                borderLayer.Contains(col.gameObject.layer))
            {
                Death();
            }
        }

        private void Death()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
