using System;
using System.Runtime.InteropServices;

namespace OpenCvHololens.Tracking
{
    /// <inheritdoc />
    /// <summary>
    /// TLD is a novel tracking framework that explicitly decomposes the long-term tracking task into tracking, learning and detection.
    /// 
    /// The tracker follows the object from frame to frame.The detector localizes all appearances that 
    /// have been observed so far and corrects the tracker if necessary.The learning estimates detector�fs 
    /// errors and updates it to avoid these errors in the future.The implementation is based on @cite TLD .
    /// 
    /// The Median Flow algorithm (see cv::TrackerMedianFlow) was chosen as a tracking component in this 
    /// implementation, following authors. Tracker is supposed to be able to handle rapid motions, partial occlusions, object absence etc.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class TrackerTLD : Tracker
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        /// <summary>
        /// 
        /// </summary>
        protected TrackerTLD(IntPtr p)
        {
            ptrObj = new Ptr(p);
            ptr = ptrObj.Get();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public static TrackerTLD Create()
        {
            IntPtr p = NativeMethods.tracking_TrackerTLD_create1();
            return new TrackerTLD(p);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">TLD parameters</param>
        /// <returns></returns>
        public static TrackerTLD Create(Params parameters)
        {
            unsafe
            {
                IntPtr p = NativeMethods.tracking_TrackerTLD_create2(&parameters);
                return new TrackerTLD(p);
            }
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        internal class Ptr : OpenCvHololens.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.tracking_Ptr_TrackerTLD_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.tracking_Ptr_TrackerTLD_delete(ptr);
                base.DisposeUnmanaged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Params
        {
        }
    }
}