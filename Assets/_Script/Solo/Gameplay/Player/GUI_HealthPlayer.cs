using UnityEngine;
using System.Collections;

public class GUI_HealthPlayer : CQCCombat
{
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;
    public Texture image;
    private float hsliderValue = 0f;

    // Use this for initialization
    void Start()
    {
        this.maxHealth = 100;
        this.currHealth = maxHealth;
        this.guardPoints = 100;
        this.currGP = guardPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUIDrawRect(new Rect(162, Screen.height - 70, 228*currHealth/maxHealth, 8), Color.green);
        GUIDrawRect(new Rect(140, Screen.height - 55, 120*currGP/guardPoints, 5), Color.blue);
        GUI.DrawTexture(new Rect(30, Screen.height - 250, 400, 400), image, ScaleMode.ScaleToFit);
    }

    // Note that this function is only meant to be called from OnGUI() functions.
    public static void GUIDrawRect(Rect position, Color color)
    {
        if (_staticRectTexture == null)
            _staticRectTexture = new Texture2D(1, 1);

        if (_staticRectStyle == null)
            _staticRectStyle = new GUIStyle();

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;

        GUI.Box(position, GUIContent.none, _staticRectStyle);
    }
}
