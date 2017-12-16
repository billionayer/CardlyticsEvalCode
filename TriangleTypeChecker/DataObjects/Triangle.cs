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
        None, //Not a triangle (because number of sides not equal to 3)
        Scalene, //No sides are equal
        Isosceles, //Only two sides are equal
        Equilateral //All sides equal
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
        private bool IsTriangle()
        {
            //Verify that sides collection is properly formatted
            //If not then return TriangleTypeEnum.None
            if (sides == null || sides.Count != 3)
            {
                return false;
            }

            //Geometric rule for Triangle is that the sum of two sides must always be 
            //greater than the thrid.
            if ((sides[0] + sides[1]) > sides[2])
            {
                return true;
            }
            else if ((sides[1] + sides[2]) > sides[0])
            {
                return true;
            }
            else if ((sides[0] + sides[2]) > sides[1])
            {
                return true;
            }
            return false;

        }
        private TriangleTypeEnum GetType()
        {
           

            //Since we cannot be sure that someone will code this triangle object
            //in the future we should do a sanity check of the data
            if(!IsTriangle())
            {
                return TriangleTypeEnum.None;
            }

            //Sort sides before doing comparison
            //This will allow for a quick evaluation of the triangle by ensuring
            //that we can use a state loop.  If ther are any 
            sides.Sort();
            
            //Assume that triangle is an equilateral triangle from the start
            TriangleTypeEnum currentType = TriangleTypeEnum.Equilateral;

            ulong currentside = sides[0];  //Start with first side

            for (int i=1;i<sides.Count;i++) //Start Loop on second side
            {
                if(sides[i] != currentside) //Compare side 
                {
                    switch (currentType)
                    {
                        case TriangleTypeEnum.Equilateral:
                            currentType = TriangleTypeEnum.Isosceles;
                            break;
                        case TriangleTypeEnum.Isosceles:
                            currentType = TriangleTypeEnum.Scalene;
                            break;
                    }
                    currentside = sides[i];
                }
            }
            return currentType;


        }
        #endregion

        #region Public Properties
        //This should only be a read-only property because 
        //This value can only be derived by examining the sides
        public TriangleTypeEnum TriangleType
        {
            get
            {
                return GetType();
            }
        }
        #endregion
    }
}
