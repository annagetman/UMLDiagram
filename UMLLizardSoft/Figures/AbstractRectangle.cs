﻿using System.Collections.Generic;
using System.Drawing;

namespace UMLLizardSoft.Figures
{
    public class AbstractRectangle : AbstractFigure,IMovable
    {
        public override void Draw(Graphics graphics, Pen pen)
        {
        }

        public override void Move(int deltaX, int deltaY,Point point)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);
            EndPoint = new Point(EndPoint.X + deltaX, EndPoint.Y + deltaY);
        }

        public override bool IsSelected(Point point)
        {
            if (point.X >= StartPoint.X && point.X <= EndPoint.X
             && point.Y >= StartPoint.Y && point.Y <= EndPoint.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveElementText(string strText)
        {
            if (select == EnumSectionRectangle.FirstSection)
            {
                _listForRect1Text.Add(strText);
            }
            //else if (select == EnumSectionRectangle.SecondSection)
            //{
            //    _listForRect2Text.Add(strText);
            //}
            //else if (select == EnumSectionRectangle.ThirdSection)
            //{
            //    _listForRect3Text.Add(strText);
            //}
        }

        public override bool CheckIfTheObjectIsClicked(Point point)
        {
            if (point.X >= StartPoint.X && point.X <= EndPoint.X
             && point.Y >= StartPoint.Y + 30 && point.Y <= EndPoint.Y + 30)
            {
                return true;
            }
            //if (point.X >= StartPoint.X && point.X <= EndPoint.X
            // && point.Y >= StartPoint.Y + 60 && point.Y <= EndPoint.Y + 60)
            //{
            //    return true;
            //}
            //if (point.X >= StartPoint.X && point.X <= EndPoint.X
            // && point.Y >= StartPoint.Y + 90 && point.Y <= EndPoint.Y + 90)
            //{
            //    return true;
            //}
            else
            {
                return false;
            }
        }
    }
}