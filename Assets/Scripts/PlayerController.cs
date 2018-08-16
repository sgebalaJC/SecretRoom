using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float fallThreshold;

	private Rigidbody rb;
	private Vector3 initialPosition;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		
		InitializePlayer();
	}

	private void InitializePlayer()
	{
		initialPosition = transform.position;

		if (fallThreshold >= initialPosition.y)
		{
			fallThreshold = initialPosition.y - 10;
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Debug.Log(string.Format("Horizontal: {0}", moveHorizontal.ToString()));
		Debug.Log(string.Format("Vertical: {0}", moveVertical.ToString()));

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		ValidatePositon();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}

	private void ValidatePositon()
	{
		Debug.Log(transform.position.y);
		
		if(transform.position.y < fallThreshold)
		{
			ResetPositon();
			rb.velocity = Vector3.zero;
		}
	}

	private void ResetPositon()
	{
		transform.position = initialPosition;
	}
}
