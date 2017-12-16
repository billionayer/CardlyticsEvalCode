/*

FileName: Triangle.cs
Author: John Eric Simmons
Date: 2017-12-16

Purpose: Implements the Triangle Class

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleTypeChecker.DataObjects
{
    public enum TriangleTypeEnum
    {
        NONE, //Not a triangle (because number of sides not equal to 3)
        SCALENE, //No sides are equal
        ISOSCELES, //Only two sides are equal
        EQUILATERAL //All sides equal
    }
    public enum TriangleValidationResult
    {
        Valid,
        Invalid_Too_Few_Sides,
        Invalid_Sum_of_Two_Sides_Rule
    }
    public class Triangle
    {
        #region Private Attributes
        //Use largest integer type in C# that are non-negative since no triangle has negative values
        //Since C# is strongly typed it will protect against negative numbers when calling constructor
        private List<ulong> sides;
        #endregion

        #region Construction
        public Triangle(ulong s1, ulong s2, ulong s3)
        {
            sides = new List<ulong>();
            sides.Add(s1);
            sides.Add(s2);
            sides.Add(s3);
        }
        #endregion

        #region Private Methods
        private TriangleTypeEnum GetTriangleType()
        {


            //Since we cannot be sure that someone will code this triangle object
            //in the future we should do a sanity check of the data
            if (!this.IsValidTriangle)
            {
                return TriangleTypeEnum.NONE;
            }

            //Sort sides before doing comparison
            //This will allow for a quick evaluation of the triangle by ensuring
            //that we can use a state loop.  If ther are any 
            sides.Sort();
            
            //Assume that triangle is an equilateral triangle from the start
            TriangleTypeEnum currentType = TriangleTypeEnum.EQUILATERAL;

            ulong currentside = sides[0];  //Start with first side

            for (int i=1;i<sides.Count;i++) //Start Loop on second side
            {
                if(sides[i] != currentside) //Compare side 
                {
                    switch (currentType)
                    {
                        case TriangleTypeEnum.EQUILATERAL:
                            currentType = TriangleTypeEnum.ISOSCELES;
                            break;
                        case TriangleTypeEnum.ISOSCELES:
                            currentType = TriangleTypeEnum.SCALENE;
                            break;
                    }
                    currentside = sides[i];
                }
            }
            return currentType;


        }
        private TriangleValidationResult ValidateTriangle()
        {
            //Verify that sides collection is properly formatted
            //If not then return TriangleTypeEnum.None
            if (sides == null || sides.Count != 3)
            {
                return TriangleValidationResult.Invalid_Too_Few_Sides;
            }

            //Geometric rule for Triangle is that the sum of two sides must always be 
            //greater than the thrid.
            if ((sides[0] + sides[1]) <= sides[2])
            {
                return TriangleValidationResult.Invalid_Sum_of_Two_Sides_Rule;
            }
            else if ((sides[1] + sides[2]) <= sides[0])
            {
                return TriangleValidationResult.Invalid_Sum_of_Two_Sides_Rule;
            }
            else if ((sides[0] + sides[2]) <= sides[1])
            {
                return TriangleValidationResult.Invalid_Sum_of_Two_Sides_Rule;
            }

            return TriangleValidationResult.Valid;
        }
        #endregion

        #region Public Properties
        //This should only be a read-only property because 
        //This value can only be derived by examining the sides
        public TriangleTypeEnum TriangleType
        {
            get
            {
                return GetTriangleType();
            }
        }
        //This should only be a read-only property because 
        //This value can only be derived by examining the sides
        public bool IsValidTriangle
        {
            get
            {
                if(ValidateTriangle() != TriangleValidationResult.Valid)
                {
                    return false;
                }
                return true;
            }
        }
        public ulong SideA
        {
            get
            {
                if(sides == null || sides.Count < 1)
                {
                    return 0;
                }
                return sides[0];
            }
        }
        public ulong SideB
        {
            get
            {
                if (sides == null || sides.Count < 2)
                {
                    return 0;
                }
                return sides[1];
            }
        }
        public ulong SideC
        {
            get
            {
                if (sides == null || sides.Count < 3)
                {
                    return 0;
                }
                return sides[2];
            }
        }
        public string ReasonTriangleIsInvalid
        {
            get
            {
                string ret = string.Empty;
                switch(ValidateTriangle())
                {
                    case TriangleValidationResult.Invalid_Sum_of_Two_Sides_Rule:
                        ret = "Sum of two sides does not exceed the third side.";
                        break;
                    case TriangleValidationResult.Invalid_Too_Few_Sides:
                        ret = string.Format("There are not enough sides:  Side Count {0}", (sides != null) ? sides.Count : 0);
                        break;
                }
                return ret;
            }
        }
        #endregion
    }
}
