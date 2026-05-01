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
            // Определяем, сколько HP остается для этого сердечка
            // Каждое сердечко представляет 2 единицы здоровья
            int remainingHP = amount - (i * 2);

            if (remainingHP >= 2)
            {
                // Сердечко полностью заполнено
                initializedHearts[i].sprite = fullHeart;
            }
            else if (remainingHP == 1)
            {
                // Сердечко заполнено наполовину
                initializedHearts[i].sprite = halfHeart;
            }
            else
            {
                // Сердечко пустое
                initializedHearts[i].sprite = emptyHeart;
            }
        }
    }
    public void InitializeHearts(int maxHP)
    {
        initializedHearts = new Image[maxHP/2];
        for(int i = 0; i < maxHP/2; i++)
            initializedHearts[i] = Instantiate(heartPrefab, transform).GetComponent<Image>();
    }
}