#region Math.NET Neodym (GPL) by Christoph Ruegg
// Math.NET Neodym, part of the Math.NET Project
// http://mathnet.opensourcedotnet.info
//
// Copyright (c) 2001-2008, Christoph R�egg,  http://christoph.ruegg.name
//						
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using MathNet.SignalProcessing.Filter.Utils;

namespace MathNet.SignalProcessing.Filter.Median
{
    public class OnlineMedianFilter : OnlineFilter
    {
        private OrderedShiftBuffer _buffer;

        public OnlineMedianFilter(int windowSize)
        {
            _buffer = new OrderedShiftBuffer(windowSize);
        }

        public override double ProcessSample(double sample)
        {
            _buffer.Append(sample);
            try
            {
                return _buffer.Median;
            }
            catch(NullReferenceException)
            {
                return double.NaN;
            }
        }

        public override void Reset()
        {
            _buffer.Clear();
        }
    }
}
