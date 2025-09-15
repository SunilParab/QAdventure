using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField]
    IntroText intro;

    public bool talking;

    public static GameState reference;

    void Awake()
    {
        reference = this;
    }

    public bool PlayerPaused()
    {
        return talking;
    }

}
