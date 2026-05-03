using TMPro;
using UnityEngine;

public class MorphUI : MonoBehaviour
{
    private MorphManager morphManager;
    [SerializeField] private TMP_Text rafRemainText;
    [SerializeField] private GameObject rafRemainContainer;
    [SerializeField] private GameObject knightIcon;
    [SerializeField] private GameObject lizardIcon;
    [SerializeField] private GameObject ogreIcon;
    private void Awake()
    {
        morphManager = FindAnyObjectByType<MorphManager>();
    }
    private void Update()
    {
        rafRemainText.text = morphManager.RafRemain.ToString();
    }
    public void OpenKnightMorph()
    {
        knightIcon.SetActive(true);
        rafRemainContainer.SetActive(true);
    }
    public void OpenLizardMorph()
    {
        lizardIcon.SetActive(true);
        rafRemainContainer.SetActive(true);
    }
    public void OpenOgreMorph()
    {
        ogreIcon.SetActive(true);
        rafRemainContainer.SetActive(true);
    }

}
