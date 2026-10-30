using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FuzzyProgram : MonoBehaviour
{

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
        int attemptedDivisionValue = (PlayerPrefs.GetInt("attempt_level_1") + PlayerPrefs.GetInt("attempt_level_2"));
        int jumpDivisionValue = (PlayerPrefs.GetInt("amount_level_one_jump") + PlayerPrefs.GetInt("amount_level_two_jump"));

        float[] membershipAttemptValues = CalculateMembershipAttempt(attemptedDivisionValue);
        float[] membershipJumpValues = CalculateMembershipJump(jumpDivisionValue);

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

        //deffuzifikasi

        for (int i = 0; i < result.Count; i++)
        {
            float perkalian = result[i][0, 0] * result[i][1, 0];
            float pembagian = result[i][0, 0];

            perkalian_new += perkalian;
            Debug.Log(perkalian + "perkalian ");
            pembagian_new += pembagian;

        }
        Debug.Log(perkalian_new + " / " + pembagian_new);
        float z = perkalian_new / pembagian_new;
        PlayerPrefs.SetFloat("result_deffuzifikasi", z);
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
        if (value > 0 && value <= 40)
        {
            value_sedikit = 1f;
        }
        else if (value > 40 && value <= 80)
        {
            value_sedikit = (80f - value) / 40f;
            value_cukup = (value - 40f) / 40f;
        }
        else if (value > 80 && value <= 120)
        {
            value_cukup = (120f - value) / 40f;
            value_banyak = (value - 80f) / 40f;
        }
        else if (value >= 120)
        {
            value_banyak = 1f;
        }
        return new float[] { value_sedikit, value_cukup, value_banyak };
    }
    private float[] CalculateMembershipJump(int value)
    {

        if (value > 0 && value <= 105)
        {
            value_jarang = 1f;
        }
        else if (value > 105 && value <= 175)
        {
            value_jarang = (175f - value) / 70f;
            value_lumayan = (value - 105f) / 70f;
        }
        else if (value > 175 && value <= 280)
        {
            value_lumayan = (280f - value) / 105f;
            value_sering = (value - 175f) / 105f;
        }
        else if (value >= 280)
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
                result.Add(new float[,] { { hasil_output }, { 6 } });
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
                result.Add(new float[,] { { hasil_output }, { 14 } });
            }
        }
    }
}
