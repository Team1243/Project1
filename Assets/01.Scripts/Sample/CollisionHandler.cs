using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _levelLoadDelay = 2f;
    [SerializeField] private AudioClip _success;
    [SerializeField] private AudioClip _crash;
    [SerializeField] private ParticleSystem _successParticle;
    [SerializeField] private ParticleSystem _crashParticle;

    private AudioSource _audioSource;

    private bool _isTransitioning = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_isTransitioning) return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccessSequence()
    {
        _isTransitioning = true;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_success);
        _successParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", _levelLoadDelay);
    }
    void StartCrashSequence()
    {
        _isTransitioning = true;
        _audioSource.Stop();
        _audioSource.PlayOneShot(_crash);
        _crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", _levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
