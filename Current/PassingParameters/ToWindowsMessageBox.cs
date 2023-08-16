using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLEANXCEL2._2.PassingParameters
{
    class ToWindowsMessageBox
    {
        public struct message_info
        {
            public string caption;
            public string message;
        }

        public message_info ToMessageBox(string s_caption, string s_message)
        {
            return new message_info
            {
                caption = s_caption,
                message = s_message
            };
        }
    }
}
