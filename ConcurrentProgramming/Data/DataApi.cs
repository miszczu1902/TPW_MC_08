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
        private object _lock = new object();

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
            lock (_lock)
            {
                foreach (Ball ball in BallsList)
                {
                    using (StreamWriter writer = new StreamWriter(@"D:\politechnika\IV sem\TPW_MC_08\ConcurrentProgramming\Data\xd", true))
                    {
                        writer.WriteLine(SaveBallData(ball));
                    }
                    // Trace.WriteLine(Path.GetFullPath("Data"));
                    // File.WriteAllText(Path.GetFullPath("Data") + @"xd", SaveBallData(ball));
                    // string xd = SaveBallData(ball);
                    // Trace.WriteLine(SaveBallData(ball));
                }   
            }
        }
    }
}