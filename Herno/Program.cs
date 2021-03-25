using System;
using System.Reflection;

namespace HernoEditor
{
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            using (var editor = new EditorWindow()) 
                editor.Run();
        }
    }
}
