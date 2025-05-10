using System.IO;
using System.Reflection;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;

namespace LightShaftsPlugin
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class LightShaftsPlugin : BaseUnityPlugin
    {
        internal const string PLUGIN_GUID = "RSkoi.robcupisz.LightShafts";
        internal const string PLUGIN_NAME = "LightShafts";
        internal const string PLUGIN_VERSION = "1.0.3";

        internal static LightShaftsPlugin _instance;
        internal static ManualLogSource _logger;

        #region materials for shaders
        private static Material _matColorFilter;
        private static Material _matCoord;
        private static Material _matDepth;
        private static Material _matDepthTransparent;
        private static Material _matDepthTransparentCutout;
        private static Material _matDepthBreaks;
        private static Material _matFinalInterpolation;
        private static Material _matInterpolateAlongRays;
        private static Material _matRaymarch;
        private static Material _matSamplePositions;
        #endregion

        #region shaders
        internal static Shader _ColorFilter;
        internal static Shader _Coord;
        internal static Shader _Depth;
        internal static Shader _DepthTransparent;
        internal static Shader _DepthTransparentCutout;
        internal static Shader _DepthBreaks;
        internal static Shader _FinalInterpolation;
        internal static Shader _InterpolateAlongRays;
        internal static Shader _Raymarch;
        internal static Shader _SamplePositions;
        #endregion

        internal void Awake()
        {
            _instance = this;
            _logger = Logger;
        }

        internal void Start()
        {
            LoadShaderResources();
            CacheShaders();
        }

        private void LoadShaderResources()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.lightshafts.unity3d");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            AssetBundle ab              = AssetBundle.LoadFromMemory(buffer);
            _matColorFilter             = ab.LoadAsset<Material>("ls_ColorFilter");
            _matCoord                   = ab.LoadAsset<Material>("ls_Coord");
            _matDepth                   = ab.LoadAsset<Material>("ls_Depth");
            _matDepthTransparent        = ab.LoadAsset<Material>("ls_DepthTransparent");
            _matDepthTransparentCutout  = ab.LoadAsset<Material>("ls_DepthTransparentCutout");
            _matDepthBreaks             = ab.LoadAsset<Material>("ls_DepthBreaks");
            _matFinalInterpolation      = ab.LoadAsset<Material>("ls_FinalInterpolation");
            _matInterpolateAlongRays    = ab.LoadAsset<Material>("ls_InterpolateAlongRays");
            _matRaymarch                = ab.LoadAsset<Material>("ls_Raymarch");
            _matSamplePositions         = ab.LoadAsset<Material>("ls_SamplePositions");

            stream.Close();
        }

        private void CacheShaders()
        {
            _ColorFilter            = _matColorFilter.shader;
            _Coord                  = _matCoord.shader;
            _Depth                  = _matDepth.shader;
            _DepthTransparent       = _matDepthTransparent.shader;
            _DepthTransparentCutout = _matDepthTransparentCutout.shader;
            _DepthBreaks            = _matDepthBreaks.shader;
            _FinalInterpolation     = _matFinalInterpolation.shader;
            _InterpolateAlongRays   = _matInterpolateAlongRays.shader;
            _Raymarch               = _matRaymarch.shader;
            _SamplePositions        = _matSamplePositions.shader;
        }
    }
}
