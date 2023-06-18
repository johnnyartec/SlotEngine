using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using Formatting = Newtonsoft.Json.Formatting;

namespace SlotEngine.GameModule.GameSetting
{
    public class WritePayTable
    {
        public void WriteFile()
        {
            PayTable payTable = PreparePayTable();

            // 將 Paytable 物件轉換成 JSON 格式的字串
            var json = JsonConvert.SerializeObject(payTable, Formatting.Indented);

            // 將 JSON 字串寫入到檔案中
            var path = @"config\paytable.json";
            File.WriteAllText(path, json);

            Console.WriteLine($"Paytable has been saved to {path}");
        }

        private static PayTable PreparePayTable()
        {
            PayTable payTable = new PayTable();

            var symbolNo = "A"; //皇冠
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      20,     20,     50, 
                50,     100,    100,    100,    100,
                100,    100,    100,    100,    100,
                100,    100,    100,    100,    100,
                100,    100,    100,    100,    100
                }
            });
            symbolNo = "B"; //沙漏
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      5,     5,     20, 
                20,     50,    50,    50,    50,
                50,    50,    50,    50,    50,
                50,    50,    50,    50,    50,
                50,    50,    50,    50,    50
                }
            });
            symbolNo = "C";     //戒指
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      4,     4,     10, 
                10,     30,    30,    30,    30,
                30,    30,    30,    30,    30,
                30,    30,    30,    30,    30,
                30,    30,    30,    30,    30
                }
            });

            symbolNo = "D";     //酒盃
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      3,     3,     4, 
                4,     24,    24,    24,    24,
                24,    24,    24,    24,    24,
                24,    24,    24,    24,    24,
                24,    24,    24,    24,    24
                }
            });

            symbolNo = "E";     //紅寶石
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      2,     2,     3, 
                3,     20,    20,    20,    20,
                20,    20,    20,    20,    20,
                20,    20,    20,    20,    20,
                20,    20,    20,    20,    20
                }
            });

            symbolNo = "F";     //紫寶石
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      1.6M,     1.6M,     2.4M, 
                2.4M,     16,    16,    16,    16,
                16,    16,    16,    16,    16,
                16,    16,    16,    16,    16,
                16,    16,    16,    16,    16
                }
            });

            symbolNo = "G";     //黃寶石
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      1,     1,     2, 
                2,     10,    10,    10,    10,
                10,    10,    10,    10,    10,
                10,    10,    10,    10,    10,
                10,    10,    10,    10,    10
                }
            });

            symbolNo = "H";     //綠寶石
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      0.8M,     0.8M,     1.8M, 
                1.8M,     8,    8,    8,    8,
                8,    8,    8,    8,    8,
                8,    8,    8,    8,    8,
                8,    8,    8,    8,    8
                }
            });


            symbolNo = "I";     //藍寶石
            payTable.Items.Add(symbolNo, new PayTableItem()
            {
                Description = symbolNo,
                SymbolType = "S",
                PayOut = new List<Decimal> { 0, 0, 0, 0, 0, 
                0,      0,      0.5M,     0.5M,     1.5M, 
                1.5M,     4,    4,    4,    4,
                4,    4,    4,    4,    4,
                4,    4,    4,    4,    4,
                4,    4,    4,    4,    4,
                }
            });
            return payTable;
        }
    }
}
