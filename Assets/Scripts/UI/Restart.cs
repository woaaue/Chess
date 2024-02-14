using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Restart : MonoBehaviour
{
   public void RestartGame()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
