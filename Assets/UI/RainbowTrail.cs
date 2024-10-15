using UnityEngine;

public class RainbowTrail : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();

        // 创建一个彩虹颜色渐变
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.red, 0.0f),
                new GradientColorKey(Color.yellow, 0.2f),
                new GradientColorKey(Color.green, 0.4f),
                new GradientColorKey(Color.cyan, 0.6f),
                new GradientColorKey(Color.blue, 0.8f),
                new GradientColorKey(Color.magenta, 1.0f)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),  // 完全不透明
                new GradientAlphaKey(0.0f, 1.0f)   // 完全透明
            }
        );

        // 应用渐变到 Trail Renderer
        trailRenderer.colorGradient = gradient;
    }
}

