using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiViewport
    {
        public uint ID;
        public ImGuiViewportFlags Flags;
        public Vector2 Pos;
        public Vector2 Size;
        public Vector2 WorkOffsetMin;
        public Vector2 WorkOffsetMax;
        public float DpiScale;
        public ImDrawData* DrawData;
        public uint ParentViewportId;
        public void* RendererUserData;
        public void* PlatformUserData;
        public void* PlatformHandle;
        public void* PlatformHandleRaw;
        public byte PlatformRequestMove;
        public byte PlatformRequestResize;
        public byte PlatformRequestClose;
    }
    public unsafe partial struct ImGuiViewportPtr
    {
        public ImGuiViewport* NativePtr { get; }
        public ImGuiViewportPtr(ImGuiViewport* nativePtr) => NativePtr = nativePtr;
        public ImGuiViewportPtr(IntPtr nativePtr) => NativePtr = (ImGuiViewport*)nativePtr;
        public static implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr) => new ImGuiViewportPtr(nativePtr);
        public static implicit operator ImGuiViewport* (ImGuiViewportPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiViewportPtr(IntPtr nativePtr) => new ImGuiViewportPtr(nativePtr);
        public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
        public ref ImGuiViewportFlags Flags => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->Flags);
        public ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);
        public ref Vector2 Size => ref Unsafe.AsRef<Vector2>(&NativePtr->Size);
        public ref Vector2 WorkOffsetMin => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkOffsetMin);
        public ref Vector2 WorkOffsetMax => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkOffsetMax);
        public ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);
        public ImDrawDataPtr DrawData => new ImDrawDataPtr(NativePtr->DrawData);
        public ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);
        public IntPtr RendererUserData { get => (IntPtr)NativePtr->RendererUserData; set => NativePtr->RendererUserData = (void*)value; }
        public IntPtr PlatformUserData { get => (IntPtr)NativePtr->PlatformUserData; set => NativePtr->PlatformUserData = (void*)value; }
        public IntPtr PlatformHandle
        {
            get => (IntPtr)NativePtr->PlatformHandle;
            set
            {
                //lock (NativePtr->PlatformHandle) { NativePtr->PlatformHandle = (void*)value; }
                NativePtr->PlatformHandle = (void*)value; 
            }
        }
        public IntPtr PlatformHandleRaw { get => (IntPtr)NativePtr->PlatformHandleRaw; set => NativePtr->PlatformHandleRaw = (void*)value; }
        public ref bool PlatformRequestMove => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestMove);
        public ref bool PlatformRequestResize => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestResize);
        public ref bool PlatformRequestClose => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestClose);
        public void Destroy()
        {
            ImGuiNative.ImGuiViewport_destroy((ImGuiViewport*)(NativePtr));
        }
        public Vector2 GetCenter()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetCenter(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
        public Vector2 GetWorkPos()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetWorkPos(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
        public Vector2 GetWorkSize()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetWorkSize(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
    }
}
