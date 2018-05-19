﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradualForm
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Win32 is just a placeholder for some Win32 imported definitions
    /// </summary>
    public class Win32Imports
    {
        [DllImport("user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// VK is just a placeholder for VK (VirtualKey) general definitions
        /// </summary>
        public class VK
        {
            public const int VK_SHIFT = 0x10;
            public const int VK_CONTROL = 0x11;
            public const int VK_MENU = 0x12;
            public const int VK_ESCAPE = 0x1B;

            public static bool IsKeyPressed(int KeyCode)
            {
                return (GetAsyncKeyState(KeyCode) & 0x0800) == 0;
            }
        }

        /// <summary>
        /// WM is just a placeholder class for WM (WindowMessage) definitions
        /// </summary>
        public class WM
        {
            public const int WM_MOUSEMOVE = 0x0200;
            public const int WM_NCMOUSEMOVE = 0x00A0;
            public const int WM_NCLBUTTONDOWN = 0x00A1;
            public const int WM_NCLBUTTONUP = 0x00A2;
            public const int WM_NCLBUTTONDBLCLK = 0x00A3;
            public const int WM_LBUTTONDOWN = 0x0201;
            public const int WM_LBUTTONUP = 0x0202;
            public const int WM_KEYDOWN = 0x0100;
        }

        /// <summary>
        /// HT is just a placeholder for HT (HitTest) definitions
        /// </summary>
        public class HT
        {
            public const int HTERROR = (-2);
            public const int HTTRANSPARENT = (-1);
            public const int HTNOWHERE = 0;
            public const int HTCLIENT = 1;
            public const int HTCAPTION = 2;
            public const int HTSYSMENU = 3;
            public const int HTGROWBOX = 4;
            public const int HTSIZE = HTGROWBOX;
            public const int HTMENU = 5;
            public const int HTHSCROLL = 6;
            public const int HTVSCROLL = 7;
            public const int HTMINBUTTON = 8;
            public const int HTMAXBUTTON = 9;
            public const int HTLEFT = 10;
            public const int HTRIGHT = 11;
            public const int HTTOP = 12;
            public const int HTTOPLEFT = 13;
            public const int HTTOPRIGHT = 14;
            public const int HTBOTTOM = 15;
            public const int HTBOTTOMLEFT = 16;
            public const int HTBOTTOMRIGHT = 17;
            public const int HTBORDER = 18;
            public const int HTREDUCE = HTMINBUTTON;
            public const int HTZOOM = HTMAXBUTTON;
            public const int HTSIZEFIRST = HTLEFT;
            public const int HTSIZELAST = HTBOTTOMRIGHT;

            public const int HTOBJECT = 19;
            public const int HTCLOSE = 20;
            public const int HTHELP = 21;
        }

        public class Bit
        {
            public static int HiWord(int iValue)
            {
                return ((iValue >> 16) & 0xFFFF);
            }
            public static int LoWord(int iValue)
            {
                return (iValue & 0xFFFF);
            }
        }
    }
}
