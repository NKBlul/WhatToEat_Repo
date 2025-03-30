using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/FoodSO")]
public class FoodSO : ScriptableObject
{
    public string foodName;
    public Sprite foodIcon;
}
