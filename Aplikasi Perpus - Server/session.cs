using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikasi_Perpus___Server
{
    static class session
    {
        static string userid;
        static void logout()
        {
            userid = null;
        }
    }
}
