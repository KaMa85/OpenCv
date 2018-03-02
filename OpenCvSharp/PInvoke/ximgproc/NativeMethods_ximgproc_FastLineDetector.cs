﻿using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvHololens
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern)]
        public static extern void ximgproc_FastLineDetector_delete(IntPtr obj);

        [DllImport(DllExtern)]
        public static extern IntPtr ximgproc_Ptr_FastLineDetector_get(IntPtr ptr);


        [DllImport(DllExtern)]
        public static extern void ximgproc_FastLineDetector_detect_OutputArray(IntPtr obj, IntPtr image, IntPtr lines);

        [DllImport(DllExtern)]
        public static extern void ximgproc_FastLineDetector_detect_vector(IntPtr obj, IntPtr image, IntPtr lines);

        [DllImport(DllExtern)]
        public static extern void ximgproc_FastLineDetector_drawSegments_InputArray(IntPtr obj, IntPtr image, IntPtr lines, int draw_arrow);

        [DllImport(DllExtern)]
        public static extern void ximgproc_FastLineDetector_drawSegments_vector(IntPtr obj, IntPtr image, IntPtr lines, int draw_arrow);

        [DllImport(DllExtern)]
        public static extern IntPtr ximgproc_createFastLineDetector(
            int length_threshold, float distance_threshold, double canny_th1, double canny_th2, int canny_aperture_size,
            int do_merge);
    }
}