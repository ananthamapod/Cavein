using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
    private Animator animator;
    private Vector3 lastPos;
    private float speed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        lastPos = Vector3.zero;
        speed = 0;
    }

    void FixedUpdate()
    {
        speed = ((transform.position - lastPos).magnitude / Time.deltaTime);
        lastPos = transform.position;
        if (speed != 0)
        {
            Debug.Log(speed);
        }
    }
    
    // Update is called once per frame
    void Update () {
        float direction = transform.eulerAngles.y;
        float localDirection = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = Mathf.Clamp(speed + 1, 0, 6);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed = Mathf.Clamp(speed - 1, 0, 6);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            localDirection = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            localDirection = 1;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Shooting", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
        animator.SetFloat("Speed", speed);
        transform.Rotate(new Vector3(0, localDirection * Time.deltaTime * 50, 0));
    }
}
