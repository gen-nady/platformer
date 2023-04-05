using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_apples")]
	public class ES3UserType_AppleTree : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_AppleTree() : base(typeof(WorldItem.AppleTree)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WorldItem.AppleTree)obj;
			
			writer.WritePrivateField("_apples", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WorldItem.AppleTree)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_apples":
					instance = (WorldItem.AppleTree)reader.SetPrivateField("_apples", reader.Read<System.Collections.Generic.List<ObjectToQuest.ApplePickUpItem>>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_AppleTreeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AppleTreeArray() : base(typeof(WorldItem.AppleTree[]), ES3UserType_AppleTree.Instance)
		{
			Instance = this;
		}
	}
}