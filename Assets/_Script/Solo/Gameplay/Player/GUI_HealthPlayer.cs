using UnityEngine;
using System.Collections;

public class GUI_HealthPlayer : CQCCombat
{
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;
    private Texture image;

    // Use this for initialization
    override protected void Start()
    {
        /*this.maxHealth = getmaxHealth;
        this.currHealth = currentHealth;
        this.guardPoints = getGP;
        this.currGP = currentGP;*/
        base.Start();
        this.image = Resources.Load<Texture>("Image/hud_healthbar");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Combat Status : " + combatStatus + "\n leavecombat = " + leavecombat);
        regenGP(combatStatus);
        if (Input.GetKeyDown(KeyCode.C))
            TakingPunishment(10);
    }

    void OnGUI()
    {
        float hppercent = currentHealth / getmaxHealth;
        float gppercent = currentGP / getGP;
        GUIDrawHP(hppercent);
        GUIDrawGP(gppercent);
        GUI.DrawTexture(new Rect(30, Screen.height - 250, 400, 400), image, ScaleMode.ScaleToFit);
    }

    // Note that this function is only meant to be called from OnGUI() functions.
    /// <summary>
    /// Draws Rectangles on GUI
    /// </summary>
    /// <param name="position"> = position on the screen</param>
    /// <param name="color"> Color of the rectangle drawn</param>
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

    public static void GUIDrawHP(float percent)
    {
        if (percent > 0.5f)
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), new Color(61/255f,161/255f,74/255f,1));
        else if (percent > 0.2f)
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), Color.yellow);
        else
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), Color.red);
    }

    public static void GUIDrawGP(float percent)
    {
        GUIDrawRect(new Rect(140, Screen.height - 55, 110 * percent, 5), Color.cyan);
    }
}
