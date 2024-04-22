using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gravity : MonoBehaviour
{
    [SerializeField] private LocomotionProvider _locomotionProvider;
    [SerializeField] private CharacterController _cc;
    [SerializeField] private float _gravity;
    [SerializeField] private Transform _groundCheck;
    private void Awake()
    {
        if (!_locomotionProvider) {
            Debug.LogError("No Locomotion provider reference");
        }

        if (!_groundCheck) {
            Debug.LogError("No ground check transform.");
        }
    }

    void Update() {
        if (_locomotionProvider.locomotionPhase == LocomotionPhase.Idle && !CheckGround()) {
            _cc.Move(Vector3.down * (_gravity * Time.deltaTime));
        }
    }

    private bool CheckGround()
    {
        if (Physics.Raycast(_groundCheck.position, Vector3.down, 0.02f)) {
            return true;
        } return false;
    }
}
