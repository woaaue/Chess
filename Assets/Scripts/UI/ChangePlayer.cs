using UnityEngine;

public sealed class ChangePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _textWhite;
    [SerializeField] private GameObject _textBlack;

    private void OnEnable()
    {
        Match.OnPlayerChanged += ChangeText;
    }

    private void ChangeText()
    {
        if (!_textBlack.activeInHierarchy)
        {
            _textWhite.SetActive(false);
            _textBlack.SetActive(true);
        }
        else 
        {
            _textBlack.SetActive(false);
            _textWhite.SetActive(true);
        }
    }

    private void OnDisable()
    {
        Match.OnPlayerChanged -= ChangeText;
    }
}
