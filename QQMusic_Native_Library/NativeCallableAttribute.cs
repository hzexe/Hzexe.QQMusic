//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("C_Style_LibraryTest")]

namespace System.Runtime.InteropServices
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NativeCallableAttribute : Attribute
    {
        public string EntryPoint;
        public CallingConvention CallingConvention;
        public NativeCallableAttribute() { }
    }
}