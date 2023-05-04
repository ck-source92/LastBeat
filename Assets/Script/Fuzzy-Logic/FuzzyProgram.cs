using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyProgram : MonoBehaviour
{
    // Attempt = Sedikit , Cukup , Banyak
    // Jump = Jarang , Lumayan , Sering

    public List<float[,]> result = new List<float[,]>();

    private string[] attempsVariable = new string[] { "sedikit", "cukup", "banyak" };
    private string[] jumpsVariable = new string[] { "jarang", "lumayan", "sering" };

    float value_sedikit = 0f;
    float value_cukup = 0f;
    float value_banyak = 0f;

    float value_jarang = 0f;
    float value_lumayan = 0f;
    float value_sering = 0f;

    float perkalian_new = 0f;
    float pembagian_new = 0f;
    private void Start()
    {
        float[] membershipAttemptValues = CalculateMembershipAttempt(55);
        float[] membershipJumpValues = CalculateMembershipJump(60);

        OutputMemberships(membershipAttemptValues, membershipJumpValues);

        UnbeatInterfensi(value_sedikit, value_jarang);
        UnbeatInterfensi(value_sedikit, value_lumayan);
        UpbeatInterfensi(value_sedikit, value_sering);

        UnbeatInterfensi(value_cukup, value_jarang);
        UnbeatInterfensi(value_cukup, value_lumayan);
        UpbeatInterfensi(value_cukup, value_sering);

        UnbeatInterfensi(value_banyak, value_jarang);
        UnbeatInterfensi(value_banyak, value_lumayan);
        UpbeatInterfensi(value_banyak, value_sering);

        for (int i = 0; i < result.Count; i++)
        {
            float value = result[i][0, 0];
            float time = result[i][1, 0];
            // 0.666 * 30
            float perkalian = result[i][0, 0] * result[i][1, 0];
            // Debug.Log("perkalian : " + perkalian);
            float pembagian = result[i][0, 0];
            // Debug.Log("pembagian : " + pembagian);

            perkalian_new += perkalian;
            pembagian_new += pembagian;
        }
        Debug.Log(perkalian_new + " / " + pembagian_new);
        float z = perkalian_new / pembagian_new;
        Debug.Log($"z = {z}");
    }

    private void OutputMemberships(float[] membershipsAttemp, float[] membershipsJump)
    {
        string result = "";
        int ruleNumber = 1;
        for (int i = 0; i < membershipsAttemp.Length; i++)
        {
            for (int j = 0; j < membershipsJump.Length; j++)
            {
                string miuAttemptVariable = attempsVariable[i];
                string miuJumpVariable = jumpsVariable[j];
                float miu = Mathf.Min(membershipsAttemp[i], membershipsJump[j]);
                result += $"R {ruleNumber}: {miuAttemptVariable} = {membershipsAttemp[i]}, {miuJumpVariable} = {membershipsJump[j]}, miu = {miu}\n";
                ruleNumber++;
            }
        }
        Debug.Log(result);
    }

    private float[] CalculateMembershipAttempt(int value)
    {
        if (value > 0 && value <= 30)
        {
            value_sedikit = 1f;
        }
        else if (value > 30 && value <= 45)
        {
            value_sedikit = (45f - value) / 15f;
            value_cukup = (value - 30f) / 15f;
        }
        else if (value > 45 && value <= 75)
        {
            value_cukup = (75f - value) / 30f;
            value_banyak = (value - 45f) / 30f;
        }
        else if (value >= 75)
        {
            value_banyak = 1f;
        }
        return new float[] { value_sedikit, value_cukup, value_banyak };
    }
    private float[] CalculateMembershipJump(int value)
    {

        if (value > 0 && value <= 30)
        {
            value_jarang = 1f;
        }
        else if (value > 30 && value <= 50)
        {
            value_jarang = (50f - value) / 20f;
            value_lumayan = (value - 30f) / 20f;
        }
        else if (value > 50 && value <= 80)
        {
            value_lumayan = (80f - value) / 30f;
            value_sering = (value - 50f) / 30f;
        }
        else if (value >= 80)
        {
            value_sering = 1f;
        }

        return new float[] { value_jarang, value_lumayan, value_sering };
    }

    private void UnbeatInterfensi(float variable_attempt, float variable_jump)
    {
        if (variable_attempt != 0)
        {
            if (variable_jump != 0)
            {
                float hasil_output = Mathf.Min(variable_attempt, variable_jump);
                Debug.Log($"hasil output unbeat : {hasil_output}");
                result.Add(new float[,] { { hasil_output }, { 30 } });
            }
        }
    }

    private void UpbeatInterfensi(float variable_attempt, float variable_jump)
    {
        if (variable_attempt != 0)
        {
            if (variable_jump != 0)
            {
                float hasil_output = Mathf.Min(variable_attempt, variable_jump);
                Debug.Log($"hasil output upbeat : {hasil_output}");
                result.Add(new float[,] { { hasil_output }, { 70 } });
            }
        }
    }

}
