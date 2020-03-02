using UnityEngine;
public class Player : MonoBehaviour
{
	[SerializeField]
	float mMoveSpeed = 100.0f;
	[SerializeField]
	float mJumpPower = 20.0f;
	[SerializeField]
	BoxCollider2D mFoot = null;

	void Carry()
	{
	}
	void Update()
	{
		Camera.main.transform.parent.position = transform.position;

		var rigid = GetComponent<Rigidbody2D>();
		var vec = rigid.velocity;
		vec.x = Input.GetAxis("Horizontal") * mMoveSpeed * Time.deltaTime;
		if(Input.GetButtonDown("Jump"))
		{
			if(mFoot.IsTouchingLayers(~(1 << LayerMask.NameToLayer("Player"))))
			{
				vec.y += mJumpPower * Time.deltaTime;
			}
		}
		rigid.velocity = vec;
	}
}
