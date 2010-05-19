using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Utils
{
    public class GeoUtil
    {
        public static string GetAddressName(string lat, string lon)
        {
            var r = WebRequest.Create(string.Format("http://ws.geonames.org/findNearbyPlaceName?lat={0}&lng={1}",lat,lon));


            var rs = r.GetResponse().GetResponseStream();

            //byte[] content = new byte[rs.Length];
            //rs.Read(content, 0, content.Length);

            //MemoryStream ms = new MemoryStream(content);
            TextReader sr = new StreamReader(rs);
            var fullAddress = sr.ReadToEnd();
            if (fullAddress.Length<6)
            {
                return "";
            } try
            {

                string addressname = fullAddress.Substring(
                    fullAddress.IndexOf("<name>")+6,
                    fullAddress.IndexOf("</name>")-fullAddress.IndexOf("<name>")-6
                    );

                return addressname;
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
