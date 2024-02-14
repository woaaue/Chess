using UnityEngine;

public sealed class ViewFigure : MonoBehaviour
{
    private void OnEnable()
    {
        Figure.OnLocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(Vector2 targetCell, Vector2 currentCell)
    {
        if (targetCell == new Vector2(transform.position.x, transform.position.y))
        {
            gameObject.SetActive(false);
        }

        if (currentCell == new Vector2(transform.position.x, transform.position.y))
        {
            transform.position = targetCell;
        }
    }

    private void OnDisable()
    {
        Figure.OnLocationChanged -= OnLocationChanged;
    }
}
