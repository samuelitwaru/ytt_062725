using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class gxdomainwwpcardtype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainwwpcardtype ()
      {
         domain[(short)0] = "Text";
         domain[(short)1] = "Banner Image";
         domain[(short)2] = "Banner Image Simple";
         domain[(short)3] = "Back Image";
         domain[(short)4] = "Back Image V1";
         domain[(short)5] = "Back Image Light";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Text"] = (short)0;
            domainMap["BannerImage"] = (short)1;
            domainMap["BannerImageSimple"] = (short)2;
            domainMap["BackImage"] = (short)3;
            domainMap["BackImageV1"] = (short)4;
            domainMap["BackImageLight"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}
