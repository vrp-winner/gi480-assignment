using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    private ARSession _arSession;
    private bool _gameStarted = false;
    void Start()
    {
        _arSession = FindFirstObjectByType<ARSession>();
        //Called from UI buttton
        UIManager.OnStartButtonPressed += StartGame;
        UIManager.OnRestartButtonPressed += RestartGame;
    }

    void StartGame()
    {
        if (_gameStarted) return;
        _gameStarted = true;
        print("Game started");
        
        planeManager.enabled = false;
        foreach (var plane in planeManager.trackables)
        {
            var meshVisual = plane.GetComponent<ARPlaneMeshVisualizer>();
            if (meshVisual) meshVisual.enabled = false;
            
            var lineVisual = plane.GetComponent<LineRenderer>();
            if (lineVisual) lineVisual.enabled = false;
        }
    }

    void RestartGame()
    {
        _gameStarted = false;
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        while (ARSession.state != ARSessionState.SessionTracking)
        {
            yield return null;
        }
        _arSession.Reset();
        planeManager.enabled = true;
    }
    
}
