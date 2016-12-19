using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField]
    float waitBuffer;

    [SerializeField]
    float rotateSpeed;

    private float verticalMovement;
    private float horizontalMovement;
    private Vector2 movementVector;
    private Animator anim;
    bool go;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Input.GetAxis("Vertical"));
        Move();

	
	}

    void Move()
    {
        float step = rotateSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");
        movementVector = new Vector2 (verticalMovement, horizontalMovement);
        Quaternion current = transform.localRotation;

        if (movementVector.x > 0 && go == false)
        {
            StartCoroutine(Blaze(waitBuffer));
            transform.position += Vector3.left;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.left), step);
        }
        if (movementVector.x < 0 && go == false)
        {
            StartCoroutine(Blaze(waitBuffer));
            transform.position += Vector3.Lerp(transform.position, Vector3.right, step);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.right), step);
        }
        if (movementVector.y > 0 && go == false)
        {
            StartCoroutine(Blaze(waitBuffer));
            transform.position += Vector3.back;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.back), step);
        }
        if (movementVector.y < 0 && go == false)
        {
            StartCoroutine(Blaze(waitBuffer));
            transform.position += Vector3.forward;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward), step);
        }
    }

    IEnumerator Blaze(float time)
    {
        go = true;
        yield return new WaitForSeconds(time);
        go = false;
    }
}
