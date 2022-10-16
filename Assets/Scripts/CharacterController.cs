using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] Animator playerAnim;

    public static CharacterController CharacterControllerInstance;

    public TextMeshProUGUI MoneyCounter;

    private Vector3 direction;
    private Camera cam;
    

    private void Start()
    {
        cam = Camera.main;
        playerAnim = GetComponent<Animator>();

        CharacterControllerInstance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
                direction = ray.GetPoint(distance);

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction.x, 0f, direction.z), playerSpeed * Time.deltaTime);

            var offset = direction - transform.position;

            if (offset.magnitude > 1f)

            transform.LookAt(direction);
        }
        if (Input.GetMouseButton(0))
        {
            playerAnim.SetBool("run", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerAnim.SetBool("run", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("logPoint"))
        {
            other.GetComponent<WorkerManager>().Work();
        }
        if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 50);
            MoneyCounter.text = PlayerPrefs.GetInt("Money").ToString("C0");
        }
    }
}