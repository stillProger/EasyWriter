using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace MyProject
{
    class NotebookSheet
    {
        public string SheetPath { get; set; }
        private Rectangle leftTextBox;
        private Rectangle rightTextBox;
        private double rotation;
        private double distanceBetweenBlockOfText;

        public NotebookSheet(string sheetPath, int height, int width,  double rotation, double distanceBetweenBlockOfText)
        {
            SheetPath = sheetPath;
            this.leftTextBox = new Rectangle(0, 0, width, height);
            this.rightTextBox = new Rectangle(0, 0, width, height);
            this.rotation = rotation;
            this.distanceBetweenBlockOfText = distanceBetweenBlockOfText;
        }
        
        //Метод на запись в файл
        public void WriteToFile(string SheetPath)
        {

            int count = 1;
            while(File.Exists(SheetPath + $"\\{count}.txt"))
                count++;

            using (FileStream file = new FileStream(SheetPath + $"\\{count}.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(file);

                writer.WriteLine($"left: {leftTextBox}\nright: {rightTextBox}\nrotation: {rotation}\ndistance: {distanceBetweenBlockOfText}");

                writer.Flush();
            }


        }
    }
}
