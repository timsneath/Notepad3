using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad3
{
    public class NotepadCustomCommands
    {
        static NotepadCustomCommands()
        {
            Exit = new RoutedUICommand("E_xit", "Exit", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt, "Alt+F4") });

            TimeDate = new RoutedUICommand("Time/_Date", "TimeDate", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.F5) });
            
            WordWrap = new RoutedUICommand("Word W_rap", "WordWrap", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.W, ModifierKeys.Control, "Ctrl+W") });
            Font = new RoutedUICommand("_Font", "Font", typeof(NotepadCustomCommands));

            ShowWhitespace = new RoutedUICommand("Show _Whitespace", "ShowWhitespace", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.D8, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+8") });
            ShowLineEndings = new RoutedUICommand("Show Line _Endings", "ShowLineEndings", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.D9, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+9") });
            ShowWrapSymbols = new RoutedUICommand("Show Wrap S_ymbols", "ShowWrapSymbols", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.D0, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+0") });
            ShowLineNumbers = new RoutedUICommand("Line _Numbers", "ShowLineNumbers", typeof(NotepadCustomCommands),
                new InputGestureCollection { new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+N") });

            About = new RoutedUICommand("_About", "About", typeof(NotepadCustomCommands) );
        }

        public static RoutedUICommand Exit { get; private set; }
        public static RoutedUICommand TimeDate { get; private set; }
        public static RoutedUICommand WordWrap { get; private set; }
        public static RoutedUICommand Font { get; private set;  }
        public static RoutedUICommand ShowWhitespace { get; private set; }
        public static RoutedUICommand ShowLineEndings { get; private set; }
        public static RoutedUICommand ShowWrapSymbols { get; private set; }
        public static RoutedUICommand ShowLineNumbers { get; private set; }
        public static RoutedUICommand About { get; private set; }
    }
}
