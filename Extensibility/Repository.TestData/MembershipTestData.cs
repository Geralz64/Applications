using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TestData
{
    public class MembershipTestData
    {
        public string MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public int BirthDate { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }

        public static List<MembershipTestData> TestData()
        {
            var list = new List<MembershipTestData>
             {
                new MembershipTestData{MemberID = "6000000000", FirstName = "Jaqueline",     LastName = "Renato",      SSN = 10020, BirthDate = 19180317, StartDate = 20000907, EndDate = 20240211 },
                 new MembershipTestData{MemberID = "6000000001", FirstName = "Mozelle",   LastName = "Mireya",      SSN = 10030, BirthDate = 19190702, StartDate = 20001105, EndDate = 20240222 },
                 new MembershipTestData{MemberID = "6000000002", FirstName = "Alyse",         LastName = "Justina",     SSN = 10050, BirthDate = 19230520, StartDate = 20001124, EndDate = 20240625 },
                 new MembershipTestData{MemberID = "6000000003", FirstName = "Arnetta",   LastName = "Hillary",     SSN = 10080, BirthDate = 19261122, StartDate = 20010531, EndDate = 20240809 },
                 new MembershipTestData{MemberID = "6000000004", FirstName = "Kimi",      LastName = "Jo",          SSN = 10100, BirthDate = 19290804, StartDate = 20010710, EndDate = 20241215 },
                 new MembershipTestData{MemberID = "6000000005", FirstName = "Milda",         LastName = "Ignacio",     SSN = 10150, BirthDate = 19371208, StartDate = 20020204, EndDate = 20250908 },
                 new MembershipTestData{MemberID = "6000000006", FirstName = "Linh",      LastName = "Marnie",      SSN = 10160, BirthDate = 19410118, StartDate = 20020627, EndDate = 20251011 },
                 new MembershipTestData{MemberID = "6000000007", FirstName = "Franklin",  LastName = "Julianna",    SSN = 10200, BirthDate = 19410904, StartDate = 20020706, EndDate = 20251110 },
                 new MembershipTestData{MemberID = "6000000008", FirstName = "Nelida",        LastName = "William",     SSN = 10220, BirthDate = 19430806, StartDate = 20020806, EndDate = 20260330 },
                 new MembershipTestData{MemberID = "6000000009", FirstName = "Carol",         LastName = "Fidela",      SSN = 10280, BirthDate = 19431104, StartDate = 20030102, EndDate = 20260914 },
                 new MembershipTestData{MemberID = "6000000010", FirstName = "Bibi",      LastName = "Jayna",       SSN = 10520, BirthDate = 19520809, StartDate = 20041025, EndDate = 20261115 },
                 new MembershipTestData{MemberID = "6000000011", FirstName = "Alexa",         LastName = "Pasquale",    SSN = 10540, BirthDate = 19540310, StartDate = 20041126, EndDate = 20270227 },
                 new MembershipTestData{MemberID = "6000000012", FirstName = "Stefan",        LastName = "Maria",       SSN = 10550, BirthDate = 19540915, StartDate = 20050913, EndDate = 20271116 },
                 new MembershipTestData{MemberID = "6000000013", FirstName = "Cornelia",  LastName = "See",         SSN = 10650, BirthDate = 19541002, StartDate = 20050918, EndDate = 20271231 },
                 new MembershipTestData{MemberID = "6000000014", FirstName = "Adeline",   LastName = "Thelma",      SSN = 10690, BirthDate = 19560628, StartDate = 20060110, EndDate = 20280116 },
                 new MembershipTestData{MemberID = "6000000015", FirstName = "Trisha",        LastName = "Royal",       SSN = 10720, BirthDate = 19570505, StartDate = 20060509, EndDate = 20280329 },
                 new MembershipTestData{MemberID = "6000000016", FirstName = "Bernadette",    LastName = "Concepcion",   SSN = 10760, BirthDate = 19720121, StartDate = 20060527, EndDate = 20281030 },
                 new MembershipTestData{MemberID = "6000000017", FirstName = "Abigail",   LastName = "Natisha",     SSN = 10770, BirthDate = 19781021, StartDate = 20061218, EndDate = 20281115 },
                 new MembershipTestData{MemberID = "6000000018", FirstName = "Levi",      LastName = "Lucilla",     SSN = 10780, BirthDate = 19811118, StartDate = 20070531, EndDate = 20290124 },
                 new MembershipTestData{MemberID = "6000000019", FirstName = "Fanny",         LastName = "Catherin",    SSN = 10810, BirthDate = 19830711, StartDate = 20070915, EndDate = 20290903 },
                 new MembershipTestData{MemberID = "6000000020", FirstName = "Madeleine",     LastName = "Meredith",    SSN = 10850, BirthDate = 19880719, StartDate = 20080111, EndDate = 20291101 },
                 new MembershipTestData{MemberID = "6000000021", FirstName = "Magan",         LastName = "Adelina",     SSN = 10900, BirthDate = 19890110, StartDate = 20091002, EndDate = 20300530 },
                 new MembershipTestData{MemberID = "6000000022", FirstName = "Danial",        LastName = "Leona",       SSN = 10950, BirthDate = 19940114, StartDate = 20091213, EndDate = 20300801 },
                 new MembershipTestData{MemberID = "6000000023", FirstName = "Siu",       LastName = "Gladys",      SSN = 10960, BirthDate = 19990319, StartDate = 20101102, EndDate = 20300825 },
                 new MembershipTestData{MemberID = "6000000024", FirstName = "Eva",       LastName = "Versie",      SSN = 11040, BirthDate = 19990422, StartDate = 20101104, EndDate = 20300901 },
                 new MembershipTestData{MemberID = "6000000025", FirstName = "Todd",      LastName = "Barbera",     SSN = 11060, BirthDate = 19170607, StartDate = 20000510, EndDate = 20240123 },
                 new MembershipTestData{MemberID = "6000000026", FirstName = "Chas",      LastName = "Gary",        SSN = 11110, BirthDate = 19210511, StartDate = 20000925, EndDate = 20240227 },
                 new MembershipTestData{MemberID = "6000000027", FirstName = "Colene",        LastName = "Zoila",       SSN = 11120, BirthDate = 19220225, StartDate = 20020409, EndDate = 20240420 },
                 new MembershipTestData{MemberID = "6000000028", FirstName = "Jeni",      LastName = "Tristan",     SSN = 11160, BirthDate = 19230910, StartDate = 20020702, EndDate = 20240724 },
                 new MembershipTestData{MemberID = "6000000029", FirstName = "Conchita",  LastName = "Addie",       SSN = 11180, BirthDate = 19260321, StartDate = 20031115, EndDate = 20241017 },
                 new MembershipTestData{MemberID = "6000000030", FirstName = "Claretta",  LastName = "Eva",         SSN = 11210, BirthDate = 19280428, StartDate = 20041103, EndDate = 20241130 },
                 new MembershipTestData{MemberID = "6000000031", FirstName = "Charolette",    LastName = "Manuel",      SSN = 11290, BirthDate = 19321213, StartDate = 20041222, EndDate = 20241209 },
                 new MembershipTestData{MemberID = "6000000032", FirstName = "Rosella",   LastName = "Ha",          SSN = 11340, BirthDate = 19330529, StartDate = 20050714, EndDate = 20241229 },
                 new MembershipTestData{MemberID = "6000000033", FirstName = "Michelina",     LastName = "Abbey",       SSN = 11390, BirthDate = 19340420, StartDate = 20051027, EndDate = 20250307 },
                 new MembershipTestData{MemberID = "6000000034", FirstName = "Georgine",  LastName = "Hailey",      SSN = 11490, BirthDate = 19390106, StartDate = 20060514, EndDate = 20250407 },
                 new MembershipTestData{MemberID = "6000000035", FirstName = "Ebony",         LastName = "Criselda",    SSN = 11530, BirthDate = 19410504, StartDate = 20060910, EndDate = 20250520 },
                 new MembershipTestData{MemberID = "6000000036", FirstName = "Hildegard",     LastName = "Jacqueline",   SSN = 11600, BirthDate = 19440224, StartDate = 20061219, EndDate = 20251222 },
                 new MembershipTestData{MemberID = "6000000037", FirstName = "Rossie",        LastName = "Shira",       SSN = 11710, BirthDate = 19530223, StartDate = 20070401, EndDate = 20251230 },
                 new MembershipTestData{MemberID = "6000000038", FirstName = "Genevive",  LastName = "Elma",        SSN = 11770, BirthDate = 19550923, StartDate = 20070512, EndDate = 20260901 },
                 new MembershipTestData{MemberID = "6000000039", FirstName = "Lesley",        LastName = "Maura",       SSN = 11900, BirthDate = 19640607, StartDate = 20070703, EndDate = 20261014 },
                 new MembershipTestData{MemberID = "6000000040", FirstName = "Frederick",     LastName = "Kasandra",    SSN = 12010, BirthDate = 19700217, StartDate = 20070719, EndDate = 20261203 },
                 new MembershipTestData{MemberID = "6000000041", FirstName = "Doria",         LastName = "Daisy",       SSN = 12060, BirthDate = 19721125, StartDate = 20080110, EndDate = 20261209 },
                 new MembershipTestData{MemberID = "6000000042", FirstName = "Torrie",        LastName = "Jonnie",      SSN = 12160, BirthDate = 19810606, StartDate = 20080610, EndDate = 20270604 },
                 new MembershipTestData{MemberID = "6000000043", FirstName = "Elouise",   LastName = "Fredricka",   SSN = 12190, BirthDate = 19810609, StartDate = 20090125, EndDate = 20270812 },
                 new MembershipTestData{MemberID = "6000000044", FirstName = "Cathy",         LastName = "Valda",       SSN = 12200, BirthDate = 19821212, StartDate = 20091121, EndDate = 20291126 },
                 new MembershipTestData{MemberID = "6000000045", FirstName = "Sara",      LastName = "Joanne",      SSN = 12310, BirthDate = 19870720, StartDate = 20100120, EndDate = 20300306 },
                 new MembershipTestData{MemberID = "6000000046", FirstName = "Rudy",      LastName = "Elayne",      SSN = 12350, BirthDate = 19881016, StartDate = 20100214, EndDate = 20300420 },
                 new MembershipTestData{MemberID = "6000000047", FirstName = "Blair",         LastName = "Latia",       SSN = 12410, BirthDate = 19930517, StartDate = 20100402, EndDate = 20300609 },
                 new MembershipTestData{MemberID = "6000000048", FirstName = "Renay",         LastName = "Leola",       SSN = 12460, BirthDate = 19951228, StartDate = 20101010, EndDate = 20300705 },
                 new MembershipTestData{MemberID = "6000000049", FirstName = "Nena",      LastName = "Odell",       SSN = 12500, BirthDate = 19960219, StartDate = 20101028, EndDate = 20301225 },
                 new MembershipTestData{MemberID = "6000000050", FirstName = "Aurelia",   LastName = "Sid",         SSN = 12530, BirthDate = 19170911, StartDate = 20000204, EndDate = 20240401 },
                 new MembershipTestData{MemberID = "6000000051", FirstName = "Martin",        LastName = "Chase",       SSN = 12540, BirthDate = 19190505, StartDate = 20000802, EndDate = 20241118 },
                 new MembershipTestData{MemberID = "6000000052", FirstName = "Cythia",        LastName = "Launa",       SSN = 12550, BirthDate = 19210919, StartDate = 20010218, EndDate = 20250102 },
                 new MembershipTestData{MemberID = "6000000053", FirstName = "Anita",         LastName = "Lavenia",     SSN = 12580, BirthDate = 19220828, StartDate = 20010226, EndDate = 20250128 },
                 new MembershipTestData{MemberID = "6000000054", FirstName = "Dorian",        LastName = "Eileen",      SSN = 12720, BirthDate = 19241010, StartDate = 20010402, EndDate = 20250713 },
                 new MembershipTestData{MemberID = "6000000055", FirstName = "Taryn",         LastName = "Jeni",        SSN = 12770, BirthDate = 19241106, StartDate = 20010416, EndDate = 20250930 },
                 new MembershipTestData{MemberID = "6000000056", FirstName = "Brande",        LastName = "Monika",      SSN = 12780, BirthDate = 19260522, StartDate = 20010727, EndDate = 20251120 },
                 new MembershipTestData{MemberID = "6000000057", FirstName = "Winona",        LastName = "Marissa",     SSN = 12840, BirthDate = 19301110, StartDate = 20011209, EndDate = 20260418 },
                 new MembershipTestData{MemberID = "6000000058", FirstName = "Maye",      LastName = "Madge",       SSN = 12960, BirthDate = 19330618, StartDate = 20040222, EndDate = 20260630 },
                 new MembershipTestData{MemberID = "6000000059", FirstName = "Ginny",         LastName = "Linsey",      SSN = 12970, BirthDate = 19350513, StartDate = 20040719, EndDate = 20261031 },
                 new MembershipTestData{MemberID = "6000000060", FirstName = "Oralia",        LastName = "Lanny",       SSN = 13000, BirthDate = 19380616, StartDate = 20060113, EndDate = 20261201 },
                 new MembershipTestData{MemberID = "6000000061", FirstName = "Ema",       LastName = "Wynell",      SSN = 13060, BirthDate = 19410711, StartDate = 20060114, EndDate = 20270317 },
                 new MembershipTestData{MemberID = "6000000062", FirstName = "Theressa",  LastName = "Esteban",     SSN = 13110, BirthDate = 19450213, StartDate = 20060420, EndDate = 20270513 },
                 new MembershipTestData{MemberID = "6000000063", FirstName = "Darline",   LastName = "Cristopher",   SSN = 13190, BirthDate = 19450407, StartDate = 20060827, EndDate = 20270604 },
                 new MembershipTestData{MemberID = "6000000064", FirstName = "Lera",      LastName = "Val",         SSN = 13230, BirthDate = 19530307, StartDate = 20061002, EndDate = 20271209 },
                 new MembershipTestData{MemberID = "6000000065", FirstName = "Tracey",        LastName = "Hannah",      SSN = 13250, BirthDate = 19610122, StartDate = 20070418, EndDate = 20280131 },
                 new MembershipTestData{MemberID = "6000000066", FirstName = "Natashia",  LastName = "Leone",       SSN = 13440, BirthDate = 19631107, StartDate = 20070926, EndDate = 20280217 },
                 new MembershipTestData{MemberID = "6000000067", FirstName = "Tyron",         LastName = "Torrie",      SSN = 13500, BirthDate = 19680403, StartDate = 20080101, EndDate = 20280304 },
                 new MembershipTestData{MemberID = "6000000068", FirstName = "Melani",        LastName = "Karry",       SSN = 13530, BirthDate = 19720310, StartDate = 20080210, EndDate = 20281220 },
                 new MembershipTestData{MemberID = "6000000069", FirstName = "Edmond",        LastName = "Yer",         SSN = 13570, BirthDate = 19721223, StartDate = 20080504, EndDate = 20290508 },
                 new MembershipTestData{MemberID = "6000000070", FirstName = "Mitchel",   LastName = "Nena",        SSN = 13580, BirthDate = 19740702, StartDate = 20081119, EndDate = 20291031 },
                 new MembershipTestData{MemberID = "6000000071", FirstName = "Laraine",   LastName = "Joye",        SSN = 13640, BirthDate = 19790214, StartDate = 20081126, EndDate = 20300702 },
                 new MembershipTestData{MemberID = "6000000072", FirstName = "Cathrine",  LastName = "Tabetha",     SSN = 13770, BirthDate = 19800722, StartDate = 20090429, EndDate = 20300722 },
                 new MembershipTestData{MemberID = "6000000073", FirstName = "Emerald",   LastName = "Shavonda",    SSN = 13790, BirthDate = 19920331, StartDate = 20090719, EndDate = 20300727 },
                 new MembershipTestData{MemberID = "6000000074", FirstName = "Willie",        LastName = "Lyndsey",     SSN = 13800, BirthDate = 19940417, StartDate = 20090825, EndDate = 20301017 },
                 new MembershipTestData{MemberID = "6000000075", FirstName = "Ninfa",         LastName = "Vance",       SSN = 13860, BirthDate = 19180806, StartDate = 20000209, EndDate = 20240222 },
                 new MembershipTestData{MemberID = "6000000076", FirstName = "Mirtha",        LastName = "Sau",         SSN = 13880, BirthDate = 19211123, StartDate = 20000525, EndDate = 20240418 },
                 new MembershipTestData{MemberID = "6000000077", FirstName = "Shaquana",  LastName = "Gayla",       SSN = 13890, BirthDate = 19220225, StartDate = 20000811, EndDate = 20241102 },
                 new MembershipTestData{MemberID = "6000000078", FirstName = "Lorrine",   LastName = "Shaunda",     SSN = 13930, BirthDate = 19220724, StartDate = 20001215, EndDate = 20250502 },
                 new MembershipTestData{MemberID = "6000000079", FirstName = "Quyen",         LastName = "Temple",      SSN = 13960, BirthDate = 19250614, StartDate = 20011217, EndDate = 20250528 },
                 new MembershipTestData{MemberID = "6000000080", FirstName = "Kattie",        LastName = "Ludie",       SSN = 14000, BirthDate = 19260828, StartDate = 20020503, EndDate = 20250611 },
                 new MembershipTestData{MemberID = "6000000081", FirstName = "Deandra",   LastName = "Amiee",       SSN = 14030, BirthDate = 19280811, StartDate = 20030623, EndDate = 20250919 },
                 new MembershipTestData{MemberID = "6000000082", FirstName = "Rosella",   LastName = "Ramonita",    SSN = 14050, BirthDate = 19290802, StartDate = 20030821, EndDate = 20251218 },
                 new MembershipTestData{MemberID = "6000000083", FirstName = "Ali",       LastName = "Yoshiko",     SSN = 14090, BirthDate = 19331028, StartDate = 20031129, EndDate = 20260317 },
                 new MembershipTestData{MemberID = "6000000084", FirstName = "Mellisa",   LastName = "Hong",        SSN = 14120, BirthDate = 19420808, StartDate = 20040101, EndDate = 20260404 },
                 new MembershipTestData{MemberID = "6000000085", FirstName = "Tomasa",        LastName = "Rory",        SSN = 14200, BirthDate = 19430213, StartDate = 20040110, EndDate = 20260406 },
                 new MembershipTestData{MemberID = "6000000086", FirstName = "Micha",         LastName = "Dona",        SSN = 14410, BirthDate = 19470217, StartDate = 20040430, EndDate = 20260412 },
                 new MembershipTestData{MemberID = "6000000087", FirstName = "Winter",        LastName = "Dia",         SSN = 14450, BirthDate = 19601022, StartDate = 20050610, EndDate = 20260503 },
                 new MembershipTestData{MemberID = "6000000088", FirstName = "Delma",         LastName = "Argentina",   SSN = 14520, BirthDate = 19651123, StartDate = 20060706, EndDate = 20260720 },
                 new MembershipTestData{MemberID = "6000000089", FirstName = "Inger",         LastName = "Robbi",       SSN = 14540, BirthDate = 19671008, StartDate = 20070130, EndDate = 20260818 },
                 new MembershipTestData{MemberID = "6000000090", FirstName = "Stevie",        LastName = "Maricruz",    SSN = 14590, BirthDate = 19671209, StartDate = 20070623, EndDate = 20260824 },
                 new MembershipTestData{MemberID = "6000000091", FirstName = "Tresa",         LastName = "Chadwick",    SSN = 14600, BirthDate = 19810430, StartDate = 20070708, EndDate = 20270322 },
                 new MembershipTestData{MemberID = "6000000092", FirstName = "Spencer",   LastName = "Gwenda",      SSN = 14670, BirthDate = 19861028, StartDate = 20071126, EndDate = 20270926 },
                 new MembershipTestData{MemberID = "6000000093", FirstName = "Lashandra",     LastName = "Bo",          SSN = 14680, BirthDate = 19870812, StartDate = 20080313, EndDate = 20280115 },
                 new MembershipTestData{MemberID = "6000000094", FirstName = "Margeret",  LastName = "Vania",       SSN = 14700, BirthDate = 19910223, StartDate = 20080510, EndDate = 20290611 },
                 new MembershipTestData{MemberID = "6000000095", FirstName = "Jennell",   LastName = "Merry",       SSN = 14740, BirthDate = 19930518, StartDate = 20080703, EndDate = 20291221 },
                 new MembershipTestData{MemberID = "6000000096", FirstName = "Classie",   LastName = "Drema",       SSN = 14780, BirthDate = 19940719, StartDate = 20090419, EndDate = 20300824 },
                 new MembershipTestData{MemberID = "6000000097", FirstName = "Jenette",   LastName = "Alycia",      SSN = 14850, BirthDate = 19950316, StartDate = 20100320, EndDate = 20300829 },
                 new MembershipTestData{MemberID = "6000000098", FirstName = "Kimbra",        LastName = "Keiko",       SSN = 14910, BirthDate = 19990329, StartDate = 20100812, EndDate = 20301011 },
                 new MembershipTestData{MemberID = "6000000099", FirstName = "Anika",         LastName = "Coleman",     SSN = 14980, BirthDate = 19991002, StartDate = 20101009, EndDate = 20301107 }
             };

            return list;

        }

        public static Task<List<MembershipTestData>> TestDataAsync()
        {

            Task<List<MembershipTestData>> task = null;
            
            task = Task.Run(() =>
            {
                var results = TestData();
                return results;

            });

            return task;

        }

        public static Task<List<MembershipTestData>> TestDataAsync(string memberID)
        {

            Task<List<MembershipTestData>> task = null;

            task = Task.Run(() =>
            {
                var results = TestData().Where(t => t.MemberID == memberID).ToList<MembershipTestData>();
                return results;

            });

            return task;

        }

        public static List<string> FixedLengthTestData()
        {
            var list = new List<string>
            {
                    "6000000000           Jaqueline              Renato10020191803172000090720240211",
                    "6000000001             Mozelle              Mireya10030191907022000110520240222",
                    "6000000002               Alyse             Justina10050192305202000112420240625",
                    "6000000003             Arnetta             Hillary10080192611222001053120240809",
                    "6000000004                Kimi                  Jo10100192908042001071020241215",
                    "6000000005               Milda             Ignacio10150193712082002020420250908",
                    "6000000006                Linh              Marnie10160194101182002062720251011",
                    "6000000007            Franklin            Julianna10200194109042002070620251110",
                    "6000000008              Nelida             William10220194308062002080620260330",
                    "6000000009               Carol              Fidela10280194311042003010220260914",
                    "6000000010                Bibi               Jayna10520195208092004102520261115",
                    "6000000011               Alexa            Pasquale10540195403102004112620270227",
                    "6000000012              Stefan               Maria10550195409152005091320271116",
                    "6000000013            Cornelia                 See10650195410022005091820271231",
                    "6000000014             Adeline              Thelma10690195606282006011020280116",
                    "6000000015              Trisha               Royal10720195705052006050920280329",
                    "6000000016          Bernadette          Concepcion10760197201212006052720281030",
                    "6000000017             Abigail             Natisha10770197810212006121820281115",
                    "6000000018                Levi             Lucilla10780198111182007053120290124",
                    "6000000019               Fanny            Catherin10810198307112007091520290903",
                    "6000000020           Madeleine            Meredith10850198807192008011120291101",
                    "6000000021               Magan             Adelina10900198901102009100220300530",
                    "6000000022              Danial               Leona10950199401142009121320300801",
                    "6000000023                 Siu              Gladys10960199903192010110220300825",
                    "6000000024                 Eva              Versie11040199904222010110420300901",
                    "6000000025                Todd             Barbera11060191706072000051020240123",
                    "6000000026                Chas                Gary11110192105112000092520240227",
                    "6000000027              Colene               Zoila11120192202252002040920240420",
                    "6000000028                Jeni             Tristan11160192309102002070220240724",
                    "6000000029            Conchita               Addie11180192603212003111520241017",
                    "6000000030            Claretta                 Eva11210192804282004110320241130",
                    "6000000031          Charolette              Manuel11290193212132004122220241209",
                    "6000000032             Rosella                  Ha11340193305292005071420241229",
                    "6000000033           Michelina               Abbey11390193404202005102720250307",
                    "6000000034            Georgine              Hailey11490193901062006051420250407",
                    "6000000035               Ebony            Criselda11530194105042006091020250520",
                    "6000000036           Hildegard          Jacqueline11600194402242006121920251222",
                    "6000000037              Rossie               Shira11710195302232007040120251230",
                    "6000000038            Genevive                Elma11770195509232007051220260901",
                    "6000000039              Lesley               Maura11900196406072007070320261014",
                    "6000000040           Frederick            Kasandra12010197002172007071920261203",
                    "6000000041               Doria               Daisy12060197211252008011020261209",
                    "6000000042              Torrie              Jonnie12160198106062008061020270604",
                    "6000000043             Elouise           Fredricka12190198106092009012520270812",
                    "6000000044               Cathy               Valda12200198212122009112120291126",
                    "6000000045                Sara              Joanne12310198707202010012020300306",
                    "6000000046                Rudy              Elayne12350198810162010021420300420",
                    "6000000047               Blair               Latia12410199305172010040220300609",
                    "6000000048               Renay               Leola12460199512282010101020300705",
                    "6000000049                Nena               Odell12500199602192010102820301225",
                    "6000000050             Aurelia                 Sid12530191709112000020420240401",
                    "6000000051              Martin               Chase12540191905052000080220241118",
                    "6000000052              Cythia               Launa12550192109192001021820250102",
                    "6000000053               Anita             Lavenia12580192208282001022620250128",
                    "6000000054              Dorian              Eileen12720192410102001040220250713",
                    "6000000055               Taryn                Jeni12770192411062001041620250930",
                    "6000000056              Brande              Monika12780192605222001072720251120",
                    "6000000057              Winona             Marissa12840193011102001120920260418",
                    "6000000058                Maye               Madge12960193306182004022220260630",
                    "6000000059               Ginny              Linsey12970193505132004071920261031",
                    "6000000060              Oralia               Lanny13000193806162006011320261201",
                    "6000000061                 Ema              Wynell13060194107112006011420270317",
                    "6000000062            Theressa             Esteban13110194502132006042020270513",
                    "6000000063             Darline          Cristopher13190194504072006082720270604",
                    "6000000064                Lera                 Val13230195303072006100220271209",
                    "6000000065              Tracey              Hannah13250196101222007041820280131",
                    "6000000066            Natashia               Leone13440196311072007092620280217",
                    "6000000067               Tyron              Torrie13500196804032008010120280304",
                    "6000000068              Melani               Karry13530197203102008021020281220",
                    "6000000069              Edmond                 Yer13570197212232008050420290508",
                    "6000000070             Mitchel                Nena13580197407022008111920291031",
                    "6000000071             Laraine                Joye13640197902142008112620300702",
                    "6000000072            Cathrine             Tabetha13770198007222009042920300722",
                    "6000000073             Emerald            Shavonda13790199203312009071920300727",
                    "6000000074              Willie             Lyndsey13800199404172009082520301017",
                    "6000000075               Ninfa               Vance13860191808062000020920240222",
                    "6000000076              Mirtha                 Sau13880192111232000052520240418",
                    "6000000077            Shaquana               Gayla13890192202252000081120241102",
                    "6000000078             Lorrine             Shaunda13930192207242000121520250502",
                    "6000000079               Quyen              Temple13960192506142001121720250528",
                    "6000000080              Kattie               Ludie14000192608282002050320250611",
                    "6000000081             Deandra               Amiee14030192808112003062320250919",
                    "6000000082             Rosella            Ramonita14050192908022003082120251218",
                    "6000000083                 Ali             Yoshiko14090193310282003112920260317",
                    "6000000084             Mellisa                Hong14120194208082004010120260404",
                    "6000000085              Tomasa                Rory14200194302132004011020260406",
                    "6000000086               Micha                Dona14410194702172004043020260412",
                    "6000000087              Winter                 Dia14450196010222005061020260503",
                    "6000000088               Delma           Argentina14520196511232006070620260720",
                    "6000000089               Inger               Robbi14540196710082007013020260818",
                    "6000000090              Stevie            Maricruz14590196712092007062320260824",
                    "6000000091               Tresa            Chadwick14600198104302007070820270322",
                    "6000000092             Spencer              Gwenda14670198610282007112620270926",
                    "6000000093           Lashandra                  Bo14680198708122008031320280115",
                    "6000000094            Margeret               Vania14700199102232008051020290611",
                    "6000000095             Jennell               Merry14740199305182008070320291221",
                    "6000000096             Classie               Drema14780199407192009041920300824",
                    "6000000097             Jenette              Alycia14850199503162010032020300829",
                    "6000000098              Kimbra               Keiko14910199903292010081220301011",
                    "6000000099               Anika             Coleman14980199910022010100920301107"
            };

            return list;

        }

        public static List<string> CSVTestData()
        {
            var list = new List<string> {

                       "6000000000,Jaqueline,Renato,10020,19180317,20000907,20240211",
                       "6000000001,Mozelle,Mireya,10030,19190702,20001105,20240222",
                       "6000000002,Alyse,Justina,10050,19230520,20001124,20240625",
                       "6000000003,Arnetta,Hillary,10080,19261122,20010531,20240809",
                       "6000000004,Kimi,Jo,10100,19290804,20010710,20241215",
                       "6000000005,Milda,Ignacio,10150,19371208,20020204,20250908",
                       "6000000006,Linh,Marnie,10160,19410118,20020627,20251011",
                       "6000000007,Franklin,Julianna,10200,19410904,20020706,20251110",
                       "6000000008,Nelida,William,10220,19430806,20020806,20260330",
                       "6000000009,Carol,Fidela,10280,19431104,20030102,20260914",
                       "6000000010,Bibi,Jayna,10520,19520809,20041025,20261115",
                       "6000000011,Alexa,Pasquale,10540,19540310,20041126,20270227",
                       "6000000012,Stefan,Maria,10550,19540915,20050913,20271116",
                       "6000000013,Cornelia,See,10650,19541002,20050918,20271231",
                       "6000000014,Adeline,Thelma,10690,19560628,20060110,20280116",
                       "6000000015,Trisha,Royal,10720,19570505,20060509,20280329",
                       "6000000016,Bernadette,Concepcion,10760,19720121,20060527,20281030",
                       "6000000017,Abigail,Natisha,10770,19781021,20061218,20281115",
                       "6000000018,Levi,Lucilla,10780,19811118,20070531,20290124",
                       "6000000019,Fanny,Catherin,10810,19830711,20070915,20290903",
                       "6000000020,Madeleine,Meredith,10850,19880719,20080111,20291101",
                       "6000000021,Magan,Adelina,10900,19890110,20091002,20300530",
                       "6000000022,Danial,Leona,10950,19940114,20091213,20300801",
                       "6000000023,Siu,Gladys,10960,19990319,20101102,20300825",
                       "6000000024,Eva,Versie,11040,19990422,20101104,20300901",
                       "6000000025,Todd,Barbera,11060,19170607,20000510,20240123",
                       "6000000026,Chas,Gary,11110,19210511,20000925,20240227",
                       "6000000027,Colene,Zoila,11120,19220225,20020409,20240420",
                       "6000000028,Jeni,Tristan,11160,19230910,20020702,20240724",
                       "6000000029,Conchita,Addie,11180,19260321,20031115,20241017",
                       "6000000030,Claretta,Eva,11210,19280428,20041103,20241130",
                       "6000000031,Charolette,Manuel,11290,19321213,20041222,20241209",
                       "6000000032,Rosella,Ha,11340,19330529,20050714,20241229",
                       "6000000033,Michelina,Abbey,11390,19340420,20051027,20250307",
                       "6000000034,Georgine,Hailey,11490,19390106,20060514,20250407",
                       "6000000035,Ebony,Criselda,11530,19410504,20060910,20250520",
                       "6000000036,Hildegard,Jacqueline,11600,19440224,20061219,20251222",
                       "6000000037,Rossie,Shira,11710,19530223,20070401,20251230",
                       "6000000038,Genevive,Elma,11770,19550923,20070512,20260901",
                       "6000000039,Lesley,Maura,11900,19640607,20070703,20261014",
                       "6000000040,Frederick,Kasandra,12010,19700217,20070719,20261203",
                       "6000000041,Doria,Daisy,12060,19721125,20080110,20261209",
                       "6000000042,Torrie,Jonnie,12160,19810606,20080610,20270604",
                       "6000000043,Elouise,Fredricka,12190,19810609,20090125,20270812",
                       "6000000044,Cathy,Valda,12200,19821212,20091121,20291126",
                       "6000000045,Sara,Joanne,12310,19870720,20100120,20300306",
                       "6000000046,Rudy,Elayne,12350,19881016,20100214,20300420",
                       "6000000047,Blair,Latia,12410,19930517,20100402,20300609",
                       "6000000048,Renay,Leola,12460,19951228,20101010,20300705",
                       "6000000049,Nena,Odell,12500,19960219,20101028,20301225",
                       "6000000050,Aurelia,Sid,12530,19170911,20000204,20240401",
                       "6000000051,Martin,Chase,12540,19190505,20000802,20241118",
                       "6000000052,Cythia,Launa,12550,19210919,20010218,20250102",
                       "6000000053,Anita,Lavenia,12580,19220828,20010226,20250128",
                       "6000000054,Dorian,Eileen,12720,19241010,20010402,20250713",
                       "6000000055,Taryn,Jeni,12770,19241106,20010416,20250930",
                       "6000000056,Brande,Monika,12780,19260522,20010727,20251120",
                       "6000000057,Winona,Marissa,12840,19301110,20011209,20260418",
                       "6000000058,Maye,Madge,12960,19330618,20040222,20260630",
                       "6000000059,Ginny,Linsey,12970,19350513,20040719,20261031",
                       "6000000060,Oralia,Lanny,13000,19380616,20060113,20261201",
                       "6000000061,Ema,Wynell,13060,19410711,20060114,20270317",
                       "6000000062,Theressa,Esteban,13110,19450213,20060420,20270513",
                       "6000000063,Darline,Cristopher,13190,19450407,20060827,20270604",
                       "6000000064,Lera,Val,13230,19530307,20061002,20271209",
                       "6000000065,Tracey,Hannah,13250,19610122,20070418,20280131",
                       "6000000066,Natashia,Leone,13440,19631107,20070926,20280217",
                       "6000000067,Tyron,Torrie,13500,19680403,20080101,20280304",
                       "6000000068,Melani,Karry,13530,19720310,20080210,20281220",
                       "6000000069,Edmond,Yer,13570,19721223,20080504,20290508",
                       "6000000070,Mitchel,Nena,13580,19740702,20081119,20291031",
                       "6000000071,Laraine,Joye,13640,19790214,20081126,20300702",
                       "6000000072,Cathrine,Tabetha,13770,19800722,20090429,20300722",
                       "6000000073,Emerald,Shavonda,13790,19920331,20090719,20300727",
                       "6000000074,Willie,Lyndsey,13800,19940417,20090825,20301017",
                       "6000000075,Ninfa,Vance,13860,19180806,20000209,20240222",
                       "6000000076,Mirtha,Sau,13880,19211123,20000525,20240418",
                       "6000000077,Shaquana,Gayla,13890,19220225,20000811,20241102",
                       "6000000078,Lorrine,Shaunda,13930,19220724,20001215,20250502",
                       "6000000079,Quyen,Temple,13960,19250614,20011217,20250528",
                       "6000000080,Kattie,Ludie,14000,19260828,20020503,20250611",
                       "6000000081,Deandra,Amiee,14030,19280811,20030623,20250919",
                       "6000000082,Rosella,Ramonita,14050,19290802,20030821,20251218",
                       "6000000083,Ali,Yoshiko,14090,19331028,20031129,20260317",
                       "6000000084,Mellisa,Hong,14120,19420808,20040101,20260404",
                       "6000000085,Tomasa,Rory,14200,19430213,20040110,20260406",
                       "6000000086,Micha,Dona,14410,19470217,20040430,20260412",
                       "6000000087,Winter,Dia,14450,19601022,20050610,20260503",
                       "6000000088,Delma,Argentina,14520,19651123,20060706,20260720",
                       "6000000089,Inger,Robbi,14540,19671008,20070130,20260818",
                       "6000000090,Stevie,Maricruz,14590,19671209,20070623,20260824",
                       "6000000091,Tresa,Chadwick,14600,19810430,20070708,20270322",
                       "6000000092,Spencer,Gwenda,14670,19861028,20071126,20270926",
                       "6000000093,Lashandra,Bo,14680,19870812,20080313,20280115",
                       "6000000094,Margeret,Vania,14700,19910223,20080510,20290611",
                       "6000000095,Jennell,Merry,14740,19930518,20080703,20291221",
                       "6000000096,Classie,Drema,14780,19940719,20090419,20300824",
                       "6000000097,Jenette,Alycia,14850,19950316,20100320,20300829",
                       "6000000098,Kimbra,Keiko,14910,19990329,20100812,20301011",
                       "6000000099,Anika,Coleman,14980,19991002,20101009,20301107"

                       };



            return list;

        }

        public static string SingleLineTestData()
        {
            var data = "6000000000           Jaqueline              Renato100201918031720000907202402116000000001             Mozelle              Mireya100301919070220001105202402226000000002               Alyse             Justina100501923052020001124202406256000000003             Arnetta             Hillary100801926112220010531202408096000000004                Kimi                  Jo101001929080420010710202412156000000005               Milda             Ignacio101501937120820020204202509086000000006                Linh              Marnie101601941011820020627202510116000000007            Franklin            Julianna102001941090420020706202511106000000008              Nelida             William102201943080620020806202603306000000009               Carol              Fidela102801943110420030102202609146000000010                Bibi               Jayna105201952080920041025202611156000000011               Alexa            Pasquale105401954031020041126202702276000000012              Stefan               Maria105501954091520050913202711166000000013            Cornelia                 See106501954100220050918202712316000000014             Adeline              Thelma106901956062820060110202801166000000015              Trisha               Royal107201957050520060509202803296000000016          Bernadette          Concepcion107601972012120060527202810306000000017             Abigail             Natisha107701978102120061218202811156000000018                Levi             Lucilla107801981111820070531202901246000000019               Fanny            Catherin108101983071120070915202909036000000020           Madeleine            Meredith108501988071920080111202911016000000021               Magan             Adelina109001989011020091002203005306000000022              Danial               Leona109501994011420091213203008016000000023                 Siu              Gladys109601999031920101102203008256000000024                 Eva              Versie110401999042220101104203009016000000025                Todd             Barbera110601917060720000510202401236000000026                Chas                Gary111101921051120000925202402276000000027              Colene               Zoila111201922022520020409202404206000000028                Jeni             Tristan111601923091020020702202407246000000029            Conchita               Addie111801926032120031115202410176000000030            Claretta                 Eva112101928042820041103202411306000000031          Charolette              Manuel112901932121320041222202412096000000032             Rosella                  Ha113401933052920050714202412296000000033           Michelina               Abbey113901934042020051027202503076000000034            Georgine              Hailey114901939010620060514202504076000000035               Ebony            Criselda115301941050420060910202505206000000036           Hildegard          Jacqueline116001944022420061219202512226000000037              Rossie               Shira117101953022320070401202512306000000038            Genevive                Elma117701955092320070512202609016000000039              Lesley               Maura119001964060720070703202610146000000040           Frederick            Kasandra120101970021720070719202612036000000041               Doria               Daisy120601972112520080110202612096000000042              Torrie              Jonnie121601981060620080610202706046000000043             Elouise           Fredricka121901981060920090125202708126000000044               Cathy               Valda122001982121220091121202911266000000045                Sara              Joanne123101987072020100120203003066000000046                Rudy              Elayne123501988101620100214203004206000000047               Blair               Latia124101993051720100402203006096000000048               Renay               Leola124601995122820101010203007056000000049                Nena               Odell125001996021920101028203012256000000050             Aurelia                 Sid125301917091120000204202404016000000051              Martin               Chase125401919050520000802202411186000000052              Cythia               Launa125501921091920010218202501026000000053               Anita             Lavenia125801922082820010226202501286000000054              Dorian              Eileen127201924101020010402202507136000000055               Taryn                Jeni127701924110620010416202509306000000056              Brande              Monika127801926052220010727202511206000000057              Winona             Marissa128401930111020011209202604186000000058                Maye               Madge129601933061820040222202606306000000059               Ginny              Linsey129701935051320040719202610316000000060              Oralia               Lanny130001938061620060113202612016000000061                 Ema              Wynell130601941071120060114202703176000000062            Theressa             Esteban131101945021320060420202705136000000063             Darline          Cristopher131901945040720060827202706046000000064                Lera                 Val132301953030720061002202712096000000065              Tracey              Hannah132501961012220070418202801316000000066            Natashia               Leone134401963110720070926202802176000000067               Tyron              Torrie135001968040320080101202803046000000068              Melani               Karry135301972031020080210202812206000000069              Edmond                 Yer135701972122320080504202905086000000070             Mitchel                Nena135801974070220081119202910316000000071             Laraine                Joye136401979021420081126203007026000000072            Cathrine             Tabetha137701980072220090429203007226000000073             Emerald            Shavonda137901992033120090719203007276000000074              Willie             Lyndsey138001994041720090825203010176000000075               Ninfa               Vance138601918080620000209202402226000000076              Mirtha                 Sau138801921112320000525202404186000000077            Shaquana               Gayla138901922022520000811202411026000000078             Lorrine             Shaunda139301922072420001215202505026000000079               Quyen              Temple139601925061420011217202505286000000080              Kattie               Ludie140001926082820020503202506116000000081             Deandra               Amiee140301928081120030623202509196000000082             Rosella            Ramonita140501929080220030821202512186000000083                 Ali             Yoshiko140901933102820031129202603176000000084             Mellisa                Hong141201942080820040101202604046000000085              Tomasa                Rory142001943021320040110202604066000000086               Micha                Dona144101947021720040430202604126000000087              Winter                 Dia144501960102220050610202605036000000088               Delma           Argentina145201965112320060706202607206000000089               Inger               Robbi145401967100820070130202608186000000090              Stevie            Maricruz145901967120920070623202608246000000091               Tresa            Chadwick146001981043020070708202703226000000092             Spencer              Gwenda146701986102820071126202709266000000093           Lashandra                  Bo146801987081220080313202801156000000094            Margeret               Vania147001991022320080510202906116000000095             Jennell               Merry147401993051820080703202912216000000096             Classie               Drema147801994071920090419203008246000000097             Jenette              Alycia148501995031620100320203008296000000098              Kimbra               Keiko149101999032920100812203010116000000099               Anika             Coleman14980199910022010100920301107";

            return data;


        }


    }

}

