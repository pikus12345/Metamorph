using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite halfHeart;
    [SerializeField] private Sprite emptyHeart;

    private Image[] initializedHearts = null;
    public void Display(int amount, int maxHP)
    {
        if (initializedHearts == null)
        {
            InitializeHearts(maxHP);
        }
        for (int i = 0; i < initializedHearts.Length; i++)
        {
            if (maxHP / 2 == i)
                initializedHearts[i].sprite = halfHeart;
            else if (maxHP / 2 > i)
                initializedHearts[i].sprite = fullHeart;
            else
                initializedHearts[i].sprite = emptyHeart;
        }
    }
    public void InitializeHearts(int maxHP)
    {
        initializedHearts = new Image[maxHP/2];
        for(int i = 0; i < maxHP/2; i++)
            initializedHearts[i] = Instantiate(heartPrefab, transform).GetComponent<Image>();
    }
}