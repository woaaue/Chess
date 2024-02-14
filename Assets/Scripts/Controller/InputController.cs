using UnityEngine;

public sealed class InputController : MonoBehaviour
{
    private Match _match;
    private Camera _camera;

    private void Start()
    {
        _match = new Match();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _match.IsCellOccupied(_match.CoordinateConversion(_camera.ScreenToWorldPoint(Input.mousePosition)));

            if (_match._selectedFigure == null)
            {
                return;
            }
            else if (_match.IsPossibleMove(_match._selectedFigure, _match.CoordinateConversion(_camera.ScreenToWorldPoint(Input.mousePosition))))
            {
                _match.ManipulationFigure(_match._selectedFigure, _match.CoordinateConversion(_camera.ScreenToWorldPoint(Input.mousePosition)));
                _match.SwitchPlayer();
            }
        }
    }
}
