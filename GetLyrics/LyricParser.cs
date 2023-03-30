using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLyrics
{
    public static class LyricParser
    {
        public static string Parser(string body)
        {
            string res = "";
            for (int i = 0; i < body.Length; i++)
            {
                if (body[i] == '"')
                {
                    if (body[i + 1] == 'w')
                    {
                        i += 9;
                        while (body[i] != '"' && body[i] != '\\')
                        {

                            res += body[i];
                            i++;
                        }
                        res += "\n";
                    }
                }
            }
            return res;
        }
    }
}
