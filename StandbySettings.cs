using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Thein
{
    public static class StandbySettings
    {

        private const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private const uint ES_DISPLAY_REQUIRED = 0x00000002;
        private const uint ES_USER_PRESENT = 0x00000004; 
        private const uint ES_AWAYMODE_REQUIRED = 0x00000040;
        private const uint ES_CONTINUOUS = 0x80000000;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern uint SetThreadExecutionState(uint esFlags);

        public static void DisableStandby()
        {
            var success = SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED | ES_SYSTEM_REQUIRED);

            if (success == 0)
            {
                var error = Marshal.GetLastWin32Error();

                if (error != 0)
                    throw new Win32Exception(error);
            }
        }

        public static void EnableStandby()
        {
            var success = SetThreadExecutionState(ES_CONTINUOUS);

            if (success == 0)
            {
                // Failed to enable standby
                var error = Marshal.GetLastWin32Error();

                if (error != 0)
                    throw new Win32Exception(error);
            }
        }
    }
}
