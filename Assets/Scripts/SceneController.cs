using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneController : MonoBehaviour
{
    public Animator transition;
    public Texture2D cursor;

    void Start() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void MainMenu() {
        StartCoroutine(LoadScene(0));
    }

    public void Game() {
        StartCoroutine(LoadScene(1));
    }

    public void End() {
        StartCoroutine(LoadScene(2));
    }

    IEnumerator LoadScene(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
