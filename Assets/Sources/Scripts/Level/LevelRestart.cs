using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonRestart;

    private ComparisonRoot _comparisonRoot;

    public void Init(ComparisonRoot comparisonRoot)
    {
        _comparisonRoot = comparisonRoot;
        _comparisonRoot.Finished += OnFinish;
    }

    private void OnDisable()
    {
        _comparisonRoot.Finished -= OnFinish;
        _buttonRestart.Clicked -= OnRestart;
    }

    private void OnFinish()
    {
        _buttonRestart.Enable();
        _buttonRestart.Clicked += OnRestart;
    }

    private void OnRestart()
    {
        int indexActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexActiveScene);
    }
}
