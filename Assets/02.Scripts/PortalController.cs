using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    bool _isPortal = false;
    [SerializeField] string _nextScene = "Start";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPortal = false;
        }
    }

    public void UsePortal()
    {
        GameManager._instance._playerController.SetSpawn(Vector2.zero);
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nextScene);
    }

}
