using UnityEngine;

public sealed class Win : MonoBehaviour
{
    [SerializeField] private GameObject _whiteWinImage;
    [SerializeField] private GameObject _blackWinImage;

    private void OnEnable()
    {
        Match.OnKingDied += ShowVictory;
    }

    private void ShowVictory(Player playerWin)
    {
        if (playerWin == Player.White)
        {
            _whiteWinImage.SetActive(true);
        }
        if (playerWin == Player.Black)
        {
            _blackWinImage.SetActive(true);
        }
    }

    private void OnDisable()
    {
        Match.OnKingDied -= ShowVictory;
    }
}
