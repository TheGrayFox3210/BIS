using System.IO;
using System.Linq;

using UnityEditor;
using UnityEngine;





namespace BIS
{
    public class BISPackageSyncBuilder : EditorWindow
    {
        private static string SharedProjectPath => Path.GetFullPath ( Path.Combine ( Application.dataPath, "../" ) );
        
        
        
        private static string FrontendsPath => Path.GetFullPath ( Path.Combine ( SharedProjectPath , "../" ) );
        
        
        
        private static readonly string[] TargetProjectNames = new string[]
        {
            "BIS.Client.Dealer",
        }; 
        
        

        private static readonly string[] ExcludeFolderNames = new string[]
        {
            "Editor" ,
            "Scenes" , 
        };
        
        
        
        private const string SourcePath = "Assets/BIS.Client.Shared";

        
        
        
        
        [MenuItem("BIS/Export and Sync All Packages")]
        public static void ExportAndSyncAll()
        {
            string srcFullPath = Path.GetFullPath ( Path.Combine ( SharedProjectPath , SourcePath ) );
            Debug.Log ( $"[PackageSync] '{SourcePath}' の直接上書き同期を開始します..." );

            try
            {
                int successCount = 0;
                foreach ( string folderName in TargetProjectNames )
                {
                    string projectPath = Path.Combine ( FrontendsPath , folderName );

                    if ( !Directory.Exists ( projectPath ) )
                    {
                        Debug.LogWarning ( $"[PackageSync] ⚠️ プロジェクトが見つからないためスキップしました: {projectPath}" );
                        continue;
                    }

                    string destFullPath = Path.Combine ( projectPath , SourcePath );

                    if ( Directory.Exists ( destFullPath ) )
                        Directory.Delete ( destFullPath , true );

                    CopyDirectory ( srcFullPath , destFullPath );

                    Debug.Log ( $"[PackageSync]  成功（フォルダ直接コピー） ➔ {folderName}" );
                    successCount ++;
                }

                Debug.Log ( $"[PackageSync] 🎉 すべて完了しました！ (成功: {successCount} / 全体: {TargetProjectNames.Length})" );
            }
            catch ( System.Exception exception )
            {
                Debug.LogError ( $"[PackageSync] 同期中に致命的なエラーが発生しました: {exception.Message}" );
            }
        }

        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            string[] files = Directory.GetFiles ( sourceDir );

            var excludeMetaNames = ExcludeFolderNames.Select ( name => name + ".meta" ).ToArray ( );

            var validFiles = files.Where ( file =>
            {
                string fileName = Path.GetFileName ( file );
                return !excludeMetaNames.Contains ( fileName );
            } ).ToArray ( );

            if (validFiles.Length > 0)
            {
                Directory.CreateDirectory ( destinationDir );
                foreach ( string file in validFiles )
                {
                    string destFile = Path.Combine ( destinationDir , Path.GetFileName ( file ) );
                    File.Copy ( file , destFile , true );
                }
            }

            foreach ( string subDir in Directory.GetDirectories ( sourceDir ) )
            {
                string dirName = Path.GetFileName ( subDir );

                if ( ExcludeFolderNames.Contains ( dirName ) )
                {
                    Debug.Log ( $"[PackageSync] 🚫 フォルダとメタファイルを完全に除外しました: {dirName}" );
                    continue;
                }

                string destSubDir = Path.Combine ( destinationDir , dirName );
                
                if (!Directory.Exists ( destinationDir ) )
                {
                    Directory.CreateDirectory ( destinationDir );
                }

                CopyDirectory ( subDir , destSubDir );
            }
        }
    }
}