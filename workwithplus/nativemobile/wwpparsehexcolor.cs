using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.nativemobile {
   public class wwpparsehexcolor : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wwpparsehexcolor_Services_Execute" ;
         }

      }

      public wwpparsehexcolor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwpparsehexcolor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ColorStringIn ,
                           out short aP1_IntR ,
                           out short aP2_IntG ,
                           out short aP3_IntB ,
                           out short aP4_IntA ,
                           out string aP5_HexR ,
                           out string aP6_HexG ,
                           out string aP7_HexB ,
                           out string aP8_HexA )
      {
         this.AV17ColorStringIn = aP0_ColorStringIn;
         this.AV16IntR = 0 ;
         this.AV15IntG = 0 ;
         this.AV14IntB = 0 ;
         this.AV13IntA = 0 ;
         this.AV12HexR = "" ;
         this.AV11HexG = "" ;
         this.AV10HexB = "" ;
         this.AV9HexA = "" ;
         initialize();
         ExecuteImpl();
         aP1_IntR=this.AV16IntR;
         aP2_IntG=this.AV15IntG;
         aP3_IntB=this.AV14IntB;
         aP4_IntA=this.AV13IntA;
         aP5_HexR=this.AV12HexR;
         aP6_HexG=this.AV11HexG;
         aP7_HexB=this.AV10HexB;
         aP8_HexA=this.AV9HexA;
      }

      public string executeUdp( string aP0_ColorStringIn ,
                                out short aP1_IntR ,
                                out short aP2_IntG ,
                                out short aP3_IntB ,
                                out short aP4_IntA ,
                                out string aP5_HexR ,
                                out string aP6_HexG ,
                                out string aP7_HexB )
      {
         execute(aP0_ColorStringIn, out aP1_IntR, out aP2_IntG, out aP3_IntB, out aP4_IntA, out aP5_HexR, out aP6_HexG, out aP7_HexB, out aP8_HexA);
         return AV9HexA ;
      }

      public void executeSubmit( string aP0_ColorStringIn ,
                                 out short aP1_IntR ,
                                 out short aP2_IntG ,
                                 out short aP3_IntB ,
                                 out short aP4_IntA ,
                                 out string aP5_HexR ,
                                 out string aP6_HexG ,
                                 out string aP7_HexB ,
                                 out string aP8_HexA )
      {
         this.AV17ColorStringIn = aP0_ColorStringIn;
         this.AV16IntR = 0 ;
         this.AV15IntG = 0 ;
         this.AV14IntB = 0 ;
         this.AV13IntA = 0 ;
         this.AV12HexR = "" ;
         this.AV11HexG = "" ;
         this.AV10HexB = "" ;
         this.AV9HexA = "" ;
         SubmitImpl();
         aP1_IntR=this.AV16IntR;
         aP2_IntG=this.AV15IntG;
         aP3_IntB=this.AV14IntB;
         aP4_IntA=this.AV13IntA;
         aP5_HexR=this.AV12HexR;
         aP6_HexG=this.AV11HexG;
         aP7_HexB=this.AV10HexB;
         aP8_HexA=this.AV9HexA;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12HexR = "ff";
         AV11HexG = "ff";
         AV10HexB = "ff";
         AV9HexA = "ff";
         AV8ColorString = AV17ColorStringIn;
         if ( StringUtil.StartsWith( AV8ColorString, "#") )
         {
            AV8ColorString = StringUtil.Substring( AV8ColorString, 2, -1);
            if ( StringUtil.Len( AV8ColorString) > 2 )
            {
               if ( StringUtil.Len( AV8ColorString) < 5 )
               {
                  AV12HexR = StringUtil.CharAt( AV8ColorString, 1);
                  AV11HexG = StringUtil.CharAt( AV8ColorString, 2);
                  AV10HexB = StringUtil.CharAt( AV8ColorString, 3);
                  if ( StringUtil.Len( AV8ColorString) > 3 )
                  {
                     AV9HexA = StringUtil.CharAt( AV8ColorString, 4);
                  }
               }
               else
               {
                  AV12HexR = StringUtil.Substring( AV8ColorString, 1, 2);
                  AV11HexG = StringUtil.Substring( AV8ColorString, 3, 2);
                  AV10HexB = StringUtil.Substring( AV8ColorString, 5, 2);
                  if ( StringUtil.Len( AV8ColorString) > 7 )
                  {
                     AV9HexA = StringUtil.Substring( AV8ColorString, 7, 2);
                  }
               }
            }
         }
         GXt_int1 = AV16IntR;
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetdecimalfromhex(context ).execute(  AV12HexR, out  GXt_int1) ;
         AV16IntR = (short)(GXt_int1);
         GXt_int1 = AV15IntG;
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetdecimalfromhex(context ).execute(  AV11HexG, out  GXt_int1) ;
         AV15IntG = (short)(GXt_int1);
         GXt_int1 = AV14IntB;
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetdecimalfromhex(context ).execute(  AV10HexB, out  GXt_int1) ;
         AV14IntB = (short)(GXt_int1);
         GXt_int1 = AV13IntA;
         new GeneXus.Programs.workwithplus.nativemobile.wwpgetdecimalfromhex(context ).execute(  AV9HexA, out  GXt_int1) ;
         AV13IntA = (short)(GXt_int1);
         AV12HexR = StringUtil.PadL( AV12HexR, 2, "0");
         AV11HexG = StringUtil.PadL( AV11HexG, 2, "0");
         AV10HexB = StringUtil.PadL( AV10HexB, 2, "0");
         AV9HexA = StringUtil.PadL( AV9HexA, 2, "0");
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12HexR = "";
         AV11HexG = "";
         AV10HexB = "";
         AV9HexA = "";
         AV8ColorString = "";
         /* GeneXus formulas. */
      }

      private short AV16IntR ;
      private short AV15IntG ;
      private short AV14IntB ;
      private short AV13IntA ;
      private int GXt_int1 ;
      private string AV17ColorStringIn ;
      private string AV12HexR ;
      private string AV11HexG ;
      private string AV10HexB ;
      private string AV9HexA ;
      private string AV8ColorString ;
      private short aP1_IntR ;
      private short aP2_IntG ;
      private short aP3_IntB ;
      private short aP4_IntA ;
      private string aP5_HexR ;
      private string aP6_HexG ;
      private string aP7_HexB ;
      private string aP8_HexA ;
   }

}
