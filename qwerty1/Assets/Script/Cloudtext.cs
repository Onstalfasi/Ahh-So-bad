using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WordCloud3D : MonoBehaviour
{
    public GameObject wordPrefab;
    public List<string> words = new List<string>();
    public List<int> frequencies = new List<int>();

    public float radius = 5f;
    public Vector2 scaleRange = new Vector2(0.5f, 3f);
    public int maxWords = 100;

    void Start()
    {
        Generate3DWordCloud();
    }

    void Generate3DWordCloud()
    {
        var sortedWords = words.Zip(frequencies, (w, f) => new { Word = w, Freq = f })
                              .OrderByDescending(x => x.Freq)
                              .Take(maxWords)
                              .ToList();

        foreach (var item in sortedWords)
        {
            GameObject wordObj = Instantiate(wordPrefab, transform);
            TextMeshPro tmp = wordObj.GetComponent<TextMeshPro>();

            tmp.text = item.Word;
            float scale = Mathf.Lerp(scaleRange.x, scaleRange.y,
                                   (float)item.Freq / sortedWords[0].Freq);
            wordObj.transform.localScale = Vector3.one * scale;

            // Размещение на сфере
            wordObj.transform.localPosition = Random.onUnitSphere * radius;

            // Направление к центру
            wordObj.transform.LookAt(transform.position);
            wordObj.transform.Rotate(0, 180, 0);
        }
    }
}