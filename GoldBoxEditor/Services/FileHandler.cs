using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBoxEditor.Services
{
    static public class Filehandler
    {
        static public bool LogEnabled = false;

        public static void Log(string text)
        {
            if (LogEnabled)
                try
                {
                    //Debug.Log(text);
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    //string logFile = path + @"\log.log";
                    string logFile = path + Path.DirectorySeparatorChar + @"log.log";

                    List<string> log = new List<string>();

                    if (!File.Exists(logFile))
                        File.Create(logFile);
                    else
                        log = File.ReadAllLines(logFile).ToList();

                    log.Insert(0, DateTime.Now.ToString("T") + ": " + text);

                    File.WriteAllLines(logFile, log);
                    //File.WriteAllLines("log.log", log);
                }
                catch (Exception e)
                {
                    //Debug.LogError("Exception thrown in Filehandler.Log(): " + e.Message);
                }

        }

        public static void SaveBytesToFile(byte[] data, string fileName)
        {
            if (data == null || !data.Any())
            {
                Log("No byte data for " + fileName);
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string file = path + Path.DirectorySeparatorChar + fileName;
            //string file = path + @"\" + fileName;

            // File.Create(file);
            if (File.Exists(file))
            {
                var fileInfo = new System.IO.FileInfo(file);
                if (fileInfo.Length > 0)
                    return;
            }

            Log("Saving datafile " + fileName + " having this many bytes: " + data.Length);
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize()

            File.WriteAllBytes(file, data);

            Log(fileName + " saved.");
        }

        public static GoldBoxData LoadGoldBoxData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFile = path + Path.DirectorySeparatorChar + @"GoldBoxData.json";

            Log($"Loading appobjects from json file");
            string json = "";

            if (File.Exists(jsonFile))
                json = File.ReadAllText(jsonFile);
            else return new GoldBoxData();

            var output = JsonConvert.DeserializeObject<GoldBoxData>(json);

            Log($"Loaded GoldBoxData");//{output.Count}
            return output;
        }

        public static void SaveGoldBoxData(GoldBoxData data)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFile = path + Path.DirectorySeparatorChar + @"GoldBoxData.json";

            Log($"Making GoldBoxData into json file");

            if (!File.Exists(jsonFile))
                File.Create(jsonFile);

            Log("File created");

            var output = JsonConvert.SerializeObject(data);

            //JsonConvert.SerializeObject(appLibrary);
            //JsonUtility.ToJson(appLibrary);
            File.WriteAllText(jsonFile, output);

            Log($"GoldBoxData.json file serialized.");
        }

        public static void AddAppToLibrary(string name, string callname = "")
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFile = path + Path.DirectorySeparatorChar + @"appLibrary.json";

            Log($"Adding {name} to appLibrary with callname {callname}");

            if (!File.Exists(jsonFile))
                File.Create(jsonFile);

            Log("File created");

            string json = File.ReadAllText(jsonFile);

            Dictionary<string, string> appLibrary = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(json))
            {
                Log($"Deserializing applibrary to add {name}");
                appLibrary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                //JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            //JsonUtility.FromJson<Dictionary<string, string>>(json);

            if (appLibrary.ContainsKey(name) && !string.IsNullOrWhiteSpace(callname))
            {
                Log($"Removing {name}");
                appLibrary.Remove(name);
            }
            if (appLibrary.ContainsKey(name) && string.IsNullOrWhiteSpace(callname))
            {
                Log($"{name} already exists in app library and callname is null or whitespace.");
                return;
            }

            appLibrary.Add(name, callname);
            var output = JsonConvert.SerializeObject(appLibrary);

            //JsonConvert.SerializeObject(appLibrary);
            //JsonUtility.ToJson(appLibrary);
            File.WriteAllText(jsonFile, output);

            Log($"Added {name} to appLibrary with callname {callname}");
        }

        //public static Sprite LoadImage(AppObject appObject)
        //{
        //    string path = Application.persistentDataPath;

        //    Log($"Loading image {appObject.Images.First()}");

        //    string filePath = path + Path.DirectorySeparatorChar + appObject.Images.First();
        //    Log($"Image path {path}");
        //    //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //    //AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");

        //    Texture2D tex = null;
        //    byte[] fileData;

        //    Rect rect = new Rect(0, 0, 0, 0);

        //    if (File.Exists(filePath))
        //    {
        //        Log($"Reading bytes from image {filePath}");
        //        fileData = File.ReadAllBytes(filePath);
        //        tex = new Texture2D(2, 2);
        //        Log($"Loading image into texture");
        //        tex.LoadImage(fileData);
        //        rect = new Rect(0, 0, tex.width, tex.height);
        //    }
        //    else
        //    {
        //        Log($"File not found  {filePath}");
        //        return null;
        //    }

        //    var sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));

        //    Log($"Returning sprite");

        //    return sprite;

        //    //    var result = await GetAppIconAsync(path, installedApkIndex, 1024 * 1024);
        //    //var image = result.Item1;
        //    //var imageWidth = result.Item2;
        //    //var imageHeight = result.Item3;

        //    //Texture2D texture = null;

        //    //if (null == image)
        //    //{
        //    //    Debug.LogFormat("Error loading icon: Path: {0}, Index: {1}", this.externalIconPath, this.installedApkIndex);
        //    //    return;
        //    //}

        //    //// Set the icon image
        //    //if (imageWidth == 0 || imageHeight == 0)
        //    //{
        //    //    texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        //    //    texture.filterMode = FilterMode.Trilinear;
        //    //    texture.anisoLevel = 16;
        //    //    texture.LoadImage(image);
        //    //}
        //    //else
        //    //{
        //    //    texture = new Texture2D(imageWidth, imageHeight, TextureFormat.ARGB32, false);
        //    //    texture.filterMode = FilterMode.Trilinear;
        //    //    texture.anisoLevel = 16;
        //    //    texture.LoadRawTextureData(image);
        //    //    texture.Apply();
        //    //}

        //    //var rect = new Rect(0, 0, texture.width, texture.height);
        //    //this.image.sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        //    //this.image.color = Color.white;

        //    //// Preserve icon's aspect ratio
        //    //this.aspectRatioFitter.aspectRatio = (float)texture.width / (float)texture.height;
        //}

        /// <summary>
        /// Loads an app icon asynchronously, either from specified external icon path or, if path is not provided or fails to load,
        /// falls back to loading the icon from the apk itself.
        /// </summary>
        /// <param name="iconPath">External icon path</param>
        /// <param name="appIndex">App index (used when falling back to loading icon from APK)</param>
        /// <param name="maxPixels">Max pixels - image will be scaled down if larger than this size</param>
        /// <returns>Icon bytes and dimensions</returns>
        //public static async Task<(byte[], int, int)> GetAppIconAsync(string iconPath, int appIndex, int maxPixels)
        //{
        //    if (null != iconPath)
        //    {
        //        // Load icon from file path
        //        try
        //        {
        //            return await LoadRawImageAsync(iconPath, maxPixels);
        //        }
        //        catch (Exception e)
        //        {
        //            // Fall back to using the apk icon
        //            Debug.LogFormat("Error reading app icon from file [{0}]: {1}", iconPath, e.Message);
        //        }
        //    }

        //    byte[] bytesIcon = null;
        //    await Task.Run(() =>
        //    {
        //        AndroidJNI.AttachCurrentThread();

        //        try
        //        {
        //            // Use built-in icon from the apk
        //            using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        //            using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
        //            {
        //                bytesIcon = (byte[])(Array)currentActivity.Call<sbyte[]>("getIcon", appIndex);
        //            }
        //        }
        //        finally
        //        {
        //            AndroidJNI.DetachCurrentThread();
        //        }
        //    });

        //    return (bytesIcon, 0, 0);
        //}

        //string output = File.ReadAllText(path + @"\oculus_home_app_testfile.txt");
        //Debug.Log("Text found in file: " + output);
        //scrollText.text += "Text found in file: " + output;

        //File.WriteAllText(path + @"\oculus_home_app_testfile2.txt", "testtesttest");
        //output = File.ReadAllText(path + @"\oculus_home_app_testfile2.txt");
        //Debug.Log("Text found in file: " + output);
        //scrollText.text += "Text found in file: " + output;
    }
}
