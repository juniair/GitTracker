using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTracker.Core.Utils
{
    public class OptionOrder
    {
        public static Comparison<ComparableOption> OrderProcess => (ComparableOption attr1, ComparableOption attr2) =>
        {

            if ("help".Equals(attr1.LongName) || "version".Equals(attr1.LongName))
            {
                return 1;
            }

            if (attr1.IsOption && attr2.IsOption)
            {
                if (attr1.Required && !attr2.Required)
                {
                    return -1;
                }
                else if (!attr1.Required && attr2.Required)
                {
                    return 1;
                }
                else
                {
                    if (string.IsNullOrEmpty(attr1.ShortName) && !string.IsNullOrEmpty(attr2.ShortName))
                    {
                        return 1;
                    }
                    else if (!string.IsNullOrEmpty(attr1.ShortName) && string.IsNullOrEmpty(attr2.ShortName))
                    {
                        return -1;
                    }
                    return string.Compare(attr1.ShortName, attr2.ShortName, StringComparison.Ordinal);
                }
            }
            else if (attr1.IsOption && attr2.IsValue)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
