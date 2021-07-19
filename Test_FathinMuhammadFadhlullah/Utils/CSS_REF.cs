using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils
{
    public class CSS_REF
    {
        private List<CSS_REF_Item> _Refs = new List<CSS_REF_Item>();

        public List<CSS_REF_Item> Refs { get { return _Refs; } }
        public List<String> toHtmlList()
        {
            List<String> RetVal = new List<String>();
            foreach (CSS_REF_Item oItem in _Refs)
            {
                RetVal.Add(oItem.Html);
            }
            return RetVal;
        }

        public void addByFileName(String FileName)
        {
            CSS_REF_Item oNewRefItem = CSS_REF_Item.createByFileName(FileName);
            _Refs.Add(oNewRefItem);
        }

        public void addByHtml(String Html)
        {
            CSS_REF_Item oNewRefItem = CSS_REF_Item.createByHtml(Html);
            _Refs.Add(oNewRefItem);
        }

        public class CSS_REF_Item
        {
            private String _FileName;
            private String _Path;
            private String _Html;

            public String Html { get { return _Html; } }

            public static CSS_REF_Item createByFileName(String FileName)
            {
                CSS_REF_Item oNewCSSRef = new CSS_REF_Item();
                oNewCSSRef._FileName = FileName;
                oNewCSSRef._Path = "~/assets/modules/css";
                oNewCSSRef._Html = "    <link href=\"" + oNewCSSRef._Path + "/" + oNewCSSRef._FileName + "\" rel=\"stylesheet\" type=\"text/css\" />";
                return oNewCSSRef;
            }

            public static CSS_REF_Item createByHtml(String Html)
            {
                CSS_REF_Item oNewCSSRef = new CSS_REF_Item();
                oNewCSSRef._Html = "    " + Html;
                return oNewCSSRef;
            }
        }
    }
}
