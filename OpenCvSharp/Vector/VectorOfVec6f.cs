﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvHololens.Util;

namespace OpenCvHololens
{
    /// <summary>
    /// 
    /// </summary>
    internal class VectorOfVec6f : DisposableCvObject, IStdVector<Vec6f>
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorOfVec6f()
        {
            ptr = NativeMethods.vector_Vec6f_new1();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfVec6f(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            ptr = NativeMethods.vector_Vec6f_new2(new IntPtr(size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public VectorOfVec6f(IEnumerable<Vec6f> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            Vec6f[] array = EnumerableEx.ToArray(data);
            ptr = NativeMethods.vector_Vec6f_new3(array, new IntPtr(array.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public VectorOfVec6f(IntPtr p)
        {
            ptr = p;
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.vector_Vec6f_delete(ptr);
            base.DisposeUnmanaged();
        }
        
        /// <summary>
        /// vector.size()
        /// </summary>
        public int Size
        {
            get
            {
                var res = NativeMethods.vector_Vec6f_getSize(ptr).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        public IntPtr ElemPtr
        {
            get
            {
                var res = NativeMethods.vector_Vec6f_getPointer(ptr);
                GC.KeepAlive(this);
                return res;
            }
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <returns></returns>
        public Vec6f[] ToArray()
        {
            return ToArray<Vec6f>();
        }

        /// <summary>
        /// Converts std::vector to managed array
        /// </summary>
        /// <typeparam name="T">structure that has four int members (ex. CvLineSegmentPoint, CvRect)</typeparam>
        /// <returns></returns>
        public T[] ToArray<T>() where T : struct
        {
            int typeSize = MarshalHelper.SizeOf<T>();
            if (typeSize != sizeof (float)*6)
            {
                throw new OpenCvHololensException();
            }

            int arySize = Size;
            if (arySize == 0)
            {
                return new T[0];
            }
            var dst = new T[arySize];
            using (var dstPtr = new ArrayAddress1<T>(dst))
            {
                MemoryHelper.CopyMemory(dstPtr, ElemPtr, typeSize*dst.Length);
            }
            GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
                                // make sure we are not disposed until finished with copy.
            return dst;
        }
    }
}
