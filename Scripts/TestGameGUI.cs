using UnityEngine;


public class TestGameGUI : MonoBehaviour
{
    [SerializeField] private GUISkin skin = null;
    [SerializeField] private float updateInterval = 0.5F;
    
    private double _lastInterval;
    private int _frames = 0;
    private float _fps;


    private Rect windowRect = new Rect(5, Screen.height - 50, Screen.width - 10, 50);

    void Start()
    {
        _lastInterval = Time.realtimeSinceStartup;
        _frames = 0;
    }
    void OnGUI()
    {
        GUI.skin = skin;
        windowRect = GUI.Window(0, windowRect, WindowFunction, "--- Î Ò Ë À Ä Ê À ---");
    }

    void WindowFunction(int windowID)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label($"fps: {_fps.ToString("f0")}");
        GUILayout.Label($"hp: {0}%");
        GUILayout.Label($"bulls: {0}");
        GUILayout.EndHorizontal();
    }

    void Update()
    {

        ++_frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > _lastInterval + updateInterval)
        {
            _fps = (float)(_frames / (timeNow - _lastInterval));
            _frames = 0;
            _lastInterval = timeNow;
        }
    }
}

