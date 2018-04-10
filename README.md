# KSHarp
Write Kodi (xbmc) Addon with Csharp (C#)
Please Test and Contribute !!

Description :

Ksharp is a library to develop kodi add-ons in C#, Python Call CSharp application console with subprocess.Popen, C# listen standard input for Python event and reply to Function writen in standard output. Version 1.00: not all tested, please test and send your report to Email

Need mono installed, tools.mono addon in libreelec.

How To Build Addon:

In windows with visual studio:

1 - Create C# Console Project.
2 - Add KSharp dll to your References.
3 - Write your code in Program.cs file, Example:


    using CRial;
    using CRial.xbmcaddon;
    using CRial.xbmcgui;
    namespace SimpleExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                SimpleAddon myAddon = new SimpleAddon();
            }
        }
        public class SimpleAddon : KSharp
        {
            Addon addon;
            public SimpleAddon():base()
            {
                addon = new Addon();
                if(Dialog.Ok(addon.getAddonInfo("name"),addon.getAddonInfo("path"),"Click ok to show notification"))
                {
                    Dialog.Notification(addon.getAddonInfo("name"), "Clicked Ok");
                }
                Stop();
            }
        }
    }

4 - Build the project.
5 - Create your addon folder, example: script.ksharp.simpleexample
6 - In your addon folder, Create the addon.xml file, copy addon.py file from KSharp example source, create folder KSharp, Copy KSharp.dll and your C# exe in KSharp folder and rename your exe file to addon.exe.
7 - Install and run your addon !

In Linux with mono:

1 - Create your addon folder, example: script.ksharp.simpleexample
2 - In your addon folder, Create the addon.xml file, copy addon.py file from KSharp example source, create folder KSharp, Copy KSharp.dll in KSharp folder.
3 - Create C# File addon.cs in KSharp Folder
4 - Write your code in addon.cs file, (view in windows section)
5 - Build the project, Example : dmcs addon.cs -r:KSharp.dll
6 - Install and run your addon !
