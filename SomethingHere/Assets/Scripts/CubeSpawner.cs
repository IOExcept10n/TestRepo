using Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Leaderboard leaders;

    public GameObject cube;
    public TextMeshProUGUI text;

    private void Start()
    {
        leaders = new();
        leaders.Load();
        UpdateText();
    }

    private void OnDestroy()
    {
        leaders.Save();
    }

    public void SpawnCube(CubeFallDetector previousCube)
    {
        //for (int i = 0; i < 1; i++)
        {
            var newCube = Instantiate(cube, transform.position, Quaternion.identity);
            var fallDetector = newCube.GetComponent<CubeFallDetector>();
            fallDetector.soundEffectSource = previousCube.soundEffectSource;
            fallDetector.spawner = previousCube.spawner;
            Leaderboard.Score++;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        StringBuilder builder = new();
        builder.AppendLine("Top:");
        int position = leaders.MyPosition();
        Debug.Log($"My position in top: {position}");
        for (int i = 0; i < leaders.Count; i++)
        {
            if (i == position)
            {
                builder.AppendLine($"You: {Leaderboard.Score}");
            }
            builder.AppendLine($"#{i + 1} {leaders[i]}");
        }
        if (leaders.Count == 0)
        {
            builder.AppendLine($"You: {Leaderboard.Score}");
        }
        text.text = builder.ToString();
    }
}
