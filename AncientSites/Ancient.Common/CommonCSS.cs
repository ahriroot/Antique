using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ancient.Common
{
    public class CommonCSS
    {
        public string CSS_p1(string inner)
        {
            return "<p style='color:#000000; text-align:center; font-weight:bold; font-size:25px; id=" + "oncli" + "'>" + inner + "</p>";
        }

        public string CSS_p2(string inner)
        {
            return "<p style='color:#ff6500; text-align:center; font-family:SimSun; font-weight:bold; font-size:15px; id=" + "oncli" + "'>" + inner + "</p>";
        }

        public string CSS_p3(string inner)
        {
            return "<p style='color:#2571fb; text-align:center; font-family:SimSun; font-weight:bold; font-size:15px; id=" + "oncli" + "'>" + inner + "</p>";
        }
    }
}
