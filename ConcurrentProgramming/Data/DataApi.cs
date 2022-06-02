using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Logic;
using System.Text.Json;

namespace Data
{
    public class DataApi : DataAbstarctApi
    {
        public static int WIDTH = 720;
        public static int HEIGHT = 360;
        private static string path = Path.GetFullPath("dir")+"..\\..\\..\\..\\..\\..\\..\\Data\\BallDiagnostic";
        public override ObservableCollection<Ball> _balls()
        {
            return new ObservableCollection<Ball>();
        }
        
        public override string SaveBallData(Ball ball)
        {
            var opt = new JsonSerializerOptions() {WriteIndented = true};
            return JsonSerializer.Serialize<Ball>(ball, opt);
        }

        public override void SaveDataToFile()
        {
   
                foreach (Ball ball in BallsList)
                {
                    
                    using (StreamWriter writer = new StreamWriter(path,true))
                    {
                        writer.WriteLine(SaveBallData(ball));
                    }
                }
        }

        public override void ClearFile()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("");
            }
        }
    }
}