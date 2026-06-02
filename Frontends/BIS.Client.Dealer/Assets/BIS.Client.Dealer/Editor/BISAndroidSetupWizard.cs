#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class BISAndroidSetupWizard
{
    [MenuItem("BIS/Run Android Setup (Pixel 5a)")]
    public static void ApplySettings()
    {
        Debug.Log("Starting Android Setup for Pixel 5a...");

        // 1. Switch Platform to Android
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        // 2. Company, Product, Package Name
        PlayerSettings.companyName = "Evergloam";
        PlayerSettings.productName = "BIS.Client.Dealer";
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "xyz.evergloam.bis.client.dealer");

        // 3. Orientation (Landscape)
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
        PlayerSettings.allowedAutorotateToLandscapeLeft = true;
        PlayerSettings.allowedAutorotateToLandscapeRight = true;
        PlayerSettings.allowedAutorotateToPortrait = false;
        PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;

        // 4. Architecture & Scripting Backend for Pixel 5a (64-bit IL2CPP)
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
        
        // API Level (Pixel 5a starts at Android 11 API 30)
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel30;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;

        // 5. Network (Cleartext HTTP)
        PlayerSettings.insecureHttpOption = InsecureHttpOption.AlwaysAllowed;

        // Save
        AssetDatabase.SaveAssets();
        
        Debug.Log("Android Setup for Pixel 5a Completed Successfully!");
        
        if (Application.isBatchMode)
        {
            EditorApplication.Exit(0);
        }
    }
}
#endif
