using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitInfoPanel : MonoBehaviour
{
    public Image fruitImage;              // ������ʾˮ��ͼƬ��UI���
    public TMP_Text fruitDescriptionText; // ����ˮ�������ı�
    public Sprite[] fruitSprites;         // ˮ����ͼƬ����

    private string[] fruitDescriptions = new string[3]  // ˮ������������
    {
        "Flex Orange is a small orange that is passionate about fitness. Despite being stuck in the fridge for a long time, he has never given up on working out. In the cold environment of the fridge, he continued strength training, building a powerful physique. Refusing to accept a fate of being forgotten, Flex Orange is determined to escape the fridge and head to a more professional gym. For Flex Orange, fitness is not only about staying in shape but also a way to prove his self worth.",

        "Mad Berry is a hot tempered and fragile blueberry. The slightest bump can make him explode in anger. During his long journey in transportation, Mad Berry was constantly jostled around, which only fueled his rage. Though small in size, his fury is enough to destroy anything in his way. Being trapped in the fridge only made him angrier, and now his determined to break free and find new freedom.",

        "Crush Apple is a dreamy apple, filled with romantic fantasies. She grew up under the fear of an apple a day keeps the doctor away, but instead of feeling anxious, she longs for the beauty of life. Whether it is handsome men or beautiful women, Crush Apple is always eager to witness the wonders of the world. Confined in the fridge, she feels lost and helpless, unable to find anything beautiful. Now, Crush Apple has made up her mind to escape and explore the outside world, seeking the beauty and romance she dreams of."
    };

    private void Start()
    {
        // �ڿ�ʼʱ����ˮ��ͼƬ
        fruitImage.gameObject.SetActive(false);
    }

    // �л�ˮ��������ͼƬ
    public void SelectFruit(int fruitIndex)
    {
        if (fruitIndex >= 0 && fruitIndex < fruitSprites.Length)
        {
            fruitImage.sprite = fruitSprites[fruitIndex];  // ����ˮ��ͼƬ
            fruitDescriptionText.text = fruitDescriptions[fruitIndex];  // ����ˮ������

            // ��ʾˮ��ͼƬ
            fruitImage.gameObject.SetActive(true);
        }
    }
}
