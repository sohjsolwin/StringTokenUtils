using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Com.SohjSolwin.DotNet.StringTokenUtils
{
    public class StringTokenUtils
    {

        /// <summary>
        /// RegEx for parsing out the "Date" format of the parameters.
        /// </summary>
        private const string ParameterParseRegEx = @"\[(?<format>.*?)\]";

        public static string ParseTokens(this string input)
        {
            string dateFormat;

            if (input.IndexOf("[") >= 0 && input.IndexOf("]") > 0)
            {
                var parmMatch = Regex.Match(input, ParameterParseRegEx);
                if (parmMatch.Length > 0)
                {
                    dateFormat = DateTime.Now.ToString(parmMatch.Value).Replace("\\", "_").Replace(" ", "_").Replace(":", "_");

                    input = input.Replace(parmMatch.Value, dateFormat.Replace("[", string.Empty).Replace("]", string.Empty));
                }
            }
            return input;
        }
    }
}
