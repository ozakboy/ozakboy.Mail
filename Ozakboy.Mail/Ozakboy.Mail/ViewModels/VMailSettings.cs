﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.Mail.ViewModels
{
    internal class VMailSettings
    {
        /// <summary>
        /// 郵件SMTP 設定
        /// </summary>
        public VSmtpMailConfig SmtpMailConfig { get; set; }
    }

    internal class VSmtpMailConfig
    {
        /// <summary>
        /// 連線的Host
        /// </summary>
        public string Host { get; set; }


        /// <summary>
        /// 指定的Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 寄件者名稱
        /// </summary>
        public string Name { get; set; }
    }
}
