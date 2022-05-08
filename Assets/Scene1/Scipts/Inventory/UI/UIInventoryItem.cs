using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image _imageIcon;
    public IInventoryItem item { get; private set; }
    [SerializeField] Text _textAmount;
    [SerializeField] Text titleInfo;
    [SerializeField] Text textInfo;
    bool isActive;
    public void Refresh(IInventorySlot slot)
    {
        if (slot.isEmpty)
        {
            Cleanup();
            return;
        }
        item = slot.item;
        _imageIcon.sprite = item.info.spriteIcon;
        _imageIcon.gameObject.SetActive(true);
        var textAmountEnabled = slot.amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);
        if (textAmountEnabled)
        {
            _textAmount.text = $"x{slot.amount.ToString()}";
        }
    }
    void Cleanup()
    {
        _imageIcon.gameObject.SetActive(false);
        _textAmount.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        titleInfo.text = item.info.title;
        textInfo.text = item.info.discription;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
