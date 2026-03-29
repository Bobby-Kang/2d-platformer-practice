using UnityEditor;
using UnityEngine;

public class SetupPlayerJump
{
    [MenuItem("Tools/Setup Player Jump")]
    public static void Setup()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) { Debug.LogError("Player not found"); return; }

        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm == null) { Debug.LogError("PlayerMovement not found"); return; }

        // GroundCheck 연결
        Transform groundCheck = player.transform.Find("GroundCheck");
        if (groundCheck != null)
            pm.groundCheck = groundCheck;

        // Ground 레이어 마스크 설정
        pm.groundLayer = LayerMask.GetMask("Ground");

        EditorUtility.SetDirty(player);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(player.scene);
        Debug.Log("Player jump setup complete!");
    }
}
