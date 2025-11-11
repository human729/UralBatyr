using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public Dictionary<string, int> Resources = new Dictionary<string, int>();

    private static int LastKumisValue;
    private static int LastChakChakValue;

    [Header("References")]
    public PlayerBehaviour playerStats;

    [Header("UI")]
    public Text KumisText;
    public Text ChakChakText;

    private void Start()
    {
        Resources.Add("Kumis", 0);
        Resources.Add("ChakChak", 0);

        LastKumisValue = Resources["Kumis"];
        LastChakChakValue = Resources["ChakChak"];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Resources["Kumis"]++;
            Resources["ChakChak"] += 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Resources["Kumis"] > 0)
            {
                Resources["Kumis"]--;
                playerStats.Health += 50f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Resources["ChakChak"] > 0)
            {
                StartCoroutine(Buff());
                Resources["ChakChak"]--;
            }
        }

        if (Resources["Kumis"] != LastKumisValue || Resources["ChakChak"] != LastChakChakValue)
        {
            LastKumisValue = Resources["Kumis"];
            LastChakChakValue = Resources["ChakChak"];
            KumisText.text = LastKumisValue.ToString();
            ChakChakText.text = LastChakChakValue.ToString();
        }
    }

    IEnumerator Buff()
    {
        playerStats.BowDamage += 2.5f;
        playerStats.SpearDamage += 5f;
        yield return new WaitForSeconds(45f);
        playerStats.BowDamage -= 2.5f;
        playerStats.SpearDamage -= 5f;
    }
}
