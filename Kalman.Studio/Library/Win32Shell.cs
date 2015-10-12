#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using System.Drawing;

#endregion


namespace Kalman.Studio
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FileShellInfo
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
        public Icon Icon { get { return Icon.FromHandle(hIcon); } }
    };

    /// <summary>
    /// 封装Win32 Shell相关调用方法
    /// </summary>
    public class Win32Shell
    {
        public const uint SHGFI_ICON = 0x100;         // Gets the icon 
        public const uint SHGFI_DISPLAYNAME = 0x200;  // Gets the Display name
        public const uint SHGFI_TYPENAME = 0x400;     // Gets the type name
        public const uint SHGFI_LARGEICON = 0x0;      // Large icon
        public const uint SHGFI_SMALLICON = 0x1;      // Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref FileShellInfo psfi, uint cbSizeFileInfo, uint uFlags);

        public static FileShellInfo GetFileInfo(string path)
        {
            FileShellInfo info = new FileShellInfo();
            IntPtr icon;

            icon = SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_TYPENAME | SHGFI_SMALLICON);

            return info;
        }
    }
}
