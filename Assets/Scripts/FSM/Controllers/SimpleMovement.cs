using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

	public float _speed = 1f;
	[SerializeField] private float _step = 1f;

	private bool _isMoving = false;
	private bool _canMove = true;

	private Vector3 _nextPosition;



	// Update is called once per frame
	void Update()
	{
		if (_canMove)
		{
			Constants.Directions direction = Constants.Directions.kNone;

			if (Input.GetAxis("Vertical") > 0)
			{
				direction = Constants.Directions.kUp;
			}
			else if (Input.GetAxis("Vertical") < 0)
			{
				direction = Constants.Directions.kDown;
			}
			else if (Input.GetAxis("Horizontal") < 0)
			{
				direction = Constants.Directions.kLeft;
			}
			else if (Input.GetAxis("Horizontal") > 0)
			{
				direction = Constants.Directions.kRight;
			}

			CalculateStep(direction);
		}

		if (_isMoving)
		{
			Move();
		}

	}

	void CalculateStep(Constants.Directions direction)
	{
		_nextPosition = transform.position;
		//Calculate next vector position with step according to direction input.
		switch (direction)
		{
			case Constants.Directions.kUp:
				_nextPosition = transform.position + Vector3.forward * _step;
				break;
			case Constants.Directions.kDown:
				_nextPosition = transform.position + Vector3.back * _step;
				break;
			case Constants.Directions.kLeft:
				_nextPosition = transform.position + Vector3.left * _step;
				break;
			case Constants.Directions.kRight:
				_nextPosition = transform.position + Vector3.right * _step;
				break;
		}

		_isMoving = (direction != Constants.Directions.kNone);
	}

	void Move()
	{
		//Just moving towards next vector position at specified speed.		
		transform.position = Vector3.MoveTowards(transform.position,
			_nextPosition,
			Time.deltaTime * _speed);

		if (Vector3.Distance(transform.position, _nextPosition) < Mathf.Epsilon)
		{
			_isMoving = false;
			_canMove = true;
		}
	}

	public class Constants
	{
		public enum Directions
		{
			kUp,
			kDown,
			kLeft,
			kRight,
			kNone
		}

	}
}