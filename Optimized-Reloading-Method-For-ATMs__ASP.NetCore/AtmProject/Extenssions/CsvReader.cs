using AtmProject.Data;
using AtmProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Extenssions
{
    public static class CsvReader
    {
        private static DataBase db = new DataBase();

        public static async void AddToAtmDataBase(string filePath)
        {

            var listTemp = await File.ReadAllLinesAsync(filePath);
            var list = listTemp.ToList();

            for (int i = 1; i < list.Count; i++)
            {
                var info = list[i].Split(',');
                Atm a = new Atm() { TID = info[0] ,Name = info[1], City = info[2] };
                db.Atms.Add(a);
            }
            await db.SaveChangesAsync();
        }

        public static async void AddToHistoricDataBase(string filePath, string atmId)//TODO: fix
        {
            var listTemp = await File.ReadAllLinesAsync(filePath);
            var list = listTemp.ToList();
            var toAdd = await db.Atms.FirstOrDefaultAsync(x => x.TID == atmId);

            var listToAdd = new List<HistoricData>();
            for (int i = 1; i < list.Count; i++)
            {
                var info = list[i].Split(',');
                HistoricData hd = new HistoricData() {
                    TID = info[0],
                    EventDate = Convert.ToDateTime(info[1], System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat),
                    PreviousPeriodID = int.Parse(info[2]),
                    PreviousLoad =Convert.ToDateTime(info[3], System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat),
                    PreviousDeposit = int.Parse(info[4]),
                    PreviousWithdraw = int.Parse(info[5]),
                    PreviousTransactionCount = int.Parse(info[6])
                };
                listToAdd.Add(hd);
            }
            toAdd.HD.AddRange(listToAdd);
            await db.SaveChangesAsync();
        }
    }
}
