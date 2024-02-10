using UnityEngine;

public sealed class InputController : MonoBehaviour
{
    private Camera _camera;
    private Match _match;

    private void Start()
    {
        _camera = Camera.main;
        _match = new Match();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _match.FirstClickCell(_camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
