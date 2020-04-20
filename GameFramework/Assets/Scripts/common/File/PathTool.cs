using UnityEngine;
using System.Collections;
using System.Text;

public class PathTool
{
    public static string GetPath(ResLoadLocation loadType)
    {
        using (ZString.Block())
        {
            string path = string.Empty;
            switch (loadType)
            {
                case ResLoadLocation.Resource:
#if UNITY_EDITOR
                    path= ZString.Concat(Application.dataPath, "/Resources/");
                    break;
#endif

                case ResLoadLocation.Streaming:

#if UNITY_ANDROID && !UNITY_EDITOR
                    path = ZString.Concat(Application.dataPath, "!assets/");
#else
                    path = ZString.Concat(Application.streamingAssetsPath, "/");
#endif
                    break;

                case ResLoadLocation.Persistent:
                    path = ZString.Concat(Application.persistentDataPath, "/");
                    break;

                case ResLoadLocation.Catch:
                    path = ZString.Concat(Application.temporaryCachePath, "/");
                    break;

                default:
                    Debug.LogError("Type Error !" + loadType);
                    break;
            }
            return path;
        }
    }
    /// <summary>
    /// 更新资源存放在Application.persistentDataPath+"/Resources/"目录下
    /// </summary>
    /// <returns></returns>
    public static string GetAssetsBundlePersistentPath()
    {
        using (ZString.Block())
        {
           return ZString.Concat(Application.persistentDataPath, "/Resources/");
        }
    }

    /// <summary>
    /// 组合绝对路径
    /// </summary>
    /// <param name="loadType">资源加载类型</param>
    /// <param name="relativelyPath">相对路径</param>
    /// <returns>绝对路径</returns>
    public static string GetAbsolutePath(ResLoadLocation loadType, string relativelyPath)
    {
        using (ZString.Block())
        {
            return ZString.Concat(GetPath(loadType), relativelyPath);
        } 
    }

    //获取相对路径
    public static string GetRelativelyPath(string path, string fileName, string expandName)
    {
        using (ZString.Block())
        {
            return ZString.Concat(path, "/", fileName, ".", expandName);
        }
    }



    /// <summary>
    /// 获取编辑器下的路径
    /// </summary>
    /// <param name="directoryName">目录名</param>
    /// <param name="fileName">文件名</param>
    /// <param name="expandName">拓展名</param>
    /// <returns></returns>
    public static string GetEditorPath(string directoryName, string fileName, string expandName)
    {
        using (ZString.Block())
        {
            return ZString.Concat(Application.dataPath, "/Editor", directoryName, "/", fileName, ".", expandName);
        }
    }
}
