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
   public class gxdomainwwptiletype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainwwptiletype ()
      {
         domain[(short)0] = "Information";
         domain[(short)1] = "Image";
         domain[(short)2] = "Web Component";
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
            domainMap["Information"] = (short)0;
            domainMap["Image"] = (short)1;
            domainMap["WebComponent"] = (short)2;
         }
         return (short)domainMap[key] ;
      }

   }

}
