
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
     Rigidbody _rigidBody;

    void Awake() => _rigidBody = GetComponent<Rigidbody>();

    void OnDisable()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
    }
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            var x = PlayerPrefs.GetFloat("PlayerX");
            var y = PlayerPrefs.GetFloat("PlayerY");
            var z = PlayerPrefs.GetFloat("PlayerZ");
            transform.position = new Vector3(x, y, z);
        }
        
 
      
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity =  new Vector3(horizontal, 0, vertical).normalized;
        _rigidBody.velocity = velocity * _speed;

        
    }
}
