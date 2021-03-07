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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Dynamic;

namespace pGina.Core.Messages
{
    public class LoginRequestMessage : MessageBase
    {
        public enum LoginReason
        {
            Login = 0,
            Unlock,
            CredUI
        }

        public string Username
        {
            get
            {
                return (String.IsNullOrEmpty(_Username)) ? "" : _Username;
            }
            set
            {
                _Username = value;
            }
        }
        private string _Username;

        public string Password
        {
            get
            {
                return (String.IsNullOrEmpty(_Password)) ? "" : _Password;
            }
            set
            {
                _Password = value;
            }
        }
        private string _Password;

        public string Domain
        {
            get
            {
                return (String.IsNullOrEmpty(_Domain)) ? "" : _Domain;
            }
            set
            {
                _Domain = value;
            }
        }
        private string _Domain;

        public int Session { get; set; }
        public LoginReason Reason { get; set; }

        public LoginRequestMessage(IDictionary<string, object> expandoVersion)
        {
            FromDict(expandoVersion);
        }

        public LoginRequestMessage()
        {
        }

        public override void FromDict(IDictionary<string, object> expandoVersion)
        {
            Username = (string) expandoVersion["Username"];
            Password = (string) expandoVersion["Password"];
            Domain = (string) expandoVersion["Domain"];
            Session = (int) expandoVersion["Session"];
            Reason = (LoginReason)((byte)expandoVersion["Reason"]);
        }

        public override IDictionary<string, object> ToDict()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Username", Username);
            dict.Add("Password", Password);
            dict.Add("Domain", Domain);
            dict.Add("Session", Session);
            dict.Add("Reason", (byte) this.Reason);
            dict.Add("MessageType", (byte) MessageType.LoginRequest);
            return dict;
        }
    }
}
