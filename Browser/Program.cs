﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Browser
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ConfigManager.Instance.Dump();
            Application.Run(new Form1());
        }

    }
}