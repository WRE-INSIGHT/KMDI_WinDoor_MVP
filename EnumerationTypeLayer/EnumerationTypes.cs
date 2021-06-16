using Headspring;

namespace EnumerationTypeLayer
{
    public class EnumerationTypes
    {
        public class FrameProfile_ArticleNo : Enumeration<FrameProfile_ArticleNo>
        {
            public static readonly FrameProfile_ArticleNo _7502 = new FrameProfile_ArticleNo(0, "7502");
            private FrameProfile_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }

        public class FrameReinf_ArticleNo : Enumeration<FrameReinf_ArticleNo>
        {
            public static readonly FrameReinf_ArticleNo _R676 = new FrameReinf_ArticleNo(0, "R676");
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

        public class Glass_Thickness : Enumeration<Glass_Thickness, int>
        {
            public static readonly Glass_Thickness _6mm = new Glass_Thickness(0, "6mm");
            public static readonly Glass_Thickness _8mm = new Glass_Thickness(1, "8mm");
            public static readonly Glass_Thickness _10mm = new Glass_Thickness(2, "10mm");
            public static readonly Glass_Thickness _11mm = new Glass_Thickness(3, "11mm");
            public static readonly Glass_Thickness _12mm = new Glass_Thickness(4, "12mm");
            public static readonly Glass_Thickness _13mm = new Glass_Thickness(5, "13mm");
            public static readonly Glass_Thickness _14mm = new Glass_Thickness(6, "14mm");
            public static readonly Glass_Thickness _15mm = new Glass_Thickness(7, "15mm");
            public static readonly Glass_Thickness _16mm = new Glass_Thickness(8, "16mm");
            public static readonly Glass_Thickness _18mm = new Glass_Thickness(9, "18mm");
            public static readonly Glass_Thickness _20mm = new Glass_Thickness(10, "20mm");
            public static readonly Glass_Thickness _22mm = new Glass_Thickness(11, "22mm");
            public static readonly Glass_Thickness _23mm = new Glass_Thickness(12, "23mm");
            public static readonly Glass_Thickness _24mm = new Glass_Thickness(13, "24mm");
            public Glass_Thickness(int value, string displayName) : base(value, displayName) { }
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
            private GlazingBead_ArticleNo(int value, string displayName) : base(value, displayName) { }
        }
        public class GlassFilm_Types : Enumeration<GlassFilm_Types, int>
        {
            public static readonly GlassFilm_Types _VKoolOEM35 = new GlassFilm_Types(0, "V-Kool OEM-35");
            public static readonly GlassFilm_Types _Titanium = new GlassFilm_Types(1, "Titanium");
            public static readonly GlassFilm_Types _Silver40 = new GlassFilm_Types(2, "Silver 40");
            public static readonly GlassFilm_Types _Black50 = new GlassFilm_Types(3, "Black 50");
            public static readonly GlassFilm_Types _Black35 = new GlassFilm_Types(4, "Black 35");
            public static readonly GlassFilm_Types _Black05 = new GlassFilm_Types(5, "Black 05");
            public static readonly GlassFilm_Types _4milSolarGuard = new GlassFilm_Types(6, "4 mil (Solar Guard)");
            public static readonly GlassFilm_Types _4milUpera = new GlassFilm_Types(7, "4 mil (Upera)");
            public static readonly GlassFilm_Types _FrostedFilm = new GlassFilm_Types(8, "Frosted Film");
            public static readonly GlassFilm_Types _None = new GlassFilm_Types(9, "None");
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
    }
}
