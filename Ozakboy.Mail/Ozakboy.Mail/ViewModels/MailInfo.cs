using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.Mail
{
    /// <summary>
    /// 收件人
    /// </summary>
    public class MailInfo
    {
        public MailInfo() { }
        public MailInfo(string _Address) 
        { 
            this.Address = _Address;
            this.Name = string.Empty;
        }

        public MailInfo(string _Address , string _Name)
        {
            this.Address = _Address;
            this.Name = _Name;
        }
        /// <summary>
        /// 收件人位置
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 收件者名稱  可以不給
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
