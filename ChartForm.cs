using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;   // the brushes and pens we need 
using System.Text;
using System.Windows.Forms;
using WinFormsApp1ProjectWAPTeachersCalendar;

namespace ProjectWAPTeachersCalendar
{
    public partial class ChartForm : Form
    {
        // Dictionary to hold our counted data (Teacher Name -> Number of classes)
        private Dictionary<string, int> teacherClassCounts = new Dictionary<string, int>();

        // Ctor that accepts the master schedule list from form1
        public ChartForm(List<Subject> scheduleList)
        { 
            InitializeComponent();
            CalculateStatistics(scheduleList);
        }

        private void CalculateStatistics(List<Subject> scheduleList)
        {
            // count how many classes each teacher has 
            foreach(Subject s in scheduleList)
            {
                if(teacherClassCounts.ContainsKey(s.TeacherName))
                {
                    teacherClassCounts[s.TeacherName]++;    // add 1 to their count
                }
                else
                {
                    teacherClassCounts.Add(s.TeacherName, 1);   // in case it's first time seeing this teacher
                }
            }
        }


        private void chartPanel_Paint(object sender, PaintEventArgs e)
        {
            // if there is no data don't draw anything
            if (teacherClassCounts.Count == 0)
            {
                return;
            }

            // grab the digital paintbrush and make it draw smoothly
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // setup the drawing tools for the lollipop chart 
            Pen stickPen = new Pen(Color.DarkGray, 3);  // The "stick" of the lollipop
            Brush candyBrush = new SolidBrush(Color.MediumPurple);
            Brush textBrush = new SolidBrush(Color.Black);
            Font textFont = new Font("Segoe UI", 10, FontStyle.Bold);

            // setup for the math for the horizontal layout
            int panelWidth = chartPanel.Width;
            int currentY = 40;  // Start near the top
            int spacing = 50;   // Space between each teacher's row
            int leftMargin = 100;   // Leave room on the left to write their names

            // find the highest nr of classes to scale the lines properly
            int maxClasses = 0;
            foreach (int count in teacherClassCounts.Values)
            {
                if(count > maxClasses)
                    maxClasses = count;
            }

            if(maxClasses == 0)
            {
                maxClasses = 1; // Safety check to prevent dividing by zero
            }

            // Draw the lollipops!
            foreach(var item in teacherClassCounts)
            {
                string shortName = item.Key.Split(' ')[0]; // Just the first name
                int classCount = item.Value;

                // Calculate how long the line should be based on panel width
                int lineLength = (int)(((double)classCount / maxClasses) * (panelWidth - leftMargin - 60));

                // draw the teacher's name on the far left
                g.DrawString(shortName, textFont, textBrush, 10, currentY - 10);

                // draw the "stick" (horizontal line)
                g.DrawLine(stickPen, leftMargin, currentY, leftMargin + lineLength, currentY);

                // draw the "candy" (the circle at the end of the stick)
                int circleSize = 28;
                int circleX = leftMargin + lineLength - (circleSize / 2);
                int circleY = currentY - (circleSize / 2);
                g.FillEllipse(candyBrush, circleX, circleY, circleSize, circleSize);

                // draw he number right inside the purple circle
                g.DrawString(classCount.ToString(), textFont, Brushes.White, circleX + 8, circleY + 4);

                // move down for the next teacher
                currentY += spacing;
            }

            // clean up tools to save memory
            stickPen.Dispose();
            candyBrush.Dispose();
            textBrush.Dispose();
            textFont.Dispose();
        }
    }
}
