using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WebPatter.WebUI.Models
{
    public class CreateSkirt
    {
        public static int Cm2Pixel(double WidthInCm)
        {
            double HeightInCm = WidthInCm;
            return Cm2Pixel(WidthInCm, HeightInCm).Width;
        }

        public static System.Drawing.Size Cm2Pixel(double WidthInCm, double HeightInCm)
        {
            float sngWidth = (float)WidthInCm; //cm
            float sngHeight = (float)HeightInCm; //cm
            using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1))
            {
                sngWidth *= 0.393700787f * 96; // x-Axis pixel
                sngHeight *= 0.393700787f * 96; // y-Axis pixel
            }

            return new System.Drawing.Size((int)sngWidth, (int)sngHeight);
        }

        public static Bitmap CreateFullSun(double waist, double length)
        {
            double radius1 = 0.32 * (waist / 2 + 1.5);
            double radius2 = Cm2Pixel(radius1 + length);
            radius1 = Cm2Pixel(radius1);

            int r1 = Convert.ToInt32(Math.Round(radius1));
            int r2 = Convert.ToInt32(Math.Round(radius2));
            int imageHeight = r2 + 10;
            int imageWidth = imageHeight * 2;

            Bitmap image = new Bitmap(imageWidth, imageHeight);

            using (Graphics graphic = Graphics.FromImage(image))
            {
                graphic.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight);


                GraphicsPath path = new GraphicsPath();

                Rectangle rectSmall = new Rectangle(imageWidth / 2 - r1, 1 - r1, r1 * 2, r1 * 2 + 1);
                Rectangle rectBig = new Rectangle(imageWidth / 2 - r2, 1 - r2, r2 * 2, r2 * 2 + 1);
                path.AddArc(rectSmall, 0, 180);
                path.AddArc(rectBig, 0, 180);
                path.AddLine(imageWidth / 2 - r1, 1, imageWidth / 2 - r2, 1);

                graphic.DrawPath(Pens.Black, path);

                GraphicsPath path2 = new GraphicsPath();
                path2.AddLine(imageWidth / 2 - r1, 1, imageWidth / 2 + r1, 1);
                graphic.DrawPath(Pens.White, path2);
            }
            return image;
        }
        public static Bitmap CreateHalfSun(double waist, double length)
        {
            double radius1 = waist / 3.14;
            double radius2 = Cm2Pixel(radius1 + length);
            radius1 = Cm2Pixel(radius1);

            int r1 = Convert.ToInt32(Math.Round(radius1));
            int r2 = Convert.ToInt32(Math.Round(radius2));
            int imageHeight = r2 + 10;
            int imageWidth = imageHeight * 2;

            Bitmap image = new Bitmap(imageWidth, imageHeight);

            using (Graphics graphic = Graphics.FromImage(image))
            {
                graphic.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight);


                GraphicsPath path = new GraphicsPath();

                Rectangle rectSmall = new Rectangle(imageWidth / 2 - r1, 1 - r1, r1 * 2, r1 * 2 + 1);
                Rectangle rectBig = new Rectangle(imageWidth / 2 - r2, 1 - r2, r2 * 2, r2 * 2 + 1);
                path.AddArc(rectSmall, 0, 180);
                path.AddArc(rectBig, 0, 180);
                path.AddLine(imageWidth / 2 - r1, 1, imageWidth / 2 - r2, 1);

                graphic.DrawPath(Pens.Black, path);

                GraphicsPath path2 = new GraphicsPath();
                path2.AddLine(imageWidth / 2 - r1, 1, imageWidth / 2 + r1, 1);
                graphic.DrawPath(Pens.White, path2);
            }
            return image;
        }

        public static Bitmap CreatePencil(double waist, double length, double hips)
        {
            double vytochki = (hips / 2 + 1) - (waist / 2 + 1);
            double vytSide = vytochki / 2;
            double vytFront = 3;
            double vytBack = vytochki - vytSide - vytFront;
            vytSide = Cm2Pixel(vytSide / 2);
            vytFront = Cm2Pixel(vytFront / 2);
            vytBack = Cm2Pixel(vytBack / 2);

            double width = hips / 2 + 1;
            width = Cm2Pixel(width);
            double height = length;
            height = Cm2Pixel(height);

            int ab = Convert.ToInt32(Math.Round(width));
            int ad = Convert.ToInt32(Math.Round(height));
            int vytSideConv = Convert.ToInt32(Math.Round(vytSide));
            int vytFrontConv = Convert.ToInt32(Math.Round(vytFront));
            int vytBackConv = Convert.ToInt32(Math.Round(vytBack));
            int imageWidth = ab + 10;
            int imageHeight = ad + Cm2Pixel(10);


            Bitmap image = new Bitmap(imageWidth, imageHeight);

            using (Graphics graphic = Graphics.FromImage(image))
            {
                graphic.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight);


                Point start = new Point(5, Cm2Pixel(5));

                Point tAb = new Point(ab / 2 + start.X, start.Y);                     // Начало линии талии(Т)
                Point lLineT = new Point(tAb.X, tAb.Y + Cm2Pixel(22));                // Пересечение линии талии и линии бёдер (Л1)
                Point tDc = new Point(ab / 2 + start.X, ad + start.Y);                // Конец линии талии(Т1)

                Point tVytA = new Point(tAb.X - vytSideConv, tAb.Y - Cm2Pixel(1));   // Средняя выточка, точка слева
                Point tVytB = new Point(tAb.X + vytSideConv, tAb.Y - Cm2Pixel(1));   // Средняя выточка, точка справа
                Point tVytACurve = new Point(tAb.X - vytSideConv / 2 + Cm2Pixel(0.5), tAb.Y + Cm2Pixel(11)); // Средняя выточка, точка сужения слева
                Point tVytBCurve = new Point(tAb.X + vytSideConv / 2 - Cm2Pixel(0.5), tAb.Y + Cm2Pixel(11)); // Средняя выточка, точка сужения справа

                Point[] pointsLeft = new Point[] { tVytA, tVytACurve, lLineT };        // Массив точек для кривой левой линии средней выточки
                Point[] pointsRight = new Point[] { tVytB, tVytBCurve, lLineT };       // Массив точек для кривой правой линии средней выточки

                Point vytBackA = new Point(ab / 4 + start.X - vytBackConv, start.Y);                     // Задняя выточка, точка слева
                Point vytBackB = new Point(ab / 4 + start.X + vytBackConv, start.Y);                     // Задняя выточка, точка справа
                Point vytBackEnd = new Point(ab / 4 + start.X, start.Y + Cm2Pixel(12));                      // Задняя выточка, точка низа

                Point vytFrontCenter = new Point(tVytB.X + Cm2Pixel(5), start.Y);      // Передняя выточка, центр
                Point vytFrontEnd = new Point(vytFrontCenter.X - Cm2Pixel(0.5), vytFrontCenter.Y + Cm2Pixel(9));  // Передняя выточка, низ
                Point vytFrontA = new Point(vytFrontCenter.X - vytFrontConv, vytFrontCenter.Y);          // Передняя выточка, точка слева
                Point vytFrontB = new Point(vytFrontCenter.X + vytFrontConv, vytFrontCenter.Y);          // Передняя выточка, точка справа

                graphic.DrawRectangle(Pens.Black, start.X, start.Y, ab, ad);
                graphic.DrawLine(Pens.Black, lLineT, tDc);
                graphic.DrawLine(Pens.Black, vytBackA, vytBackEnd);
                graphic.DrawLine(Pens.Black, vytBackB, vytBackEnd);
                graphic.DrawLine(Pens.Black, vytBackB, tVytA);
                graphic.DrawLine(Pens.Black, vytFrontA, tVytB);
                graphic.DrawLine(Pens.Black, vytFrontA, vytFrontEnd);
                graphic.DrawLine(Pens.Black, vytFrontB, vytFrontEnd);
                graphic.DrawLine(Pens.White, vytBackA, vytFrontB);

                graphic.DrawCurve(Pens.Black, pointsLeft);
                graphic.DrawCurve(Pens.Black, pointsRight);
            }
            return image;
        }
        public static Bitmap CreateSimple(double length, double hips)
        {
            double width = hips;
            width = Cm2Pixel(width);
            double height = length;
            height = Cm2Pixel(height);

            int imageWidth = Convert.ToInt32(Math.Round(width)) + 10;
            int imageHeight = Convert.ToInt32(Math.Round(height)) + 10;
            int patWidth = Convert.ToInt32(Math.Round(width));
            int patHeight = Convert.ToInt32(Math.Round(height));


            Bitmap image = new Bitmap(imageWidth, imageHeight);

            using (Graphics graphic = Graphics.FromImage(image))
            {
                graphic.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight);


                Point start = new Point(5, 5);
                Point center = new Point(patWidth / 2 + start.X, start.Y);         // Начало центральной линии
                Point centerEnd = new Point(center.X, start.Y + patHeight);        // Конец центральной линии
                Point waistLineA = new Point(start.X, start.Y + Cm2Pixel(5));      // Линия талии начало
                Point waistLineB = new Point(start.X + patWidth, waistLineA.Y);    // Линия талии конец
                Point zipLineA = new Point(start.X, start.Y + Cm2Pixel(15));       // Линия молнии начало
                Point zipLineB = new Point(start.X + Cm2Pixel(2), zipLineA.Y);     // Линия молнии конец
                Point foldLineA = new Point(patWidth / 4 + start.X, start.Y);      // Линия первого сгиба начало
                Point foldLineB = new Point(foldLineA.X, start.Y + patHeight);     // Линия первого сгиба конец
                Point foldLastLineA = new Point(patWidth / 4 + center.X, start.Y);      // Линия последнего сгиба начало
                Point foldLastLineB = new Point(foldLastLineA.X, start.Y + patHeight);  // Линия последнего сгиба конец
                Point foldSecLineA = new Point(patWidth / 6 + foldLineA.X, start.Y);    // Линия второго сгиба начало
                Point foldSecLineB = new Point(foldSecLineA.X, start.Y + patHeight);    // Линия второго сгиба конец
                Point foldThirdLineA = new Point(patWidth / 6 + foldSecLineA.X, start.Y);     // Линия третьего сгиба начало
                Point foldThirdLineB = new Point(foldThirdLineA.X, start.Y + patHeight);    // Линия третьего сгиба конец
                Point foldLineFoldA = new Point(patWidth / 12 + foldLineA.X, start.Y);      // Линия сложения первого сгиба начало
                Point foldLineFoldB = new Point(foldLineFoldA.X, waistLineA.Y);      // Линия сложения первого сгиба конец
                Point foldThirdLineFoldA = new Point(patWidth / 12 + foldThirdLineA.X, start.Y);      // Линия сложения последнего сгиба начало
                Point foldThirdLineFoldB = new Point(foldThirdLineFoldA.X, waistLineA.Y);      // Линия сложения последнего сгиба конец
                Point foldSecLineFoldA = new Point(patWidth / 24 + foldSecLineA.X, start.Y);      // Линия сложения второго сгиба начало
                Point foldSecLineFoldB = new Point(foldSecLineFoldA.X, waistLineA.Y);      // Линия сложения второго сгиба конец
                Point foldBetweenLineFoldA = new Point(patWidth / 24 + center.X, start.Y);      // Линия сложения третьего сгиба начало
                Point foldBetweenLineFoldB = new Point(foldBetweenLineFoldA.X, waistLineA.Y);      // Линия сложения третьего сгиба конец

                graphic.DrawRectangle(Pens.Black, start.X, start.Y, patWidth, patHeight);
                graphic.DrawLine(Pens.Black, center, centerEnd);
                graphic.DrawLine(Pens.Red, waistLineA, waistLineB);
                graphic.DrawLine(Pens.Red, zipLineA, zipLineB);
                graphic.DrawLine(Pens.Black, foldLineA, foldLineB);
                graphic.DrawLine(Pens.Black, foldLastLineA, foldLastLineB);
                graphic.DrawLine(Pens.Black, foldSecLineA, foldSecLineB);
                graphic.DrawLine(Pens.Black, foldThirdLineA, foldThirdLineB);
                graphic.DrawLine(Pens.Red, foldLineFoldA, foldLineFoldB);
                graphic.DrawLine(Pens.Red, foldThirdLineFoldA, foldThirdLineFoldB);
                graphic.DrawLine(Pens.Red, foldSecLineFoldA, foldSecLineFoldB);
                graphic.DrawLine(Pens.Red, foldBetweenLineFoldA, foldBetweenLineFoldB);
            }
            return image;
        }
        ~CreateSkirt() { }
    }
}
