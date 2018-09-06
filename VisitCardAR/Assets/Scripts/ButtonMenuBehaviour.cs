using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuBehaviour : MonoBehaviour
{
	public void Click()
	{
		SceneManager.LoadScene("MainScene");
	}
}