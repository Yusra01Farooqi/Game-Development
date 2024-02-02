using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class TimelineSceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    PlayableDirector playableDirector;
    void Start()
    {
        // Get the playable director component
        playableDirector = GetComponent<PlayableDirector>();
        // Add a listener to the stopped event
        playableDirector.stopped += OnTimelineStopped;
    }

    // Update is called once per frame
    void OnTimelineStopped(PlayableDirector source)
    {
        // Load the next scene by its name or index
        SceneManager.LoadScene(1);
    }
}
