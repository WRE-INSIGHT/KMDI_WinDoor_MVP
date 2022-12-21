using Headspring;

namespace EnumerationTypeLayer
{
    public class EnumerationTypes
    {
        public class SystemProfile_Option : Enumeration<SystemProfile_Option>
        {
            public static readonly SystemProfile_Option _C70 = new SystemProfile_Option(0, "C70");
            public static readonly SystemProfile_Option _G58 = new SystemProfile_Option(1, "G58");
            public static readonly SystemProfile_Option _Premiline = new SystemProfile_Option(2, "Premiline");

            private SystemProfile_Option(int value, string displayName) : base(value, displayName) { }
        }
        public class FrameProfile_ArticleNo : Enumeration<FrameProfile_ArticleNo>
        {
            public static readonly FrameProfile_ArticleNo _7502 = new FrameProfile_ArticleNo(0, "7502");
            public static readonly FrameProfile_ArticleNo _7507 = new FrameProfile_ArticleNo(1, "7507");
            public static readonly FrameProfile_ArticleNo _2060 = new FrameProfile_ArticleNo(2, "2060"); //G58
            public static readonly FrameProfile_ArticleNo _6050 = new FrameProfile_ArticleNo(3, "6050");
            public static readonly FrameProfile_ArticleNo _6052 = new FrameProfile_ArticleNo(4, "6052");

            private FrameProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrameProfileForPremi_ArticleNo : Enumeration<FrameProfileForPremi_ArticleNo>
        {
            public static readonly FrameProfileForPremi_ArticleNo _6055 = new FrameProfileForPremi_ArticleNo(0, "6055");
            public static readonly FrameProfileForPremi_ArticleNo _6052_milled = new FrameProfileForPremi_ArticleNo(1, "6052 - Milled");

            private FrameProfileForPremi_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class FrameReinf_ArticleNo : Enumeration<FrameReinf_ArticleNo>
        {
            public static readonly FrameReinf_ArticleNo _R676 = new FrameReinf_ArticleNo(0, "R676");
            public static readonly FrameReinf_ArticleNo _R677 = new FrameReinf_ArticleNo(1, "R677");
            public static readonly FrameReinf_ArticleNo _V226 = new FrameReinf_ArticleNo(2, "V226"); //G58
            public static readonly FrameReinf_ArticleNo _TV107 = new FrameReinf_ArticleNo(3, "T-V107");
            public static readonly FrameReinf_ArticleNo _TV110 = new FrameReinf_ArticleNo(4, "T-V110");

            private FrameReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrameReinfForPremi_ArticleNo : Enumeration<FrameReinfForPremi_ArticleNo>
        {
            public static readonly FrameReinfForPremi_ArticleNo _V115 = new FrameReinfForPremi_ArticleNo(0, "V-115");
            public static readonly FrameReinfForPremi_ArticleNo _TV107 = new FrameReinfForPremi_ArticleNo(1, "T-V107");

            private FrameReinfForPremi_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Divider_ArticleNo : Enumeration<Divider_ArticleNo, int>
        {
            public static readonly Divider_ArticleNo _7536 = new Divider_ArticleNo(0, "7536");
            public static readonly Divider_ArticleNo _7538 = new Divider_ArticleNo(1, "7538");
            public static readonly Divider_ArticleNo _2069 = new Divider_ArticleNo(2, "2069");
            public static readonly Divider_ArticleNo _6052 = new Divider_ArticleNo(3, "6052");
            public static readonly Divider_ArticleNo _None = new Divider_ArticleNo(4, "None");
            private Divider_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class DividerReinf_ArticleNo : Enumeration<DividerReinf_ArticleNo, int>
        {
            public static readonly DividerReinf_ArticleNo _R677 = new DividerReinf_ArticleNo(0, "R677");
            public static readonly DividerReinf_ArticleNo _R686 = new DividerReinf_ArticleNo(1, "R686");
            public static readonly DividerReinf_ArticleNo _V226 = new DividerReinf_ArticleNo(2, "V226");//G58
            public static readonly DividerReinf_ArticleNo _TV107 = new DividerReinf_ArticleNo(3, "T-V107");
            public static readonly DividerReinf_ArticleNo _None = new DividerReinf_ArticleNo(4, "None");
            private DividerReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class DummyMullion_ArticleNo : Enumeration<DummyMullion_ArticleNo, int>
        {
            public static readonly DummyMullion_ArticleNo _7533 = new DummyMullion_ArticleNo(0, "7533");
            public static readonly DummyMullion_ArticleNo _385P = new DummyMullion_ArticleNo(1, "385P");

            private DummyMullion_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class EndcapDM_ArticleNo : Enumeration<EndcapDM_ArticleNo, int>
        {
            public static readonly EndcapDM_ArticleNo _K7533 = new EndcapDM_ArticleNo(0, "K7533");
            public static readonly EndcapDM_ArticleNo _K385 = new EndcapDM_ArticleNo(1, "K385");

            private EndcapDM_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Divider_MechJointArticleNo : Enumeration<Divider_MechJointArticleNo, int>
        {
            public static readonly Divider_MechJointArticleNo _9U18 = new Divider_MechJointArticleNo(0, "9U18");
            public static readonly Divider_MechJointArticleNo _AV585 = new Divider_MechJointArticleNo(1, "AV585");
            private Divider_MechJointArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GlazingBead_ArticleNo : Enumeration<GlazingBead_ArticleNo, int>
        {
            public static readonly GlazingBead_ArticleNo _2452 = new GlazingBead_ArticleNo(0, "2452");
            public static readonly GlazingBead_ArticleNo _2451 = new GlazingBead_ArticleNo(1, "2451");
            public static readonly GlazingBead_ArticleNo _2453 = new GlazingBead_ArticleNo(2, "2453");
            public static readonly GlazingBead_ArticleNo _2436 = new GlazingBead_ArticleNo(3, "2436");
            public static readonly GlazingBead_ArticleNo _2438 = new GlazingBead_ArticleNo(4, "2438");
            public static readonly GlazingBead_ArticleNo _2437 = new GlazingBead_ArticleNo(5, "2437");
            public static readonly GlazingBead_ArticleNo _2434 = new GlazingBead_ArticleNo(6, "2434");
            public static readonly GlazingBead_ArticleNo _2435 = new GlazingBead_ArticleNo(7, "2435");
            public static readonly GlazingBead_ArticleNo _2433 = new GlazingBead_ArticleNo(8, "2433");
            public static readonly GlazingBead_ArticleNo _2432 = new GlazingBead_ArticleNo(9, "2432");
            public static readonly GlazingBead_ArticleNo _2431 = new GlazingBead_ArticleNo(10, "2431");
            public static readonly GlazingBead_ArticleNo _1681 = new GlazingBead_ArticleNo(11, "1681");//G58 21.5 thickness
            public static readonly GlazingBead_ArticleNo _2429 = new GlazingBead_ArticleNo(12, "2429");
            public static readonly GlazingBead_ArticleNo _2431_9073 = new GlazingBead_ArticleNo(13, "2431 & 9073");
            public static readonly GlazingBead_ArticleNo _2433_9073 = new GlazingBead_ArticleNo(14, "2433 & 9073");
            public static readonly GlazingBead_ArticleNo _2429_9044 = new GlazingBead_ArticleNo(15, "2429 & 9044");



            private GlazingBead_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class GlassFilm_Types : Enumeration<GlassFilm_Types, int>
        {
            public static readonly GlassFilm_Types _None = new GlassFilm_Types(0, "None");
            public static readonly GlassFilm_Types _VKoolOEM35 = new GlassFilm_Types(1, "V-Kool OEM-35");
            public static readonly GlassFilm_Types _Titanium = new GlassFilm_Types(2, "Titanium");
            public static readonly GlassFilm_Types _Silver40 = new GlassFilm_Types(3, "Silver 40");
            public static readonly GlassFilm_Types _Black50 = new GlassFilm_Types(4, "Black 50");
            public static readonly GlassFilm_Types _Black35 = new GlassFilm_Types(5, "Black 35");
            public static readonly GlassFilm_Types _Black05 = new GlassFilm_Types(6, "Black 05");
            public static readonly GlassFilm_Types _4milSolarGuard = new GlassFilm_Types(7, "4 mil Safety Film (Solar Guard)");
            public static readonly GlassFilm_Types _4milUpera = new GlassFilm_Types(8, "4 mil Safety Film (Upera)");
            public static readonly GlassFilm_Types _FrostedFilm = new GlassFilm_Types(9, "Frosted Film");
            private GlassFilm_Types(int value, string displayName) : base(value, displayName) { }
        }
        public class GlassType : Enumeration<GlassType, int>
        {
            public static readonly GlassType _Single = new GlassType(0, "Single");
            public static readonly GlassType _Double = new GlassType(1, "Double");
            public static readonly GlassType _Triple = new GlassType(2, "Triple");

            private GlassType(int value, string displayName) : base(value, displayName) { }
        }
        public class CreateNewGlass_ShowPurpose : Enumeration<CreateNewGlass_ShowPurpose, int>
        {
            public static readonly CreateNewGlass_ShowPurpose _Single = new CreateNewGlass_ShowPurpose(0, "Single");
            public static readonly CreateNewGlass_ShowPurpose _DoubleInsulated = new CreateNewGlass_ShowPurpose(1, "DoubleInsulated");
            public static readonly CreateNewGlass_ShowPurpose _DoubleLaminated = new CreateNewGlass_ShowPurpose(2, "DoubleLaminated");
            public static readonly CreateNewGlass_ShowPurpose _TripleInsulated = new CreateNewGlass_ShowPurpose(3, "TripleInsulated");
            public static readonly CreateNewGlass_ShowPurpose _TripleLaminated = new CreateNewGlass_ShowPurpose(4, "TripleLaminated");
            public static readonly CreateNewGlass_ShowPurpose _DefaultNone = new CreateNewGlass_ShowPurpose(5, "DefaultNone");

            private CreateNewGlass_ShowPurpose(int value, string displayName) : base(value, displayName) { }
        }
        public class CladdingProfile_ArticleNo : Enumeration<CladdingProfile_ArticleNo, int>
        {
            public static readonly CladdingProfile_ArticleNo _1338 = new CladdingProfile_ArticleNo(0, "1338");
            public static readonly CladdingProfile_ArticleNo _WK50 = new CladdingProfile_ArticleNo(1, "WK50");

            private CladdingProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class CladdingReinf_ArticleNo : Enumeration<CladdingReinf_ArticleNo, int>
        {
            public static readonly CladdingReinf_ArticleNo _9120 = new CladdingReinf_ArticleNo(0, "9120");
            public static readonly CladdingReinf_ArticleNo _NA50 = new CladdingReinf_ArticleNo(1, "NA50");

            private CladdingReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class CoverForCladdingProfile_ArticleNo : Enumeration<CoverForCladdingProfile_ArticleNo, int>
        {
            public static readonly CoverForCladdingProfile_ArticleNo _NK5 = new CoverForCladdingProfile_ArticleNo(0, "NK5");

            private CoverForCladdingProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class SashProfile_ArticleNo : Enumeration<SashProfile_ArticleNo, int>
        {
            public static readonly SashProfile_ArticleNo _None = new SashProfile_ArticleNo(0, "None");
            public static readonly SashProfile_ArticleNo _7581 = new SashProfile_ArticleNo(1, "7581");
            public static readonly SashProfile_ArticleNo _373 = new SashProfile_ArticleNo(2, "373"); //inward
            public static readonly SashProfile_ArticleNo _374 = new SashProfile_ArticleNo(3, "374");
            public static readonly SashProfile_ArticleNo _395 = new SashProfile_ArticleNo(4, "395"); //inward
            public static readonly SashProfile_ArticleNo _2067 = new SashProfile_ArticleNo(5, "2067"); //G58
            public static readonly SashProfile_ArticleNo _6040 = new SashProfile_ArticleNo(6, "6040");
            public static readonly SashProfile_ArticleNo _6041 = new SashProfile_ArticleNo(7, "6041");

            private SashProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SashReinf_ArticleNo : Enumeration<SashReinf_ArticleNo, int>
        {
            public static readonly SashReinf_ArticleNo _None = new SashReinf_ArticleNo(0, "None");
            public static readonly SashReinf_ArticleNo _R675 = new SashReinf_ArticleNo(1, "R675");
            public static readonly SashReinf_ArticleNo _655 = new SashReinf_ArticleNo(2, "655");
            public static readonly SashReinf_ArticleNo _207 = new SashReinf_ArticleNo(3, "207");
            public static readonly SashReinf_ArticleNo _V226 = new SashReinf_ArticleNo(4, "V226");//G58
            public static readonly SashReinf_ArticleNo _TV104 = new SashReinf_ArticleNo(5, "T-V104");
            public static readonly SashReinf_ArticleNo _TV106 = new SashReinf_ArticleNo(6, "T-V106");



            private SashReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Base_Color : Enumeration<Base_Color, int>
        {
            public static readonly Base_Color _White = new Base_Color(0, "White");
            public static readonly Base_Color _Ivory = new Base_Color(1, "Ivory");
            public static readonly Base_Color _DarkBrown = new Base_Color(2, "Dark Brown");

            private Base_Color(int value, string displayName) : base(value, displayName) { }
        }

        public class Foil_Color : Enumeration<Foil_Color, int>
        {
            public static readonly Foil_Color _Walnut = new Foil_Color(0, "Walnut");
            public static readonly Foil_Color _GoldenOak = new Foil_Color(1, "GoldenOak");
            public static readonly Foil_Color _Mahogany = new Foil_Color(2, "Mahogany");
            public static readonly Foil_Color _CharcoalGray = new Foil_Color(3, "Charcoal Gray");
            public static readonly Foil_Color _FossilGray = new Foil_Color(4, "Fossil Gray");
            public static readonly Foil_Color _BeechOak = new Foil_Color(5, "Beech Oak");
            public static readonly Foil_Color _DriftWood = new Foil_Color(6, "DriftWood");
            public static readonly Foil_Color _Graphite = new Foil_Color(7, "Graphite");
            public static readonly Foil_Color _JetBlack = new Foil_Color(8, "JetBlack");
            public static readonly Foil_Color _ChestnutOak = new Foil_Color(9, "Chestnut Oak");
            public static readonly Foil_Color _WashedOak = new Foil_Color(10, "Washed Oak");
            public static readonly Foil_Color _GreyOak = new Foil_Color(11, "Grey Oak");
            public static readonly Foil_Color _Cacao = new Foil_Color(12, "Cacao");
            public static readonly Foil_Color _Havana = new Foil_Color(13, "Havana");
            public static readonly Foil_Color _None = new Foil_Color(14, "None");

            private Foil_Color(int value, string displayName) : base(value, displayName) { }
        }

        public class CoverProfile_ArticleNo : Enumeration<CoverProfile_ArticleNo, int>
        {
            public static readonly CoverProfile_ArticleNo _0914 = new CoverProfile_ArticleNo(0, "0914");
            public static readonly CoverProfile_ArticleNo _1640 = new CoverProfile_ArticleNo(1, "1640");

            private CoverProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrictionStay_ArticleNo : Enumeration<FrictionStay_ArticleNo, int> //AW
        {
            public static readonly FrictionStay_ArticleNo _Storm8 = new FrictionStay_ArticleNo(0, "Storm 8 (8\"HD)");
            public static readonly FrictionStay_ArticleNo _10HD = new FrictionStay_ArticleNo(1, "477254 (10\"HD)");
            public static readonly FrictionStay_ArticleNo _12HD = new FrictionStay_ArticleNo(2, "A2121C1261 (12\"HD)");
            public static readonly FrictionStay_ArticleNo _16HD = new FrictionStay_ArticleNo(3, "A212C16161 (16\"HD)");
            public static readonly FrictionStay_ArticleNo _Storm22 = new FrictionStay_ArticleNo(4, "Storm 22 (22\"HD)");
            public static readonly FrictionStay_ArticleNo _Storm26 = new FrictionStay_ArticleNo(5, "Storm 26 (26\"HD)");
            public static readonly FrictionStay_ArticleNo _None = new FrictionStay_ArticleNo(6, "None");

            private FrictionStay_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrictionStayCasement_ArticleNo : Enumeration<FrictionStayCasement_ArticleNo, int> //CW
        {
            public static FrictionStayCasement_ArticleNo _10HD = new FrictionStayCasement_ArticleNo(0, "485770 (10\"HD)");
            public static readonly FrictionStayCasement_ArticleNo _12FS = new FrictionStayCasement_ArticleNo(1, "A235B12161 (12\"FS)");
            public static readonly FrictionStayCasement_ArticleNo _12HD = new FrictionStayCasement_ArticleNo(2, "A212C12161 (12\"HD)");
            public static readonly FrictionStayCasement_ArticleNo _16HD = new FrictionStayCasement_ArticleNo(3, "A212C16161 (16\"HD)");
            public static readonly FrictionStayCasement_ArticleNo _20HD = new FrictionStayCasement_ArticleNo(4, "A212C20161 (20\"HD)");
            public static readonly FrictionStayCasement_ArticleNo _None = new FrictionStayCasement_ArticleNo(5, "None");

            private FrictionStayCasement_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Handle_Type : Enumeration<Handle_Type, int>
        {
            public static readonly Handle_Type _Rotoswing = new Handle_Type(0, "Rotoswing Handle");
            public static readonly Handle_Type _Rotary = new Handle_Type(1, "Rotary Handle");
            public static readonly Handle_Type _Rio = new Handle_Type(2, "Rio Handle");
            public static readonly Handle_Type _Rotoline = new Handle_Type(3, "Rotoline Handle");
            public static readonly Handle_Type _MVD = new Handle_Type(4, "MVD Handle");
            public static readonly Handle_Type _D = new Handle_Type(5, "D Handle");
            public static readonly Handle_Type _D_IO_Locking = new Handle_Type(6, "D Handle In & Out Locking");
            public static readonly Handle_Type _DummyD = new Handle_Type(7, "Dummy D Handle");
            public static readonly Handle_Type _PopUp = new Handle_Type(8, "Pop-up Handle");
            public static readonly Handle_Type _RotoswingForSliding = new Handle_Type(9, "Rotoswing(Sliding) Handle");






            public static readonly Handle_Type _None = new Handle_Type(10, "None");

            private Handle_Type(int value, string displayName) : base(value, displayName) { }
        }

        public class Rotoswing_HandleArtNo : Enumeration<Rotoswing_HandleArtNo, int>
        {
            public static readonly Rotoswing_HandleArtNo _RSC773451 = new Rotoswing_HandleArtNo(0, "RSC-773451");
            public static readonly Rotoswing_HandleArtNo _RSC773452 = new Rotoswing_HandleArtNo(1, "RSC-773452");
            public static readonly Rotoswing_HandleArtNo _RSC823048 = new Rotoswing_HandleArtNo(2, "RSC-823048");
            public static readonly Rotoswing_HandleArtNo _RSC833307 = new Rotoswing_HandleArtNo(3, "RSC-833307");

            private Rotoswing_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Rotoswing_Sliding_HandleArtNo : Enumeration<Rotoswing_Sliding_HandleArtNo, int>
        {
            public static readonly Rotoswing_Sliding_HandleArtNo _RSS632300 = new Rotoswing_Sliding_HandleArtNo(0, "RSS-632300");
            public static readonly Rotoswing_Sliding_HandleArtNo _RSS823073 = new Rotoswing_Sliding_HandleArtNo(1, "RSS-823073");
            public static readonly Rotoswing_Sliding_HandleArtNo _RSS823094 = new Rotoswing_Sliding_HandleArtNo(2, "RSS-823094");
            public static readonly Rotoswing_Sliding_HandleArtNo _RSS632303 = new Rotoswing_Sliding_HandleArtNo(3, "RSS-632303");

            private Rotoswing_Sliding_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }
        public class Rotary_HandleArtNo : Enumeration<Rotary_HandleArtNo, int>
        {
            public static readonly Rotary_HandleArtNo _T511155KMWSS = new Rotary_HandleArtNo(0, "T-51.1155 KM-W-SS");
            public static readonly Rotary_HandleArtNo _T511155KMBLSS = new Rotary_HandleArtNo(1, "T-51.1155 KM-BL-SS");

            private Rotary_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Rio_HandleArtNo : Enumeration<Rio_HandleArtNo, int>
        {
            public static readonly Rio_HandleArtNo _C050C108019 = new Rio_HandleArtNo(0, "C050C108019");
            public static readonly Rio_HandleArtNo _C050C109005 = new Rio_HandleArtNo(1, "C050C109005");
            public static readonly Rio_HandleArtNo _C050C107025 = new Rio_HandleArtNo(2, "C050C107025");

            private Rio_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ProfileKnobCylinder_ArtNo : Enumeration<ProfileKnobCylinder_ArtNo, int>
        {
            public static readonly ProfileKnobCylinder_ArtNo _45x45 = new ProfileKnobCylinder_ArtNo(0, "45x45");
            public static readonly ProfileKnobCylinder_ArtNo _35x35 = new ProfileKnobCylinder_ArtNo(1, "35x35");
            //public static readonly ProfileKnobCylinder_ArtNo _50p5x50p5 = new ProfileKnobCylinder_ArtNo(0, "50.5x50.5");

            private ProfileKnobCylinder_ArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Cylinder_CoverArtNo : Enumeration<Cylinder_CoverArtNo, int>
        {
            public static readonly Cylinder_CoverArtNo _EPSW_7025_50992 = new Cylinder_CoverArtNo(0, "EPSW-7025/50992");
            public static readonly Cylinder_CoverArtNo _EPSW_8022_823332 = new Cylinder_CoverArtNo(1, "EPSW-8022/823332");
            public static readonly Cylinder_CoverArtNo _EPSW_9005_614441 = new Cylinder_CoverArtNo(2, "EPSW-9005/614441");
            public static readonly Cylinder_CoverArtNo _EPSW_IVORY = new Cylinder_CoverArtNo(3, "EPSW-IVORY");

            private Cylinder_CoverArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Rotoline_HandleArtNo : Enumeration<Rotoline_HandleArtNo, int>
        {
            public static readonly Rotoline_HandleArtNo _K070A21725 = new Rotoline_HandleArtNo(0, "K070A21725");

            private Rotoline_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MVD_HandleArtNo : Enumeration<MVD_HandleArtNo, int>
        {
            public static readonly MVD_HandleArtNo _046366M = new MVD_HandleArtNo(0, "046-366M");

            private MVD_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class D_HandleArtNo : Enumeration<D_HandleArtNo, int>
        {
            public static readonly D_HandleArtNo _DH605543 = new D_HandleArtNo(0, "DH-605543(out) White");
            public static readonly D_HandleArtNo _DH613226 = new D_HandleArtNo(1, "DH-613226(in) White");
            public static readonly D_HandleArtNo _DH613185 = new D_HandleArtNo(2, "DH-613185(out) DB");
            public static readonly D_HandleArtNo _DH613224 = new D_HandleArtNo(3, "DH-613224(in) DB");
            public static readonly D_HandleArtNo _DH605551 = new D_HandleArtNo(4, "DH-605551(out) Black");
            public static readonly D_HandleArtNo _DH613225 = new D_HandleArtNo(5, "DH-613225(in) Black");
            public static readonly D_HandleArtNo _DH487261 = new D_HandleArtNo(6, "DH-487261(out) Mill Finish");
            public static readonly D_HandleArtNo _DH613228 = new D_HandleArtNo(7, "DH-613228(in) Mill Finish");

            private D_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }


        public class D_Handle_IO_LockingArtNo : Enumeration<D_Handle_IO_LockingArtNo, int>
        {
            public static readonly D_Handle_IO_LockingArtNo _613217 = new D_Handle_IO_LockingArtNo(0, "613217(out) White");
            public static readonly D_Handle_IO_LockingArtNo _DH613243 = new D_Handle_IO_LockingArtNo(1, "DH-613243(in) White");
            public static readonly D_Handle_IO_LockingArtNo _DH833309_613215 = new D_Handle_IO_LockingArtNo(2, "DH-833309/613215(out) DB");
            public static readonly D_Handle_IO_LockingArtNo _DH833308_613241 = new D_Handle_IO_LockingArtNo(3, "DH-833308/613241(in) DB");
            public static readonly D_Handle_IO_LockingArtNo _DH605216 = new D_Handle_IO_LockingArtNo(4, "DH-605216(OUT) BLK");
            public static readonly D_Handle_IO_LockingArtNo _DH613242 = new D_Handle_IO_LockingArtNo(5, "DH-613242(IN) BLK");
            public static readonly D_Handle_IO_LockingArtNo _DH613219 = new D_Handle_IO_LockingArtNo(6, "DH-613219(out) Mill Finish");
            public static readonly D_Handle_IO_LockingArtNo _DH613245 = new D_Handle_IO_LockingArtNo(7, "DH-613245(in) Mill Finish");

            private D_Handle_IO_LockingArtNo(int value, string displayName) : base(value, displayName) { }
        }

        public class DummyD_HandleArtNo : Enumeration<DummyD_HandleArtNo, int>
        {
            public static readonly DummyD_HandleArtNo _DH613191 = new DummyD_HandleArtNo(0, "DH-613191(out)White");
            public static readonly DummyD_HandleArtNo _DH613226 = new DummyD_HandleArtNo(1, "DH-613226(in) White");
            public static readonly DummyD_HandleArtNo _DH613190 = new DummyD_HandleArtNo(2, "DH-613190(out) BL");
            public static readonly DummyD_HandleArtNo _DH613225 = new DummyD_HandleArtNo(3, "DH-613225(in) BL");
            public static readonly DummyD_HandleArtNo _DH833310_613189 = new DummyD_HandleArtNo(4, "DH-833310/613189(out) DB");
            public static readonly DummyD_HandleArtNo _DH613224 = new DummyD_HandleArtNo(5, "DH-613224(in) DB");
            public static readonly DummyD_HandleArtNo _DH613193 = new DummyD_HandleArtNo(6, "DH-613193(out) Mill Finish");
            public static readonly DummyD_HandleArtNo _DH613228 = new DummyD_HandleArtNo(7, "DH-613228(in) Mill Finish ");

            private DummyD_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }


        public class PopUp_HandleArtNo : Enumeration<PopUp_HandleArtNo, int>
        {
            public static readonly PopUp_HandleArtNo _3127668 = new PopUp_HandleArtNo(0, "3127668");
            public static readonly PopUp_HandleArtNo _323778 = new PopUp_HandleArtNo(1, "323778");


            private PopUp_HandleArtNo(int value, string displayName) : base(value, displayName) { }
        }
        public class Espagnolette_ArticleNo : Enumeration<Espagnolette_ArticleNo, int>
        {
            public static readonly Espagnolette_ArticleNo _628806 = new Espagnolette_ArticleNo(0, "628806");
            public static readonly Espagnolette_ArticleNo _628807 = new Espagnolette_ArticleNo(1, "628807");
            public static readonly Espagnolette_ArticleNo _628809 = new Espagnolette_ArticleNo(2, "628809");
            public static readonly Espagnolette_ArticleNo _741012 = new Espagnolette_ArticleNo(3, "741012");
            public static readonly Espagnolette_ArticleNo _EQ87NT = new Espagnolette_ArticleNo(4, "EQ87(NT)");
            public static readonly Espagnolette_ArticleNo _642105 = new Espagnolette_ArticleNo(5, "642105");
            public static readonly Espagnolette_ArticleNo _642089 = new Espagnolette_ArticleNo(6, "642089");
            public static readonly Espagnolette_ArticleNo _630963 = new Espagnolette_ArticleNo(7, "630963");
            public static readonly Espagnolette_ArticleNo _N110A00006 = new Espagnolette_ArticleNo(8, "N110A00006");
            public static readonly Espagnolette_ArticleNo _N110A01006 = new Espagnolette_ArticleNo(9, "N110A01006");
            public static readonly Espagnolette_ArticleNo _N110A02206 = new Espagnolette_ArticleNo(10, "N110A02206");
            public static readonly Espagnolette_ArticleNo _N110A03206 = new Espagnolette_ArticleNo(11, "N110A03206");
            public static readonly Espagnolette_ArticleNo _N110A04206 = new Espagnolette_ArticleNo(12, "N110A04206");
            public static readonly Espagnolette_ArticleNo _N110A05206 = new Espagnolette_ArticleNo(13, "N110A05206");
            public static readonly Espagnolette_ArticleNo _N110A06206 = new Espagnolette_ArticleNo(14, "N110A06206");
            public static readonly Espagnolette_ArticleNo _774275 = new Espagnolette_ArticleNo(15, "774275");
            public static readonly Espagnolette_ArticleNo _774276 = new Espagnolette_ArticleNo(16, "774276");
            public static readonly Espagnolette_ArticleNo _774277 = new Espagnolette_ArticleNo(17, "774277");
            public static readonly Espagnolette_ArticleNo _774278 = new Espagnolette_ArticleNo(18, "774278");
            public static readonly Espagnolette_ArticleNo _774286 = new Espagnolette_ArticleNo(19, "774286");
            public static readonly Espagnolette_ArticleNo _774287 = new Espagnolette_ArticleNo(20, "774287");
            public static readonly Espagnolette_ArticleNo _731852 = new Espagnolette_ArticleNo(21, "731852");
            public static readonly Espagnolette_ArticleNo _6_90137_10_0_1 = new Espagnolette_ArticleNo(22, "6-90137-10-0-1");
            public static readonly Espagnolette_ArticleNo _None = new Espagnolette_ArticleNo(23, "None");

            private Espagnolette_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Extension_ArticleNo : Enumeration<Extension_ArticleNo, int>
        {
            public static readonly Extension_ArticleNo _None = new Extension_ArticleNo(0, "None");
            public static readonly Extension_ArticleNo _612978 = new Extension_ArticleNo(1, "612978");
            public static readonly Extension_ArticleNo _639957 = new Extension_ArticleNo(2, "639957");
            public static readonly Extension_ArticleNo _641798 = new Extension_ArticleNo(3, "641798");
            public static readonly Extension_ArticleNo _567639 = new Extension_ArticleNo(4, "567639");
            public static readonly Extension_ArticleNo _630956 = new Extension_ArticleNo(5, "630956");

            private Extension_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CornerDrive_ArticleNo : Enumeration<CornerDrive_ArticleNo, int>
        {
            public static readonly CornerDrive_ArticleNo _None = new CornerDrive_ArticleNo(0, "None");
            public static readonly CornerDrive_ArticleNo _639958 = new CornerDrive_ArticleNo(1, "639958");
            public static readonly CornerDrive_ArticleNo _N400A01206 = new CornerDrive_ArticleNo(2, "N400A01206");

            private CornerDrive_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Striker_ArticleNo : Enumeration<Striker_ArticleNo, int>
        {
            public static readonly Striker_ArticleNo _M89ANTA = new Striker_ArticleNo(0, "M89A-NT-A");
            public static readonly Striker_ArticleNo _M89ANTC = new Striker_ArticleNo(1, "M89A-NT-C");
            public static readonly Striker_ArticleNo _629555 = new Striker_ArticleNo(2, "629555"); //left
            public static readonly Striker_ArticleNo _629554 = new Striker_ArticleNo(3, "629554"); //right
            public static readonly Striker_ArticleNo _897019 = new Striker_ArticleNo(4, "897019"); // center profile
            public static readonly Striker_ArticleNo _M54ANT = new Striker_ArticleNo(5, "M54A-NT"); // left
            public static readonly Striker_ArticleNo _M55ANT = new Striker_ArticleNo(6, "M55A-NT"); // right

            private Striker_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MiddleCloser_ArticleNo : Enumeration<MiddleCloser_ArticleNo, int>
        {
            public static readonly MiddleCloser_ArticleNo _1WC70WHT = new MiddleCloser_ArticleNo(0, "1WC70-WHT");
            public static readonly MiddleCloser_ArticleNo _1WC70DB = new MiddleCloser_ArticleNo(1, "1WC70-DB");
            public static readonly MiddleCloser_ArticleNo _None = new MiddleCloser_ArticleNo(2, "None");

            private MiddleCloser_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SnapInKeep_ArticleNo : Enumeration<SnapInKeep_ArticleNo, int>
        {
            public static readonly SnapInKeep_ArticleNo _0400205 = new SnapInKeep_ArticleNo(0, "0400205");
            public static readonly SnapInKeep_ArticleNo _0400215 = new SnapInKeep_ArticleNo(1, "0400215");

            private SnapInKeep_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FixedCam_ArticleNo : Enumeration<FixedCam_ArticleNo, int>
        {
            public static readonly FixedCam_ArticleNo _1481413 = new FixedCam_ArticleNo(0, "1481413");

            private FixedCam_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LockingKit_ArticleNo : Enumeration<LockingKit_ArticleNo, int>
        {
            public static readonly LockingKit_ArticleNo _T244002KMW = new LockingKit_ArticleNo(0, "T-24.40.02 KM-W");
            public static readonly LockingKit_ArticleNo _T24402KMBL = new LockingKit_ArticleNo(1, "T-24.4.02 KM-BL");
            public static readonly LockingKit_ArticleNo _None = new LockingKit_ArticleNo(2, "None");

            private LockingKit_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MotorizedMech_ArticleNo : Enumeration<MotorizedMech_ArticleNo, int>
        {
            public static readonly MotorizedMech_ArticleNo _41556C = new MotorizedMech_ArticleNo(0, "41556C");
            public static readonly MotorizedMech_ArticleNo _41555B = new MotorizedMech_ArticleNo(1, "41555B");
            public static readonly MotorizedMech_ArticleNo _409990E = new MotorizedMech_ArticleNo(2, "409990E");

            private MotorizedMech_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class _30x25Cover_ArticleNo : Enumeration<_30x25Cover_ArticleNo, int>
        {
            public static readonly _30x25Cover_ArticleNo _1067_Milled = new _30x25Cover_ArticleNo(0, "1067 - Milled");

            private _30x25Cover_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MotorizedDivider_ArticleNo : Enumeration<MotorizedDivider_ArticleNo, int>
        {
            public static readonly MotorizedDivider_ArticleNo _0505 = new MotorizedDivider_ArticleNo(0, "0505");

            private MotorizedDivider_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CoverForMotor_ArticleNo : Enumeration<CoverForMotor_ArticleNo, int>
        {
            public static readonly CoverForMotor_ArticleNo _1182 = new CoverForMotor_ArticleNo(0, "1182");

            private CoverForMotor_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class _2DHinge_ArticleNo : Enumeration<_2DHinge_ArticleNo, int>
        {
            public static readonly _2DHinge_ArticleNo _614293 = new _2DHinge_ArticleNo(0, "614293");

            private _2DHinge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class PushButtonSwitch_ArticleNo : Enumeration<PushButtonSwitch_ArticleNo, int>
        {
            public static readonly PushButtonSwitch_ArticleNo _N4037 = new PushButtonSwitch_ArticleNo(0, "N4037");

            private PushButtonSwitch_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FalsePole_ArticleNo : Enumeration<FalsePole_ArticleNo, int>
        {
            public static readonly FalsePole_ArticleNo _N4950 = new FalsePole_ArticleNo(0, "N4950");

            private FalsePole_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SupportingFrame_ArticleNo : Enumeration<SupportingFrame_ArticleNo, int>
        {
            public static readonly SupportingFrame_ArticleNo _N4703 = new SupportingFrame_ArticleNo(0, "N4703");

            private SupportingFrame_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Plate_ArticleNo : Enumeration<Plate_ArticleNo, int>
        {
            public static readonly Plate_ArticleNo _N4803LB = new Plate_ArticleNo(0, "N4803LB");

            private Plate_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class GeorgianBar_ArticleNo : Enumeration<GeorgianBar_ArticleNo, int>
        {
            public static readonly GeorgianBar_ArticleNo _0724 = new GeorgianBar_ArticleNo(0, "0724");
            public static readonly GeorgianBar_ArticleNo _0726 = new GeorgianBar_ArticleNo(1, "0726");
            public static readonly GeorgianBar_ArticleNo _None = new GeorgianBar_ArticleNo(2, "None");

            private GeorgianBar_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class PlasticWedge_ArticleNo : Enumeration<PlasticWedge_ArticleNo, int>
        {
            public static readonly PlasticWedge_ArticleNo _7199DB = new PlasticWedge_ArticleNo(0, "7199-DB");
            public static readonly PlasticWedge_ArticleNo _7199WHT = new PlasticWedge_ArticleNo(0, "7199-WHT");

            private PlasticWedge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class HingeOption : Enumeration<HingeOption, int>
        {
            public static readonly HingeOption _FrictionStay = new HingeOption(0, "Friction Stay");
            public static readonly HingeOption _2DHinge = new HingeOption(1, "2DHinge");

            private HingeOption(int value, string displayName) : base(value, displayName) { }
        }

        public class CenterHingeOption : Enumeration<CenterHingeOption, int>
        {
            public static readonly CenterHingeOption _NTCenterHinge = new CenterHingeOption(0, "NT Center Hinge");
            public static readonly CenterHingeOption _MiddleCloser = new CenterHingeOption(1, "Middle Closer");

            private CenterHingeOption(int value, string displayName) : base(value, displayName) { }
        }


        public class NTCenterHinge_ArticleNo : Enumeration<NTCenterHinge_ArticleNo, int>
        {
            public static readonly NTCenterHinge_ArticleNo _N610A06516 = new NTCenterHinge_ArticleNo(0, "N610A06516");

            private NTCenterHinge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class StayBearingK_ArticleNo : Enumeration<StayBearingK_ArticleNo, int>
        {
            public static readonly StayBearingK_ArticleNo _N390A00106_230177 = new StayBearingK_ArticleNo(0, "N390A00106/230177");

            private StayBearingK_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class StayBearingPin_ArticleNo : Enumeration<StayBearingPin_ArticleNo, int>
        {
            public static readonly StayBearingPin_ArticleNo _F710D52008_227354 = new StayBearingPin_ArticleNo(0, "F710D52008/227354");

            private StayBearingPin_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class StayBearingCover_ArticleNo : Enumeration<StayBearingCover_ArticleNo, int>
        {
            public static readonly StayBearingCover_ArticleNo _WhiteIvory = new StayBearingCover_ArticleNo(0, "N391A03718/230252");
            public static readonly StayBearingCover_ArticleNo _DB = new StayBearingCover_ArticleNo(1, "N391A015580/230204");

            private StayBearingCover_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class TopCornerHinge_ArticleNo : Enumeration<TopCornerHinge_ArticleNo, int>
        {
            public static readonly TopCornerHinge_ArticleNo _Right = new TopCornerHinge_ArticleNo(0, "N620A6116R");
            public static readonly TopCornerHinge_ArticleNo _Left = new TopCornerHinge_ArticleNo(1, "N620A6116L");

            private TopCornerHinge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class TopCornerHingeCover_ArticleNo : Enumeration<TopCornerHingeCover_ArticleNo, int>
        {
            public static readonly TopCornerHingeCover_ArticleNo _WhiteIvory = new TopCornerHingeCover_ArticleNo(0, "N391A03718/230252");
            public static readonly TopCornerHingeCover_ArticleNo _DB = new TopCornerHingeCover_ArticleNo(1, "N391A03558/230251");

            private TopCornerHingeCover_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class TopCornerHingeSpacer_ArticleNo : Enumeration<TopCornerHingeSpacer_ArticleNo, int>
        {
            public static readonly TopCornerHingeSpacer_ArticleNo _331488 = new TopCornerHingeSpacer_ArticleNo(0, "331488");

            private TopCornerHingeSpacer_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CornerHingeK_ArticleNo : Enumeration<CornerHingeK_ArticleNo, int>
        {
            public static readonly CornerHingeK_ArticleNo _N510A0011 = new CornerHingeK_ArticleNo(0, "N510A0011");

            private CornerHingeK_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CornerPivotRestK_ArticleNo : Enumeration<CornerPivotRestK_ArticleNo, int>
        {
            public static readonly CornerPivotRestK_ArticleNo _N510A0001_258590 = new CornerPivotRestK_ArticleNo(0, "N510A0001/258590");

            private CornerPivotRestK_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CornerHingeCoverK_ArticleNo : Enumeration<CornerHingeCoverK_ArticleNo, int>
        {
            public static readonly CornerHingeCoverK_ArticleNo _DB = new CornerHingeCoverK_ArticleNo(0, "N591A04558");
            public static readonly CornerHingeCoverK_ArticleNo _WhiteIvory = new CornerHingeCoverK_ArticleNo(1, "N591A04718");

            private CornerHingeCoverK_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CoverForCornerPivotRestVertical_ArticleNo : Enumeration<CoverForCornerPivotRestVertical_ArticleNo, int>
        {
            public static readonly CoverForCornerPivotRestVertical_ArticleNo _DB = new CoverForCornerPivotRestVertical_ArticleNo(0, "N591A01558");
            public static readonly CoverForCornerPivotRestVertical_ArticleNo _WhiteIvory = new CoverForCornerPivotRestVertical_ArticleNo(1, "N591A01718/230426");

            private CoverForCornerPivotRestVertical_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CoverForCornerPivotRest_ArticleNo : Enumeration<CoverForCornerPivotRest_ArticleNo, int>
        {
            public static readonly CoverForCornerPivotRest_ArticleNo _DB = new CoverForCornerPivotRest_ArticleNo(0, "N591B12556");
            public static readonly CoverForCornerPivotRest_ArticleNo _WhiteIvory = new CoverForCornerPivotRest_ArticleNo(1, "N591A02718");

            private CoverForCornerPivotRest_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LeverEspagnolette_ArticleNo : Enumeration<LeverEspagnolette_ArticleNo, int>
        {
            public static readonly LeverEspagnolette_ArticleNo _None = new LeverEspagnolette_ArticleNo(0, "None");
            public static readonly LeverEspagnolette_ArticleNo _625_205 = new LeverEspagnolette_ArticleNo(1, "625-205");
            public static readonly LeverEspagnolette_ArticleNo _625_206 = new LeverEspagnolette_ArticleNo(2, "625-206");
            public static readonly LeverEspagnolette_ArticleNo _625_207 = new LeverEspagnolette_ArticleNo(3, "625-207");
            public static readonly LeverEspagnolette_ArticleNo _631153 = new LeverEspagnolette_ArticleNo(4, "631153");
            public static readonly LeverEspagnolette_ArticleNo _476518 = new LeverEspagnolette_ArticleNo(5, "476518");

            private LeverEspagnolette_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ShootboltStriker_ArticleNo : Enumeration<LeverEspagnolette_ArticleNo, int>
        {
            public static readonly ShootboltStriker_ArticleNo _N705A20106 = new ShootboltStriker_ArticleNo(0, "N705A20106");

            private ShootboltStriker_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ShootboltReverse_ArticleNo : Enumeration<ShootboltReverse_ArticleNo, int>
        {
            public static readonly ShootboltReverse_ArticleNo _312033 = new ShootboltReverse_ArticleNo(0, "312033");

            private ShootboltReverse_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ShootboltNonReverse_ArticleNo : Enumeration<ShootboltNonReverse_ArticleNo, int>
        {
            public static readonly ShootboltNonReverse_ArticleNo _349187 = new ShootboltNonReverse_ArticleNo(0, "349187");

            private ShootboltNonReverse_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class _3dHinge_ArticleNo : Enumeration<_3dHinge_ArticleNo, int>
        {
            public static readonly _3dHinge_ArticleNo _3DHinge_WHT = new _3dHinge_ArticleNo(0, "492596");
            public static readonly _3dHinge_ArticleNo _3DHinge_IVORY = new _3dHinge_ArticleNo(1, "492592");
            public static readonly _3dHinge_ArticleNo _3DHinge_BL = new _3dHinge_ArticleNo(2, "492592");
            public static readonly _3dHinge_ArticleNo _3DHinge_DB = new _3dHinge_ArticleNo(3, "492594");

            private _3dHinge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class RestrictorStay_ArticleNo : Enumeration<RestrictorStay_ArticleNo, int>
        {
            public static readonly RestrictorStay_ArticleNo _613249 = new RestrictorStay_ArticleNo(0, "613249");

            private RestrictorStay_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class AdjustableStriker_ArticleNo : Enumeration<AdjustableStriker_ArticleNo, int>
        {
            public static readonly AdjustableStriker_ArticleNo _332439 = new AdjustableStriker_ArticleNo(0, "332439");

            private AdjustableStriker_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class WeldableCornerJoint_ArticleNo : Enumeration<WeldableCornerJoint_ArticleNo, int>
        {
            public static readonly WeldableCornerJoint_ArticleNo _498N = new WeldableCornerJoint_ArticleNo(0, "498N");

            private WeldableCornerJoint_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LatchDeadboltStriker_ArticleNo : Enumeration<LatchDeadboltStriker_ArticleNo, int>
        {
            public static readonly LatchDeadboltStriker_ArticleNo _Right = new LatchDeadboltStriker_ArticleNo(0, "390660");
            public static readonly LatchDeadboltStriker_ArticleNo _Left = new LatchDeadboltStriker_ArticleNo(1, "390659");

            private LatchDeadboltStriker_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GlazingAdaptor_ArticleNo : Enumeration<GlazingAdaptor_ArticleNo, int>
        {
            public static readonly GlazingAdaptor_ArticleNo _6418 = new GlazingAdaptor_ArticleNo(0, "6418");

            private GlazingAdaptor_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ButtHinge_ArticleNo : Enumeration<ButtHinge_ArticleNo, int>
        {
            public static readonly ButtHinge_ArticleNo _WHT = new ButtHinge_ArticleNo(0, "770725-WHT"); //white-based
            public static readonly ButtHinge_ArticleNo _PC = new ButtHinge_ArticleNo(1, "770725-PC"); //Ivory-based
            public static readonly ButtHinge_ArticleNo _BL = new ButtHinge_ArticleNo(2, "770725-BL");
            public static readonly ButtHinge_ArticleNo _DB = new ButtHinge_ArticleNo(3, "770725-DB"); //Dark brown

            private ButtHinge_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MilledFrame_ArticleNo : Enumeration<MilledFrame_ArticleNo, int>
        {
            public static readonly MilledFrame_ArticleNo _7502Milled = new MilledFrame_ArticleNo(0, "7502-Milled");

            private MilledFrame_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MilledFrameReinf_ArticleNo : Enumeration<MilledFrameReinf_ArticleNo, int>
        {
            public static readonly MilledFrameReinf_ArticleNo _R_676 = new MilledFrameReinf_ArticleNo(0, "R-676");

            private MilledFrameReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GBSpacer_ArticleNo : Enumeration<GBSpacer_ArticleNo, int>
        {
            //public static readonly GBSpacer_ArticleNo _GBSpacer = new GBSpacer_ArticleNo(0, "GB SPACER");
            public static readonly GBSpacer_ArticleNo _KBC70 = new GBSpacer_ArticleNo(0, "KBC70");
            public static readonly GBSpacer_ArticleNo _9C54 = new GBSpacer_ArticleNo(0, "9C54");

            private GBSpacer_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class DummyMullionStriker_ArticleNo : Enumeration<DummyMullionStriker_ArticleNo, int>
        {
            public static readonly DummyMullionStriker_ArticleNo _339395 = new DummyMullionStriker_ArticleNo(0, "339395");

            private DummyMullionStriker_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class AluminumThreshold_ArticleNo : Enumeration<AluminumThreshold_ArticleNo, int>
        {
            public static readonly AluminumThreshold_ArticleNo _7789 = new AluminumThreshold_ArticleNo(0, "7789");

            private AluminumThreshold_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class FillerProfile_ArticleNo : Enumeration<FillerProfile_ArticleNo, int>
        {
            public static readonly FillerProfile_ArticleNo _0914_milled = new FillerProfile_ArticleNo(0, "0914-milled");
            public static readonly FillerProfile_ArticleNo _0505_milled = new FillerProfile_ArticleNo(1, "0505-milled");
            public static readonly FillerProfile_ArticleNo _6052_milled = new FillerProfile_ArticleNo(2, "6052-milled");
            private FillerProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class Brush_ArticleNo : Enumeration<Brush_ArticleNo, int>
        {
            public static readonly Brush_ArticleNo _SP02 = new Brush_ArticleNo(0, "SP02");

            private Brush_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class DoorSashGasket_ArticleNo : Enumeration<DoorSashGasket_ArticleNo, int>
        {
            public static readonly DoorSashGasket_ArticleNo _782 = new DoorSashGasket_ArticleNo(0, "782");

            private DoorSashGasket_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class ThresholdMetalPiece_ArticleNo : Enumeration<ThresholdMetalPiece_ArticleNo, int>
        {
            public static readonly ThresholdMetalPiece_ArticleNo _SHC70 = new ThresholdMetalPiece_ArticleNo(0, "SHC70");

            private ThresholdMetalPiece_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class AccessoryForSHC70_ArticleNo : Enumeration<AccessoryForSHC70_ArticleNo, int>
        {
            public static readonly AccessoryForSHC70_ArticleNo _DK7507 = new AccessoryForSHC70_ArticleNo(0, "DK7507");

            private AccessoryForSHC70_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class BottomFrameTypes : Enumeration<BottomFrameTypes, int>
        {
            public static readonly BottomFrameTypes _7507 = new BottomFrameTypes(0, "7507");
            public static readonly BottomFrameTypes _7502 = new BottomFrameTypes(1, "7502");
            public static readonly BottomFrameTypes _7789 = new BottomFrameTypes(2, "7789");
            public static readonly BottomFrameTypes _None = new BottomFrameTypes(3, "None");

            private BottomFrameTypes(int value, string displayName) : base(value, displayName) { }
        }
        public class SlidingTypes : Enumeration<SlidingTypes, int>
        {
            public static readonly SlidingTypes _Premiline = new SlidingTypes(0, "Premiline");
            public static readonly SlidingTypes _FoldAndSlide = new SlidingTypes(1, "Fold and Slide");
            public static readonly SlidingTypes _LiftAndSlide = new SlidingTypes(2, "Lift and Slide");
            public static readonly SlidingTypes _Pivot = new SlidingTypes(3, "Sliding Pivot");
            public static readonly SlidingTypes _Paraslide = new SlidingTypes(4, "Paraslide");
            public static readonly SlidingTypes _TopHung = new SlidingTypes(5, "Top Hung");

            private SlidingTypes(int value, string displayName) : base(value, displayName) { }
        }
        public class OverlapSash : Enumeration<OverlapSash, int>
        {
            public static readonly OverlapSash _Left = new OverlapSash(0, "Left");
            public static readonly OverlapSash _Right = new OverlapSash(1, "Right");
            public static readonly OverlapSash _Both = new OverlapSash(2, "Both");
            public static readonly OverlapSash _None = new OverlapSash(3, "None");

            private OverlapSash(int value, string displayName) : base(value, displayName) { }
        }

        public class RollersTypes : Enumeration<RollersTypes, int>
        {
            public static readonly RollersTypes _TandemRoller = new RollersTypes(0, "615951");
            public static readonly RollersTypes _HDRoller = new RollersTypes(1, "609014");
            public static readonly RollersTypes _GURoller = new RollersTypes(2, "C901090008");

            private RollersTypes(int value, string displayName) : base(value, displayName) { }
        }

        public class ScrewSets : Enumeration<ScrewSets, int>
        {
            public static readonly ScrewSets _DH613172 = new ScrewSets(0, "DH-613172");
            public static readonly ScrewSets _DH613176 = new ScrewSets(1, "DH-613176");
            public static readonly ScrewSets _DH613180 = new ScrewSets(2, "DH-613180");

            private ScrewSets(int value, string displayName) : base(value, displayName) { }
        }

        public class GuideTrackProfile_ArticleNo : Enumeration<GuideTrackProfile_ArticleNo, int>
        {
            public static readonly GuideTrackProfile_ArticleNo _6059 = new GuideTrackProfile_ArticleNo(0, "6059");

            private GuideTrackProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class AluminumTrack_ArticleNo : Enumeration<AluminumTrack_ArticleNo, int>
        {
            public static readonly AluminumTrack_ArticleNo _9C51 = new AluminumTrack_ArticleNo(0, "9C51");

            private AluminumTrack_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class WeatherBar_ArticleNo : Enumeration<WeatherBar_ArticleNo, int>
        {
            public static readonly WeatherBar_ArticleNo _1244 = new WeatherBar_ArticleNo(0, "1244");

            private WeatherBar_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class WaterSeepage_ArticleNo : Enumeration<WaterSeepage_ArticleNo, int>
        {
            public static readonly WaterSeepage_ArticleNo _1646 = new WaterSeepage_ArticleNo(0, "1646");

            private WaterSeepage_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ConnectingProfile_ArticleNo : Enumeration<ConnectingProfile_ArticleNo, int>
        {
            public static readonly ConnectingProfile_ArticleNo _0373 = new ConnectingProfile_ArticleNo(0, "0373");

            private ConnectingProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Interlock_ArticleNo : Enumeration<Interlock_ArticleNo, int>
        {
            public static readonly Interlock_ArticleNo _6061_Milled = new Interlock_ArticleNo(0, "6061 - Milled");

            private Interlock_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ExtensionForInterlock_ArticleNo : Enumeration<ExtensionForInterlock_ArticleNo, int>
        {
            public static readonly ExtensionForInterlock_ArticleNo _9C61_Milled = new ExtensionForInterlock_ArticleNo(0, "9C61 - Milled");

            private ExtensionForInterlock_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CenterProfile_ArticleNo : Enumeration<CenterProfile_ArticleNo, int>
        {
            public static readonly CenterProfile_ArticleNo _A000 = new CenterProfile_ArticleNo(0, "A000");

            private CenterProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class AluminumPullHandle_ArticleNo : Enumeration<AluminumPullHandle_ArticleNo, int>
        {
            public static readonly AluminumPullHandle_ArticleNo _9C58 = new AluminumPullHandle_ArticleNo(0, "9C58");

            private AluminumPullHandle_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class WeatherBarFastener_ArticleNo : Enumeration<WeatherBarFastener_ArticleNo, int>
        {
            public static readonly WeatherBarFastener_ArticleNo _9447 = new WeatherBarFastener_ArticleNo(0, "9447");

            private WeatherBarFastener_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class EndCapForWeatherBar_ArticleNo : Enumeration<EndCapForWeatherBar_ArticleNo, int>
        {
            public static readonly EndCapForWeatherBar_ArticleNo _9483 = new EndCapForWeatherBar_ArticleNo(0, "9483");

            private EndCapForWeatherBar_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SealingElement_ArticleNo : Enumeration<SealingElement_ArticleNo, int>
        {
            public static readonly SealingElement_ArticleNo _9C97 = new SealingElement_ArticleNo(0, "9C97");

            private SealingElement_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MechnJointForFrame_ArticleNo : Enumeration<MechnJointForFrame_ArticleNo, int>
        {
            public static readonly MechnJointForFrame_ArticleNo _9C52 = new MechnJointForFrame_ArticleNo(0, "9C52");

            private MechnJointForFrame_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class EndCapFor9C58_ArticleNo : Enumeration<EndCapFor9C58_ArticleNo, int>
        {
            public static readonly EndCapFor9C58_ArticleNo _9C68 = new EndCapFor9C58_ArticleNo(0, "9C68");

            private EndCapFor9C58_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class BrushSeal_ArticleNo : Enumeration<BrushSeal_ArticleNo, int>
        {
            public static readonly BrushSeal_ArticleNo _9091 = new BrushSeal_ArticleNo(0, "9091");

            private BrushSeal_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GlazingRebateBlock_ArticleNo : Enumeration<GlazingRebateBlock_ArticleNo, int>
        {
            public static readonly GlazingRebateBlock_ArticleNo _9C56 = new GlazingRebateBlock_ArticleNo(0, "9C56");

            private GlazingRebateBlock_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Spacer_ArticleNo : Enumeration<Spacer_ArticleNo, int>
        {
            public static readonly Spacer_ArticleNo _M063 = new Spacer_ArticleNo(0, "M063");

            private Spacer_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SealingBlock_ArticleNo : Enumeration<SealingBlock_ArticleNo, int>
        {
            public static readonly SealingBlock_ArticleNo _9C63 = new SealingBlock_ArticleNo(0, "9C63");

            private SealingBlock_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrameConnectionType : Enumeration<FrameConnectionType, int>
        {
            public static readonly FrameConnectionType _Weldable = new FrameConnectionType(0, "Weldable");
            public static readonly FrameConnectionType _MechanicalJoint = new FrameConnectionType(1, "Mechanical Joint");

            private FrameConnectionType(int value, string displayName) : base(value, displayName) { }
        }

        public class ScreenType : Enumeration<ScreenType, int>
        {
            public static readonly ScreenType _RollUp = new ScreenType(0, "Roll-up Insect Screen");
            public static readonly ScreenType _Plisse = new ScreenType(1, "Plissé Insect Screen");
            public static readonly ScreenType _Sliding = new ScreenType(2, "Sliding Insect Screen"); // using mesh
            public static readonly ScreenType _BuiltInSideroll = new ScreenType(3, "Built-In Sideroll Insect Screen");
            public static readonly ScreenType _Piconet = new ScreenType(4, "Piconet Insect Screen");
            public static readonly ScreenType _Fixed = new ScreenType(5, "Fixed Screen"); // using mesh 
            public static readonly ScreenType _ChainDriven = new ScreenType(6, "Chain Driven Screen");
            public static readonly ScreenType _ZeroGravityChainDriven = new ScreenType(7, "Zero Gravity Chain Driven Screen");
            public static readonly ScreenType _Magnum = new ScreenType(8, "Magnum Screen");
            public static readonly ScreenType _Maxxy = new ScreenType(9, "Maxxy Screen");


            private ScreenType(int value, string displayName) : base(value, displayName) { }
        }

        public class PlisseType : Enumeration<PlisseType, int>
        {
            public static readonly PlisseType _SR = new PlisseType(0, "Plissé SR Slim Line Insect Screen");
            public static readonly PlisseType _TR = new PlisseType(1, "Plissé TR Insect Screen");
            public static readonly PlisseType _AD = new PlisseType(2, "Plissé AD Insect Screen");
            public static readonly PlisseType _RD = new PlisseType(3, "Plissé rd Insect Screen");


            private PlisseType(int value, string displayName) : base(value, displayName) { }
        }


        public class MeshType : Enumeration<MeshType, int>
        {
            public static readonly MeshType _Security = new MeshType(0, "Security Mesh");
            public static readonly MeshType _Tuff = new MeshType(1, "Tuff Mesh");

            private MeshType(int value, string displayName) : base(value, displayName) { }
        }

        public class ScreenPVCBox_ArticleNo : Enumeration<ScreenPVCBox_ArticleNo, int>
        {
            public static readonly ScreenPVCBox_ArticleNo _0505 = new ScreenPVCBox_ArticleNo(0, "0505");
            public static readonly ScreenPVCBox_ArticleNo _1067 = new ScreenPVCBox_ArticleNo(1, "1067");

            private ScreenPVCBox_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class ScreenAddOnsMaterial : Enumeration<ScreenAddOnsMaterial, int>
        {
            public static readonly ScreenAddOnsMaterial _PVCbox = new ScreenAddOnsMaterial(0, "PVC box");
            public static readonly ScreenAddOnsMaterial _PowderCoating = new ScreenAddOnsMaterial(1, "Powder Coating");
            public static readonly ScreenAddOnsMaterial _LandCover = new ScreenAddOnsMaterial(2, "L & Cover");
            public static readonly ScreenAddOnsMaterial _ManualShootBolt = new ScreenAddOnsMaterial(3, "Manual Shootbolt");


            private ScreenAddOnsMaterial(int value, string displayName) : base(value, displayName) { }
        }

        public class ScreenReinforcement_ArticleNo : Enumeration<ScreenReinforcement_ArticleNo, int>
        {
            public static readonly ScreenReinforcement_ArticleNo _CenterPark = new ScreenReinforcement_ArticleNo(0, "Center Park");
            public static readonly ScreenReinforcement_ArticleNo _DoubleCenterClosure = new ScreenReinforcement_ArticleNo(1, "Double Center Closure");

            private ScreenReinforcement_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class PVCCenterProfile_ArticleNo : Enumeration<PVCCenterProfile_ArticleNo, int>
        {
            public static readonly PVCCenterProfile_ArticleNo _6067 = new PVCCenterProfile_ArticleNo(0, "6067");

            private PVCCenterProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GS100_T_EM_T_HMCOVER_ArticleNo : Enumeration<GS100_T_EM_T_HMCOVER_ArticleNo, int>
        {
            public static readonly GS100_T_EM_T_HMCOVER_ArticleNo _L15056103 = new GS100_T_EM_T_HMCOVER_ArticleNo(0, "L-15056-103");
            public static readonly GS100_T_EM_T_HMCOVER_ArticleNo _L15056103B = new GS100_T_EM_T_HMCOVER_ArticleNo(1, "L-15056-103B");


            private GS100_T_EM_T_HMCOVER_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }


        public class TrackProfile_ArticleNo : Enumeration<TrackProfile_ArticleNo, int>
        {
            public static readonly TrackProfile_ArticleNo _L15056140 = new TrackProfile_ArticleNo(0, "L-15056-140");
            public static readonly TrackProfile_ArticleNo _L15056141 = new TrackProfile_ArticleNo(1, "L-15056-141");
            public static readonly TrackProfile_ArticleNo _L15056142 = new TrackProfile_ArticleNo(2, "L-15056-142");
            public static readonly TrackProfile_ArticleNo _L15056143 = new TrackProfile_ArticleNo(3, "L-15056-143");
            public static readonly TrackProfile_ArticleNo _L15056144 = new TrackProfile_ArticleNo(4, "L-15056-144");
            public static readonly TrackProfile_ArticleNo _L15056146 = new TrackProfile_ArticleNo(5, "L-15056-146");

            private TrackProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class TrackRail_ArticleNo : Enumeration<TrackRail_ArticleNo, int>
        {
            public static readonly TrackRail_ArticleNo _L15056196 = new TrackRail_ArticleNo(0, "L-15056-196");

            private TrackRail_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class MicrocellOneSafetySensor_ArticleNo : Enumeration<MicrocellOneSafetySensor_ArticleNo, int>
        {
            public static readonly MicrocellOneSafetySensor_ArticleNo _L15056051 = new MicrocellOneSafetySensor_ArticleNo(0, "L-15056-051");

            private MicrocellOneSafetySensor_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class AutodoorBracketForGS100UPVC_ArticleNo : Enumeration<AutodoorBracketForGS100UPVC_ArticleNo, int>
        {
            public static readonly AutodoorBracketForGS100UPVC_ArticleNo _L15227001 = new AutodoorBracketForGS100UPVC_ArticleNo(0, "L-15227-001");

            private AutodoorBracketForGS100UPVC_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GS100EndCapScrewM5AndLSupport_ArticleNo : Enumeration<GS100EndCapScrewM5AndLSupport_ArticleNo, int>
        {
            public static readonly GS100EndCapScrewM5AndLSupport_ArticleNo _L15227002 = new GS100EndCapScrewM5AndLSupport_ArticleNo(0, "L-15227-002");

            private GS100EndCapScrewM5AndLSupport_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class EuroLeadExitButton_ArticleNo : Enumeration<EuroLeadExitButton_ArticleNo, int>
        {
            public static readonly EuroLeadExitButton_ArticleNo _L15224001 = new EuroLeadExitButton_ArticleNo(0, "L-15224-001");

            private EuroLeadExitButton_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class TOOTHBELT_EM_CM_ArticleNo : Enumeration<TOOTHBELT_EM_CM_ArticleNo, int>
        {
            public static readonly TOOTHBELT_EM_CM_ArticleNo _A7134370 = new TOOTHBELT_EM_CM_ArticleNo(0, "A-7134370");

            private TOOTHBELT_EM_CM_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GuBeaZenMicrowaveSensor_ArticleNo : Enumeration<GuBeaZenMicrowaveSensor_ArticleNo, int>
        {
            public static readonly GuBeaZenMicrowaveSensor_ArticleNo _L15049052 = new GuBeaZenMicrowaveSensor_ArticleNo(0, "L-15049-052");

            private GuBeaZenMicrowaveSensor_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SlidingDoorKitGs100_1_ArticleNo : Enumeration<SlidingDoorKitGs100_1_ArticleNo, int>
        {
            public static readonly SlidingDoorKitGs100_1_ArticleNo _A9002180 = new SlidingDoorKitGs100_1_ArticleNo(0, "A-9002180");

            private SlidingDoorKitGs100_1_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class GS100CoverKit_ArticleNo : Enumeration<GS100CoverKit_ArticleNo, int>
        {
            public static readonly GS100CoverKit_ArticleNo _L15049052 = new GS100CoverKit_ArticleNo(0, "A-8007210");

            private GS100CoverKit_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class BillOfMaterialsFilter : Enumeration<BillOfMaterialsFilter, int>
        {
            public static readonly BillOfMaterialsFilter _PriceBreakDown = new BillOfMaterialsFilter(0, "Price Break Down");
            public static readonly BillOfMaterialsFilter _MaterialCost = new BillOfMaterialsFilter(1, "Material Cost");
            public static readonly BillOfMaterialsFilter _AccesorriesCost = new BillOfMaterialsFilter(2, "Accesorries");
            public static readonly BillOfMaterialsFilter _AncillaryProfileCost = new BillOfMaterialsFilter(3, "Ancillary Profile");
            public static readonly BillOfMaterialsFilter _FittingAndSuppliesCost = new BillOfMaterialsFilter(4, "Fitting and Supplies");

            private BillOfMaterialsFilter(int value, string displayName) : base(value, displayName) { }
        }

        public class PlantOnWeatherStripHead_ArticleNo : Enumeration<PlantOnWeatherStripHead_ArticleNo, int>
        {
            public static readonly PlantOnWeatherStripHead_ArticleNo _AL1313 = new PlantOnWeatherStripHead_ArticleNo(0, "AL-1313");

            private PlantOnWeatherStripHead_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class PlantOnWeatherStripSeal_ArticleNo : Enumeration<PlantOnWeatherStripSeal_ArticleNo, int>
        {
            public static readonly PlantOnWeatherStripSeal_ArticleNo _AL1314 = new PlantOnWeatherStripSeal_ArticleNo(0, "AL-1314");

            private PlantOnWeatherStripSeal_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LouverFrameWeatherStripHead_ArticleNo : Enumeration<LouverFrameWeatherStripHead_ArticleNo, int>
        {
            public static readonly LouverFrameWeatherStripHead_ArticleNo _AL1307 = new LouverFrameWeatherStripHead_ArticleNo(0, "AL-1307");

            private LouverFrameWeatherStripHead_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LouverFrameBottomWeatherStrip_ArticleNo : Enumeration<LouverFrameBottomWeatherStrip_ArticleNo, int>
        {
            public static readonly LouverFrameBottomWeatherStrip_ArticleNo _AL1309 = new LouverFrameBottomWeatherStrip_ArticleNo(0, "AL-1309");

            private LouverFrameBottomWeatherStrip_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class RubberSeal_ArticleNo : Enumeration<RubberSeal_ArticleNo, int>
        {
            public static readonly RubberSeal_ArticleNo _ALSC31 = new RubberSeal_ArticleNo(0, "AL-SC31");
            public static readonly RubberSeal_ArticleNo _SL31 = new RubberSeal_ArticleNo(1, "SL31");

            private RubberSeal_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CasementSeal_ArticleNo : Enumeration<CasementSeal_ArticleNo, int>
        {
            public static readonly CasementSeal_ArticleNo _SL31 = new CasementSeal_ArticleNo(0, "SL31");

            private CasementSeal_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SealForHandle_ArticleNo : Enumeration<SealForHandle_ArticleNo, int>
        {
            public static readonly SealForHandle_ArticleNo _AL1309 = new SealForHandle_ArticleNo(0, "AL-1309");

            private SealForHandle_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class LouverGallerySet_ArticleNo : Enumeration<LouverGallerySet_ArticleNo, int>
        {
            public static readonly LouverGallerySet_ArticleNo _LVRG15202SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-02-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15203SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-03-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15204SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-04-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15205SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-05-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15206SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-06-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15207SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-07-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15208SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-08-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15209SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-09-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15210SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-10-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15211SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-11-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15212SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-12-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15213SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-13-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15214SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-14-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15215SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-15-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15216SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-16-S-RH-Black");
            public static readonly LouverGallerySet_ArticleNo _LVRG15217SRHBlack = new LouverGallerySet_ArticleNo(0, "LVRG-152-17-S-RH-Black");

            private LouverGallerySet_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class BladeType_Option : Enumeration<BladeType_Option, int>
        {
            public static readonly BladeType_Option _glass = new BladeType_Option(0, "Glass");
            public static readonly BladeType_Option _Aluminum = new BladeType_Option(1, "Aluminum");


            private BladeType_Option(int value, string displayName) : base(value, displayName) { }
        }

        public class BladeCombination_Option : Enumeration<BladeCombination_Option, int>
        {
            public static readonly BladeCombination_Option _43 = new BladeCombination_Option(0, "4/3");
            public static readonly BladeCombination_Option _44 = new BladeCombination_Option(1, "4/4");
            public static readonly BladeCombination_Option _45 = new BladeCombination_Option(2, "4/5");
            public static readonly BladeCombination_Option _46 = new BladeCombination_Option(3, "4/6");
            public static readonly BladeCombination_Option _56 = new BladeCombination_Option(4, "5/6");
            public static readonly BladeCombination_Option _66 = new BladeCombination_Option(5, "6/6");
            public static readonly BladeCombination_Option _436 = new BladeCombination_Option(6, "4/3/6");
            public static readonly BladeCombination_Option _446 = new BladeCombination_Option(7, "4/4/6");
            public static readonly BladeCombination_Option _456 = new BladeCombination_Option(8, "4/5/6");
            public static readonly BladeCombination_Option _466 = new BladeCombination_Option(9, "4/6/6");
            public static readonly BladeCombination_Option _566 = new BladeCombination_Option(10, "5/6/6");


            private BladeCombination_Option(int value, string displayName) : base(value, displayName) { }
        }

        public class BladeHeight_Option : Enumeration<BladeHeight_Option, int>
        {
            public static readonly BladeHeight_Option _150 = new BladeHeight_Option(0, "150");
            public static readonly BladeHeight_Option _152 = new BladeHeight_Option(1, "152");


            private BladeHeight_Option(int value, string displayName) : base(value, displayName) { }
        }

        public class GalleryHandle_Option : Enumeration<GalleryHandle_Option, int>
        {
            public static readonly GalleryHandle_Option _single = new GalleryHandle_Option(0, "Single");
            public static readonly GalleryHandle_Option _dual = new GalleryHandle_Option(1, "Dual");
            public static readonly GalleryHandle_Option _ringPullControl = new GalleryHandle_Option(3, "Ring Pull Control");
            public static readonly GalleryHandle_Option _automated = new GalleryHandle_Option(4, "Automated");
            public static readonly GalleryHandle_Option _none = new GalleryHandle_Option(4, "None");
             
            private GalleryHandle_Option(int value, string displayName) : base(value, displayName) { }
        }

        public class GalleryHandleLoc_Option : Enumeration<GalleryHandleLoc_Option, int>
        {
            public static readonly GalleryHandleLoc_Option _LH = new GalleryHandleLoc_Option(0, "Left Hand");
            public static readonly GalleryHandleLoc_Option _RH = new GalleryHandleLoc_Option(1, "Right Hand");
            public static readonly GalleryHandleLoc_Option _H = new GalleryHandleLoc_Option(2, "With Holes");
            public static readonly GalleryHandleLoc_Option _none = new GalleryHandleLoc_Option(3, "None");
             
            private GalleryHandleLoc_Option(int value, string displayName) : base(value, displayName) { }
        }


        public class LouverType_Option : Enumeration<LouverType_Option, int>
        {
            public static readonly LouverType_Option _movable = new LouverType_Option(0, "Movable");
            public static readonly LouverType_Option _fixed = new LouverType_Option(1, "Fixed"); 

            private LouverType_Option(int value, string displayName) : base(value, displayName) { }
        }
    }
}
