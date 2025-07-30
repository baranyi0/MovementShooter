using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public int point = 0;

    public Text counterText;


    //----------------------------------------
    // instance: ak�rhonnan el�rem ennek a scriptnek a met�dusait, tulajdons�gait
    // egy PointCounter.Instance h�v�ssal! L�sd Weapon script 53. sor!

    public static PointCounter Instance;
    private void Awake()
    {
        Instance = this;
    }

    //----------------------------------------

    private void Start()
    {
        counterText.text = point.ToString();
    }

    public void AddPoint(int amount)
    {
        point += amount;
        counterText.text = point.ToString();
    }
}
