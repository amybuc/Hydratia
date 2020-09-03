using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("dateTime", "waterDrank", "waterGoal")]
	public class ES3UserType_WaterLog : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WaterLog() : base(typeof(WaterLog)){ Instance = this; priority = 1; }


		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (WaterLog)obj;
			
			writer.WriteProperty("dateTime", instance.dateTime, ES3Type_DateTime.Instance);
			writer.WriteProperty("waterDrank", instance.waterDrank, ES3Type_int.Instance);
			writer.WriteProperty("waterGoal", instance.waterGoal, ES3Type_int.Instance);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (WaterLog)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "dateTime":
						instance.dateTime = reader.Read<System.DateTime>(ES3Type_DateTime.Instance);
						break;
					case "waterDrank":
						instance.waterDrank = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "waterGoal":
						instance.waterGoal = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WaterLogArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WaterLogArray() : base(typeof(WaterLog[]), ES3UserType_WaterLog.Instance)
		{
			Instance = this;
		}
	}
}