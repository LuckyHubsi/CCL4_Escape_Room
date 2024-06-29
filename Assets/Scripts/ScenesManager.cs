using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScenesManager : MonoBehaviour
{
    // Creating a singleton instance that can be used in any script without instantiating it first
    public static ScenesManager Instance;

    [SerializeField]
    private Image progressBar;

    private float target;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
            return;
        }
        Instance = this;

        progressBar.fillAmount = 0;
    }

    // Creating an enum for all Scenes that we want to use in our build
    // (the names in the enum have to match the names of our scenes)
    public enum Scene 
    { 
        Main_Menu,
        Indoor,
        Outdoor,
        Win,
        Lose
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    // Method using unity's SceneManager class to load a scene by name or build index
    public void LoadMenu() 
    {
        SceneManager.LoadScene((int)Scene.Main_Menu);

        //Wwise
        AkSoundEngine.StopAll();
    }

    // Method using unity's SceneManager class to load a scene by using our scene enums
    public void LoadScene(Scene scene) 
    {
        SceneManager.LoadScene(scene.ToString());
        
        //Wwise
        AkSoundEngine.StopAll();
    }

    // Method using unity's SceneManager class to load the next scene by increasing the build index
    public void LoadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        //Wwise
        AkSoundEngine.StopAll();
    }

    // Method to load a scene asynchronously, if the next scene has lots of things that need to be loaded
    // (progress bar was planned and kinda included, but never really got used because the loading time is still very short)
    public async void LoadSceneAsync()
    {
        AkSoundEngine.StopAll();

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

    }
}
