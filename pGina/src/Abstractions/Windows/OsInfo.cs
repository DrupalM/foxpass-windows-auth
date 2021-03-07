﻿/*
	Copyright © 2021 Foxpass, Inc.
	All rights reserved.

	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
		* Redistributions of source code must retain the above copyright
		  notice, this list of conditions and the following disclaimer.
		* Redistributions in binary form must reproduce the above copyright
		  notice, this list of conditions and the following disclaimer in the
		  documentation and/or other materials provided with the distribution.
		* Neither the name of the pGina Team nor the names of its contributors
		  may be used to endorse or promote products derived from this software without
		  specific prior written permission.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
	ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
	WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY
	DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
	(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
	LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
	ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
	(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
	SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstractions.WindowsApi;

namespace Abstractions.Windows
{
    public static class OsInfo
    {
        public static bool IsVistaOrLater()
        {
            OperatingSystem sys = System.Environment.OSVersion;

            if (sys.Platform == PlatformID.Win32NT &&
                sys.Version.Major >= 6)
                return true;

            return false;
        }

        public static bool IsWindows()
        {
            OperatingSystem sys = System.Environment.OSVersion;

            if (sys.Platform == PlatformID.Win32NT ||
                sys.Platform == PlatformID.Win32S ||
                sys.Platform == PlatformID.Win32Windows ||
                sys.Platform == PlatformID.WinCE)
                return true;

            return false;
        }

        public static bool Is64Bit()
        {
            // Is this equivalent?:  return Environment.Is64BitOperatingSystem;
            return IntPtr.Size == 8;
        }

        public static string OsDescription()
        {
            pInvokes.structenums.OSVERSIONINFOW ver = pInvokes.VersionsInfo();
            return string.Format("OS {0}.{1}.{2} Runtime: {3} Culture: {4}", ver.dwMajorVersion, ver.dwMinorVersion, ver.dwBuildNumber, System.Environment.Version, CultureInfo.InstalledUICulture.EnglishName);
        }

        public static bool Is7OrLater()
        {
            pInvokes.structenums.OSVERSIONINFOW ver = pInvokes.VersionsInfo();
            if (ver.dwMajorVersion == 6 && ver.dwMinorVersion >= 1)
            {
                return true;
            }
            if (ver.dwMajorVersion > 6)
            {
                return true;
            }

            return false;
        }

        public static bool Is8OrLater()
        {
            pInvokes.structenums.OSVERSIONINFOW ver = pInvokes.VersionsInfo();
            if (ver.dwMajorVersion == 6 && ver.dwMinorVersion >= 2)
            {
                return true;
            }
            if (ver.dwMajorVersion > 6)
            {
                return true;
            }

            return false;
        }

        public static bool Is8oneOrLater()
        {
            pInvokes.structenums.OSVERSIONINFOW ver = pInvokes.VersionsInfo();
            if (ver.dwMajorVersion == 6 && ver.dwMinorVersion >= 3)
            {
                return true;
            }
            if (ver.dwMajorVersion > 6)
            {
                return true;
            }

            return false;
        }

        public static bool Is10OrLater()
        {
            pInvokes.structenums.OSVERSIONINFOW ver = pInvokes.VersionsInfo();
            if (ver.dwMajorVersion == 6 && ver.dwMinorVersion >= 4)
            {
                return true;
            }
            if (ver.dwMajorVersion > 6)
            {
                return true;
            }

            return false;
        }
    }
}
