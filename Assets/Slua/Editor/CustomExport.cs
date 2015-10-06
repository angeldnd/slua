// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SLua
{
	using System.Collections.Generic;
	using System;

    /* yjpark changes begin */
    using angeldnd.dap;
    using angeldnd.dap.util;
    using angeldnd.dap.unity;
    using angeldnd.dap.unity.util;
    using angeldnd.dap.lua;
    /* yjpark changes end */

	public class CustomExport
	{

		public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
		{
			add(typeof(System.Func<int>), null);
			add(typeof(System.Action<int, string>), null);
			add(typeof(System.Action<int, Dictionary<int, object>>), null);
			add(typeof(List<int>), "ListInt");
			add(typeof(Dictionary<int, string>), "DictIntStr");
			add(typeof(string), "String");
			// add your custom class here
			// add( type, typename)
			// type is what you want to export
			// typename used for simplify generic type name or rename, like List<int> named to "ListInt", if not a generic type keep typename as null or rename as new type name
            /* yjpark changes begin */
            // DapCore
            add(typeof(Pass), null);
            add(typeof(Data), null);
            add(typeof(EventChecker), null);
            add(typeof(EventListener), null);
            add(typeof(RequestChecker), null);
            add(typeof(RequestListener), null);
            add(typeof(ResponseListener), null);
            add(typeof(RequestHandler), null);
            add(typeof(BlockEventChecker), null);
            add(typeof(BlockEventListener), null);
            add(typeof(BlockRequestChecker), null);
            add(typeof(BlockRequestListener), null);
            add(typeof(BlockResponseListener), null);
            add(typeof(BlockRequestHandler), null);
            add(typeof(Handler), null);
            add(typeof(Handlers), null);
            add(typeof(Channel), null);
            add(typeof(Channels), null);
            add(typeof(Entity), null);
            add(typeof(Context), null);
            add(typeof(Item), null);
            add(typeof(Registry), null);
            add(typeof(Properties), null);
            add(typeof(BoolProperty), null);
            add(typeof(BoolBlockValueChecker), null);
            add(typeof(BoolBlockValueWatcher), null);

            //SILP:EXPORT_PROPERTY(Bool)
            add(typeof(BoolProperty), null);                          //__SILP__
            add(typeof(BoolBlockValueChecker), null);                 //__SILP__
            add(typeof(BoolBlockValueWatcher), null);                 //__SILP__
            //SILP:EXPORT_PROPERTY(Int)
            add(typeof(IntProperty), null);                           //__SILP__
            add(typeof(IntBlockValueChecker), null);                  //__SILP__
            add(typeof(IntBlockValueWatcher), null);                  //__SILP__
            //SILP:EXPORT_PROPERTY(Long)
            add(typeof(LongProperty), null);                          //__SILP__
            add(typeof(LongBlockValueChecker), null);                 //__SILP__
            add(typeof(LongBlockValueWatcher), null);                 //__SILP__
            //SILP:EXPORT_PROPERTY(Float)
            add(typeof(FloatProperty), null);                         //__SILP__
            add(typeof(FloatBlockValueChecker), null);                //__SILP__
            add(typeof(FloatBlockValueWatcher), null);                //__SILP__
            //SILP:EXPORT_PROPERTY(Double)
            add(typeof(DoubleProperty), null);                        //__SILP__
            add(typeof(DoubleBlockValueChecker), null);               //__SILP__
            add(typeof(DoubleBlockValueWatcher), null);               //__SILP__
            //SILP:EXPORT_PROPERTY(String)
            add(typeof(StringProperty), null);                        //__SILP__
            add(typeof(StringBlockValueChecker), null);               //__SILP__
            add(typeof(StringBlockValueWatcher), null);               //__SILP__
            //SILP:EXPORT_PROPERTY(Data)
            add(typeof(DataProperty), null);                          //__SILP__
            add(typeof(DataBlockValueChecker), null);                 //__SILP__
            add(typeof(DataBlockValueWatcher), null);                 //__SILP__

            add(typeof(ResponseHelper), null);

            // DapLua
            add(typeof(LuaHelper), null);

            /* yjpark changes end */
		}

		public static void OnAddCustomAssembly(ref List<string> list)
		{
			// add your custom assembly here
			// you can build a dll for 3rd library like ngui titled assembly name "NGUI", put it in Assets folder
			// add it's name into list, slua will generate all exported interface automatically for you

			//list.Add("NGUI");
		}

		// if uselist return a white list, don't check noUseList(black list) again
		public static void OnGetUseList(out List<string> list)
		{
            /* yjpark changes begin
			list = new List<string>
			{
			};
            */
            list = new List<string>();

            List<string> names = new List<string> {
                "Object", "GameObject",
                "Behaviour", "MonoBehaviour",
                "Vector2", "Vector3", "Vector4",
                "Color",
                "Rect",
                "Random",
            };

            foreach (var name in names) {
                list.Add("UnityEngine." + name);
            }
            /* yjpark changes end */
		}

		// black list if white list not given
		public static void OnGetNoUseList(out List<string> list)
		{
			list = new List<string>
        {      
            "HideInInspector",
            "ExecuteInEditMode",
            "AddComponentMenu",
            "ContextMenu",
            "RequireComponent",
            "DisallowMultipleComponent",
            "SerializeField",
            "AssemblyIsEditorAssembly",
            "Attribute", 
            "Types",
            "UnitySurrogateSelector",
            "TrackedReference",
            "TypeInferenceRules",
            "FFTWindow",
            "RPC",
            "Network",
            "MasterServer",
            "BitStream",
            "HostData",
            "ConnectionTesterStatus",
            "GUI",
            "EventType",
            "EventModifiers",
            "FontStyle",
            "TextAlignment",
            "TextEditor",
            "TextEditorDblClickSnapping",
            "TextGenerator",
            "TextClipping",
            "Gizmos",
             "ADBannerView",
            "ADInterstitialAd",            
            "Android",
            "jvalue",
            "iPhone",
            "iOS",
            "CalendarIdentifier",
            "CalendarUnit",
            "CalendarUnit",
            "FullScreenMovieControlMode",
            "FullScreenMovieScalingMode",
            "Handheld",
            "LocalNotification",
            "NotificationServices",
            "RemoteNotificationType",      
            "RemoteNotification",
            "SamsungTV",
            "TextureCompressionQuality",
            "TouchScreenKeyboardType",
            "TouchScreenKeyboard",
            "MovieTexture",
            "UnityEngineInternal",
            "Terrain",                            
            "Tree",
            "SplatPrototype",
            "DetailPrototype",
            "DetailRenderMode",
            "MeshSubsetCombineUtility",
            "AOT",
            "Social",
            "Enumerator",       
            "SendMouseEvents",               
            "Cursor",
            "Flash",
            "ActionScript",
            "OnRequestRebuild",
			"Ping",
            "ShaderVariantCollection",
			"SimpleJson.Reflection",
        };
		}

	}
}
