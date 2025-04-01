using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UIManager : MonoBehaviour
{
    [Header("Button Setup")]
    [SerializeField]private Button startButton;
    [SerializeField]private Button restartButton;
    [SerializeField]private Button shootButton;
    
    [Header("UI Setup")]
    [SerializeField]private TMP_Text greetingText;
    
    public static event Action OnStartButtonPressed;
    public static event Action OnRestartButtonPressed;
    public static event Action OnShootButtonPressed;
    
    void Start()
    {
        startButton.onClick.AddListener(OnUIStartButtonPressed);
        restartButton.onClick.AddListener(OnUIRestartButtonPressed);
        shootButton.onClick.AddListener(OnUIStartButtonPressed);
        
        restartButton.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
    }

    void OnUIStartButtonPressed()
    {
        OnStartButtonPressed?.Invoke();
        
        restartButton.gameObject.SetActive(true);
        shootButton.gameObject.SetActive(true);
        //greetingText.text = "SHOOT THE ENEMY";
        greetingText.gameObject.SetActive(false);
    }

    void OnUIRestartButtonPressed()
    {
        OnRestartButtonPressed?.Invoke();
        
        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
        greetingText.gameObject.SetActive(true);
    }

    void OnUIShootButtonPressed()
    {
        OnShootButtonPressed?.Invoke();
    }
}
