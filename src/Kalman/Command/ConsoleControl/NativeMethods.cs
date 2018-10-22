
using System;
using System.Text;
using System.Runtime.InteropServices;



namespace Kalman.Command
{
	internal static class NativeMethods
	{


		// richTextBox auto-scroll to the bottom
		internal const int SB_VERT = 1;
		internal const int EM_SETSCROLLPOS = 0x0400 + 222;


		[DllImport( "user32", CharSet = CharSet.Auto )]
		internal static extern bool GetScrollRange( IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos );


		[DllImport( "user32", CharSet = CharSet.Auto )]
		internal static extern IntPtr SendMessage( IntPtr hWnd, int msg, int wParam, POINT lParam );


		[StructLayout( LayoutKind.Sequential )]
		internal class POINT
		{
			public int x;
			public int y;

			public POINT()
			{
			}

			public POINT( int x, int y )
			{
				this.x = x;
				this.y = y;
			}
		}


		///////////////////////////////////////////////////////////

		[DllImport( "user32", CharSet = CharSet.Auto )]
		internal extern static IntPtr SendMessage( IntPtr hWnd, int msg, int wParam, IntPtr lParam );

		internal const int WM_SETREDRAW = 0x000B;
		internal const int WM_USER = 0x400;
		internal const int EM_GETEVENTMASK = ( WM_USER + 59 );
		internal const int EM_SETEVENTMASK = ( WM_USER + 69 );


	}
}
