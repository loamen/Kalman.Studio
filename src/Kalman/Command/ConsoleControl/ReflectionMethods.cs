
using System;
using System.Collections.Specialized;	// StringCollection
using System.Drawing;			// Color
using System.Text;			// StringBuilder
using System.Windows.Forms;		// DUH!
using System.Diagnostics;		// Process
using System.IO;			// StreamWriter, StreamReader
using System.Threading;			// Thread
using System.Reflection;



namespace Kalman.Command
{

	public partial class RichConsoleBox : RichTextBox
	{

		internal static class ReflectionMethods
		{
			/// <summary>
			/// Creates simple "Property Name = Value" text report for object instance
			/// </summary>
			/// <param name="o">Subject of the report</param>
			/// <returns></returns>
			public static string GeneratePropertiesReport( object o )
			{

				//
				StringBuilder classreportOutput = new StringBuilder();


				// 
				Type t = o.GetType();


				//
				PropertyInfo[] props = t.GetProperties( BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static );
				foreach ( PropertyInfo p in props )
				{

					// Stores as string representation of a property's value
					string propertyValue = String.Empty;


					// Get the property's name and current value
					try
					{
						propertyValue = p.GetValue( o, null ).ToString();

					}
					catch ( Exception e )
					{

						// Display the reason for the exception
						if ( e.InnerException == null )
						{
							propertyValue = "(" + e.Message + ")";
						}
						else
						{
							propertyValue = "(" + e.InnerException.Message + ")";
						}
					}

					// Add this property/value to the report
					classreportOutput.Append( "\t" + p.Name + " = " + propertyValue + Environment.NewLine );

				}

				// Return report with padding
				return classreportOutput.ToString() + Environment.NewLine;
			}

			public static bool ExecuteInternalCommand( string commandLine )
			{
				// 
				Type t = typeof( InternalCommands );
				//
				MethodInfo[] methods = t.GetMethods( BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Static );
				//
				foreach ( MethodInfo m in methods )
				{
					if ( m.Name.ToLower().Equals( commandLine ) )
					{
						m.Invoke( null, null );
						return true;
					}

				}
				//
				return false;
			}
			
		}

	}
}
