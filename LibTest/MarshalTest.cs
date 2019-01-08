using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;


namespace LibTest
{
    public class MarshalTest
    {
        public static object Native_SongItem { get; private set; }

        [Fact]
        public unsafe static void FixMarshalArrayLengthTest()
        {
            MarshalAsAttribute ma = typeof(B).GetField("c").GetCustomAttributes(typeof(MarshalAsAttribute), false)[0] as MarshalAsAttribute;
            int length = ma.SizeConst;
            Assert.True(length > 1);


            A[] a1 = new[] { new A { c = 1 } };
            A[] a2 = new A[length + 100];
            a2[0] = a1[0];

            var st1 = new B();
            st1.c = a1;
            int len1 = Marshal.SizeOf(st1);
            var st2 = new B();
            st2.c = a2;

            Array.Resize(ref st1.c, length);
            Array.Resize(ref st2.c, length);


            IntPtr b = Marshal.AllocHGlobal(len1);
            Marshal.StructureToPtr(st1, b, false);
            Byte[] data1 = new byte[len1];
            Marshal.Copy(b, data1, 0, len1);

            int len2 = Marshal.SizeOf(st1);
            IntPtr b2 = Marshal.AllocHGlobal(len2);
            Marshal.StructureToPtr(st2, b2, false);
            Byte[] data2 = new byte[len2];
            Marshal.Copy(b2, data2, 0, len2);

            var string1 = BitConverter.ToString(data1);
            var string2 = BitConverter.ToString(data2);

            Assert.Equal(string1, string2);
        }

       


        [StructLayout(LayoutKind.Sequential, Size = 4)]
        struct A
        {
            public int c;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe struct B
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public A[] c;
        }

    }
}
