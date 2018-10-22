using System;
//using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Diagnostics;



namespace Kalman.Command
{
	public partial class RichConsoleBox : RichTextBox
	{

		internal static class InternalCommands
		{
			/// <summary>
			/// Displays ConsoleControl properties as StandardOutput
			/// </summary>
			internal static void ConsoleInfo()
			{


				Trace.WriteLine( "Running ConsoleInfo..." );

				/*
				Font titleFont = new Font( this.Font, FontStyle.Underline );
				Color titleForeColor = Color.White;
				Color titleBackColor = this.BackColor;


				this.AppendFormattedText( Environment.NewLine + Environment.NewLine + "cmd.exe Process:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( processCMD ) );


				this.AppendFormattedText( "StandardOutput.BaseStream:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( processCMD.StandardOutput.BaseStream ) );


				this.AppendFormattedText( "StandardError.BaseStream:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( processCMD.StandardError.BaseStream ) );


				this.AppendFormattedText( "StandardInput.BaseStream:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( processCMD.StandardInput.BaseStream ) );


				this.AppendFormattedText( "threadStandardOutput:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( threadStandardOutput ) );

				this.AppendFormattedText( "threadStandardError:" + Environment.NewLine, titleFont, titleForeColor, titleBackColor );
				this.AppendText( ReflectionMethods.GeneratePropertiesReport( threadStandardError ) );
				*/
			}

		}

	}
}
