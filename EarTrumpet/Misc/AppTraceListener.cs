﻿using System;
using System.Diagnostics;
using System.Text;

namespace EarTrumpet.Misc
{
    class AppTraceListener : TraceListener
    {
        internal static AppTraceListener Instance;
        internal StringBuilder Log = new StringBuilder();

        private readonly DefaultTraceListener _defaultListener = new DefaultTraceListener();

        public AppTraceListener()
        {
            Debug.Assert(Instance == null);

            Instance = this;
        }

        public override void Write(string message)
        {
            _defaultListener.Write(message);
        }

        public override void WriteLine(string message)
        {
            message = $"{DateTime.Now.ToString("HH:mm:ss.fff")} {message}";

            Log.AppendLine(message);
            _defaultListener.WriteLine(message);
        }
    }
}
