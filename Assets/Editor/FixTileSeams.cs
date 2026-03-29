using UnityEditor;
using UnityEngine;

public class FixTileSeams
{
    [MenuItem("Tools/Fix Tile Seams")]
    public static void Fix()
    {
        string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/Simple 2D Platformer BE2/Sprites" });
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (importer == null) continue;

            importer.filterMode = FilterMode.Point;
            importer.mipmapEnabled = false;
            EditorUtility.SetDirty(importer);
            importer.SaveAndReimport();
            Debug.Log($"Fixed: {path}");
        }

        Debug.Log("Tile seam fix complete.");
    }
}
