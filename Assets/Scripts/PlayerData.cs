using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Create Player Scriptable Object", order = 0)]
public class PlayerData : ScriptableObject
{
    public KeyCode KeyForward;
    public KeyCode KeyRight;
    public KeyCode KeyLeft;
    public KeyCode KeyFire;
    public Color PlayerColor = Color.white;
}
