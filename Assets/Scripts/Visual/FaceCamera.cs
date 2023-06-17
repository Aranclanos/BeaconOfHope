using UnityEngine;

namespace Visual
{
	public class FaceCamera : MonoBehaviour
	{
		private Camera mainCamera;

		private void Start()
		{
			mainCamera = Camera.main;
		}

		private void Update()
		{
			var cameraDirection = transform.position - mainCamera.transform.position;
			var cameraDirectionXZ = Vector3.ProjectOnPlane(cameraDirection, Vector3.up);
			var angle = Vector3.SignedAngle(transform.forward, cameraDirectionXZ, Vector3.up);
			transform.Rotate(Vector3.up, angle, Space.World);
		}
	}
}