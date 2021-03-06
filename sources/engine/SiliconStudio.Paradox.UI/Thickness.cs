﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Diagnostics;

namespace SiliconStudio.Paradox.UI
{
    /// <summary>
    /// Describes the thickness of a frame around a cuboid. Six float values describe the Left, Top, Right, Bottom, Front, and Back sides of the cuboid, respectively.
    /// </summary>
    [DebuggerDisplay("Left:{Left}, Top:{Top}, Back:{Back}, Right:{Right}, Bottom:{Bottom}, Front:{Front}")]
    public struct Thickness
    {
        /// <summary>
        /// Initializes a new instance of the Thickness structure that has the specified uniform length on the Left, Right, Top, Bottom side and 0 for the Front and Back side.
        /// </summary>
        /// <param name="thickness">The uniform length applied to all four sides of the bounding rectangle.</param>
        /// <returns>The created thickness class</returns>
        public static Thickness UniformRectangle(float thickness)
        {
            return new Thickness(thickness, thickness, thickness, thickness);
        }

        /// <summary>
        /// Initializes a new instance of the Thickness structure that has the specified uniform length on the Left, Right, Top, Bottom, Front, and Back side.
        /// </summary>
        /// <param name="thickness">The uniform length applied to all six sides of the bounding cuboid.</param>
        /// <returns>The created thickness class</returns>
        public static Thickness UniformCuboid(float thickness)
        {
            return new Thickness(thickness, thickness, thickness, thickness, thickness, thickness);
        }
        
        /// <summary>
        /// Initializes a new instance of the Thickness structure that has specific lengths applied to each side of the rectangle.
        /// </summary>
        /// <param name="bottom">The thickness for the lower side of the rectangle.</param>
        /// <param name="left">The thickness for the left side of the rectangle.</param>
        /// <param name="right">The thickness for the right side of the rectangle</param>
        /// <param name="top">The thickness for the upper side of the rectangle.</param>
        public Thickness(float left, float top, float right, float bottom)
        {
            Bottom = bottom;
            Left = left;
            Right = right;
            Top = top;
            Front = 0;
            Back = 0;
        }

        /// <summary>
        /// Reverses the direction of a given Thickness.
        /// </summary>
        /// <param name="value">The Thickness to negate.</param>
        /// <returns>A Thickness with the opposite direction.</returns>
        public static Thickness operator -(Thickness value)
        {
            return new Thickness(-value.Left, -value.Top, -value.Back, -value.Right, -value.Bottom, -value.Front);
        }

        /// <summary>
        /// Addition two Thickness together.
        /// </summary>
        /// <param name="value1">The first thickness to add.</param>
        /// <param name="value2">The second thickness to add.</param>
        /// <returns>A Thickness with the opposite direction.</returns>
        public static Thickness operator +(Thickness value1, Thickness value2)
        {
            return new Thickness(value1.Left + value2.Left, value1.Top + value2.Top, value1.Back + value2.Back, value1.Right + value2.Right, value1.Bottom + value2.Bottom, value1.Front + value2.Front);
        }

        /// <summary>
        /// Divide a Thickness by a float.
        /// </summary>
        /// <param name="value1">The first thickness to add.</param>
        /// <param name="value2">The float value to divide by.</param>
        /// <returns>The divided thickness</returns>
        public static Thickness operator /(Thickness value1, float value2)
        {
            return new Thickness(value1.Left / value2, value1.Top / value2, value1.Back / value2, value1.Right / value2, value1.Bottom / value2, value1.Front / value2);
        }    
        
        /// <summary>
        /// Initializes a new instance of the Thickness structure that has specific lengths applied to each side of the cuboid.
        /// </summary>
        /// <param name="bottom">The thickness for the lower side of the rectangle.</param>
        /// <param name="left">The thickness for the left side of the rectangle.</param>
        /// <param name="right">The thickness for the right side of the rectangle</param>
        /// <param name="top">The thickness for the upper side of the rectangle.</param>
        /// <param name="front">The thickness for the front side of the rectangle.</param>
        /// <param name="back">The thickness for the Back side of the rectangle.</param>
        public Thickness(float left, float top, float back, float right, float bottom, float front)
        {
            Bottom = bottom;
            Left = left;
            Right = right;
            Top = top;
            Front = front;
            Back = back;
        }

        /// <summary>
        ///  The bottom side of the bounding rectangle.
        /// </summary>
        public float Bottom;

        /// <summary>
        ///  The left side of the bounding rectangle.
        /// </summary>
        public float Left;

        /// <summary>
        ///  The right side of the bounding rectangle.
        /// </summary>
        public float Right;

        /// <summary>
        ///  The upper side of the bounding rectangle.
        /// </summary>
        public float Top;

        /// <summary>
        ///  The front side of the bounding rectangle.
        /// </summary>
        public float Front;

        /// <summary>
        ///  The Back side of the bounding rectangle.
        /// </summary>
        public float Back;

        /// <summary>
        /// Gets the component at the specified index.
        /// </summary>
        /// <param name="index">The index of the component to access. Use 0 for the Left component, 1 for the Top component, 
        /// 2 for the Front component, 3 for the Right component, 4 for the Bottom component, 5 for the Back component.</param>
        /// <returns>The value of the component at the specified index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 5].</exception>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Left;
                    case 1: return Top;
                    case 2: return Front;
                    case 3: return Right;
                    case 4: return Bottom;
                    case 5: return Back;
                }

                throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
            }
        }
    }
}