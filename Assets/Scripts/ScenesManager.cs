using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class is an example of a SceneManager
/// </summary>
/// 

public class ScenesManager : MonoBehaviour
{
    // creating a singleton instance that can be used in any script without instantiating it first
    public static ScenesManager Instance;

    [SerializeField]
    private Image progressBar;

    private float target;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;

        progressBar.fillAmount = 0;
    }

    // creating an enum for all Scenes that we want to use in our build
    // to access the scenes that are currently in the build go to "File > Build Settings > Scenes in Build"
    // the names in the enum have to match the names of your scenes
    public enum Scene { 
        Main_Menu,
        Indoor,
        Outdoor,
        Win,
        Lose
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        // we use Unity's SceneManager class to load a scene by name or build index (can be found in build settings menu)
        SceneManager.LoadScene((int)Scene.Main_Menu);
        //SceneManager.LoadScene(Scene.UIScene.ToString());
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // unity can load scenes asynchronously
    // this allows us to load large scenes in the background while we show a loading screen or continue the game
    // Needs to be marked as "async" !!!
    public async void LoadSceneAsync()
    {
        target = 0f;
        progressBar.fillAmount = 0f;

        // Start loading the next scene asynchronously
        var scene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // Prevent the scene from activating immediately
        scene.allowSceneActivation = false;

        while (scene.progress < 0.9f)
        {
            // Update the progress bar fill amount
            target = scene.progress;
            progressBar.fillAmount = target;

            // Yield control back to the main thread to keep the UI responsive
            await Task.Yield();
        }

        // Allow the scene to activate
        scene.allowSceneActivation = true;

        // Optionally, continue to update the progress bar to full (1.0f) until the scene is fully activated
        while (!scene.isDone)
        {
            target = Mathf.MoveTowards(target, 1f, Time.deltaTime);
            progressBar.fillAmount = target;

            // Yield control back to the main thread to keep the UI responsive
            await Task.Yield();
        }
    }

    private void Update()
    {
        // fill the bar smoothly through the MoveTowards
        // interpolates between the current fillAmount and the newly calulcated loading percentage in the LoadSceneAsync func
        // progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, Time.deltaTime * 3);
    }
}
