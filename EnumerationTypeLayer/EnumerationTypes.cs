using Headspring;

namespace EnumerationTypeLayer
{
    public class EnumerationTypes
    {
        public class FrameProfile_ArticleNo : Enumeration<FrameProfile_ArticleNo>
        {
            public static readonly FrameProfile_ArticleNo _7502 = new FrameProfile_ArticleNo(0, "7502");
            public static readonly FrameProfile_ArticleNo _7507 = new FrameProfile_ArticleNo(1, "7507");
            private FrameProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrameReinf_ArticleNo : Enumeration<FrameReinf_ArticleNo>
        {
            public static readonly FrameReinf_ArticleNo _R676 = new FrameReinf_ArticleNo(0, "R676");
            public static readonly FrameReinf_ArticleNo _R677 = new FrameReinf_ArticleNo(1, "R677");
            private FrameReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Divider_ArticleNo : Enumeration<Divider_ArticleNo, int>
        {
            public static readonly Divider_ArticleNo _7536 = new Divider_ArticleNo(0, "7536");
            public static readonly Divider_ArticleNo _7538 = new Divider_ArticleNo(1, "7538");
            public static readonly Divider_ArticleNo _None = new Divider_ArticleNo(2, "None");
            private Divider_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class DividerReinf_ArticleNo : Enumeration<DividerReinf_ArticleNo, int>
        {
            public static readonly DividerReinf_ArticleNo _R677 = new DividerReinf_ArticleNo(0, "R677");
            public static readonly DividerReinf_ArticleNo _R686 = new DividerReinf_ArticleNo(1, "R686");
            private DividerReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
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
            public static readonly GlassFilm_Types _4milSolarGuard = new GlassFilm_Types(7, "4 mil (Solar Guard)");
            public static readonly GlassFilm_Types _4milUpera = new GlassFilm_Types(8, "4 mil (Upera)");
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

            private CladdingProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class CladdingReinf_ArticleNo : Enumeration<CladdingReinf_ArticleNo, int>
        {
            public static readonly CladdingReinf_ArticleNo _9120 = new CladdingReinf_ArticleNo(0, "9120");

            private CladdingReinf_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class SashProfile_ArticleNo : Enumeration<SashProfile_ArticleNo, int>
        {
            public static readonly SashProfile_ArticleNo _None = new SashProfile_ArticleNo(0, "None");
            public static readonly SashProfile_ArticleNo _7581 = new SashProfile_ArticleNo(1, "7581");
            public static readonly SashProfile_ArticleNo _374 = new SashProfile_ArticleNo(2, "374");
            public static readonly SashProfile_ArticleNo _395 = new SashProfile_ArticleNo(3, "395"); //inward
            private SashProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class SashReinf_ArticleNo : Enumeration<SashReinf_ArticleNo, int>
        {
            public static readonly SashReinf_ArticleNo _None = new SashReinf_ArticleNo(0, "None");
            public static readonly SashReinf_ArticleNo _R675 = new SashReinf_ArticleNo(1, "R675");
            public static readonly SashReinf_ArticleNo _655 = new SashReinf_ArticleNo(2, "655");
            public static readonly SashReinf_ArticleNo _207 = new SashReinf_ArticleNo(3, "207");
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
            public static readonly FrictionStay_ArticleNo _Storm8 = new FrictionStay_ArticleNo(0, "Storm 8");
            public static readonly FrictionStay_ArticleNo _477254 = new FrictionStay_ArticleNo(1, "477254");
            public static readonly FrictionStay_ArticleNo _A2121C1261 = new FrictionStay_ArticleNo(2, "A2121C1261");
            public static readonly FrictionStay_ArticleNo _A212C16161 = new FrictionStay_ArticleNo(3, "A212C16161");
            public static readonly FrictionStay_ArticleNo _Storm22 = new FrictionStay_ArticleNo(4, "Storm 22");
            public static readonly FrictionStay_ArticleNo _Storm26 = new FrictionStay_ArticleNo(5, "Storm 26");
            public static readonly FrictionStay_ArticleNo _None = new FrictionStay_ArticleNo(6, "None");

            private FrictionStay_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrictionStayCasement_ArticleNo : Enumeration<FrictionStayCasement_ArticleNo, int> //CW
        {
            public static readonly FrictionStayCasement_ArticleNo _485770 = new FrictionStayCasement_ArticleNo(0, "485770");
            public static readonly FrictionStayCasement_ArticleNo _A235B12161 = new FrictionStayCasement_ArticleNo(1, "A235B12161");
            public static readonly FrictionStayCasement_ArticleNo _A212C12161 = new FrictionStayCasement_ArticleNo(2, "A212C12161");
            public static readonly FrictionStayCasement_ArticleNo _A212C16161 = new FrictionStayCasement_ArticleNo(3, "A212C16161");
            public static readonly FrictionStayCasement_ArticleNo _A212C20161 = new FrictionStayCasement_ArticleNo(4, "A212C20161");
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
            public static readonly Handle_Type _None = new Handle_Type(5, "None");

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

        public class Espagnolette_ArticleNo : Enumeration<Espagnolette_ArticleNo, int>
        {
            public static readonly Espagnolette_ArticleNo _628806 = new Espagnolette_ArticleNo(0, "628806");
            public static readonly Espagnolette_ArticleNo _628807 = new Espagnolette_ArticleNo(1, "628807");
            public static readonly Espagnolette_ArticleNo _628809 = new Espagnolette_ArticleNo(2, "628809");
            public static readonly Espagnolette_ArticleNo _741012 = new Espagnolette_ArticleNo(3, "741012");
            public static readonly Espagnolette_ArticleNo _EQ87NT = new Espagnolette_ArticleNo(4, "EQ87(NT)");
            public static readonly Espagnolette_ArticleNo _None = new Espagnolette_ArticleNo(5, "None");

            private Espagnolette_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Extension_ArticleNo : Enumeration<Extension_ArticleNo, int>
        {
            public static readonly Extension_ArticleNo _None = new Extension_ArticleNo(0, "None");
            public static readonly Extension_ArticleNo _612978 = new Extension_ArticleNo(1, "612978");
            public static readonly Extension_ArticleNo _639957 = new Extension_ArticleNo(2, "639957");

            private Extension_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class CornerDrive_ArticleNo : Enumeration<CornerDrive_ArticleNo, int>
        {
            public static readonly CornerDrive_ArticleNo _None = new CornerDrive_ArticleNo(0, "None");
            public static readonly CornerDrive_ArticleNo _639958 = new CornerDrive_ArticleNo(1, "639958");

            private CornerDrive_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class Striker_ArticleNo : Enumeration<Striker_ArticleNo, int>
        {
            public static readonly Striker_ArticleNo _M89ANTA = new Striker_ArticleNo(0, "M89A-NT-A");
            public static readonly Striker_ArticleNo _M89ANTC = new Striker_ArticleNo(1, "M89A-NT-C");
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
            public static readonly HingeOption _2DHinge = new HingeOption(0, "2DHinge");
            public static readonly HingeOption _FrictionStay = new HingeOption(1, "Friction Stay");

            private HingeOption(int value, string displayName) : base(value, displayName) { }
        }

    }
}
