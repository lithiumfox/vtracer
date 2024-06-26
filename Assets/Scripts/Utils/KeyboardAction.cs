﻿using System;
using System.Runtime.InteropServices;

namespace VMC
{
    public class KeyboardEventArgs : EventArgs
    {
        public int KeyCode { get; }
        public string KeyName { get; }

        public KeyboardEventArgs(int keyCode) : base()
        {
            KeyCode = keyCode; KeyName = KeyboardAction.KeyCodeString[keyCode];
        }
    }

    public static class KeyboardAction
    {
        public static EventHandler<KeyboardEventArgs> KeyDownEvent;
        public static EventHandler<KeyboardEventArgs> KeyUpEvent;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);


        private static bool IsInitialized = false;

        private static bool[] LastKeys = new bool[256];

        public static void Update()
        {
            int i;
            var keys = new bool[256];
            var states = new byte[256];
            //if (GetKeyboardState(states))
            //{
            //    for (i = 0; i < 256; i++)
            //    {
            //        keys[i] = ((states[i] & 0x80) == 0x80) & KeyMask[i];
            //    }
            //}
            for (i = 0; i < 256; i++)
            {
                if (KeyMask[i])
                {
                    keys[i] = (GetAsyncKeyState(i) & 0x8000) != 0;
                }
            }
            if (IsInitialized)
            {
                for (i = 0; i < 256; i++)
                {
                    if (keys[i] != LastKeys[i])
                    {
                        if (keys[i]) KeyDownEvent(keys, new KeyboardEventArgs(i));
                        else KeyUpEvent(keys, new KeyboardEventArgs(i));
                    }
                }
            }
            else
            {
                IsInitialized = true;
            }
            LastKeys = keys;
        }


        public static string[] KeyCodeString = new string[] {
        "",
        "左クリック",
        "右クリック",
        "コントロールブレイク",
        "中クリック",
        "マウス第一拡張",
        "マウス第二拡張",
        "未定義",
        "BackSpace",
        "Tab",
        "予約済",
        "予約済",
        "Clear",
        "Enter",
        "未定義",
        "未定義",
        "Shift",
        "Ctrl",
        "Alt",
        "Pause",
        "CapsLock",
        "IME かな",
        "未定義",
        "IME Junja",
        "IME ファイナル",
        "IME 漢字",
        "未定義",
        "Esc",
        "IME 変換",
        "IME 無変換",
        "IME 使用可能",
        "IME モード変更要求",
        "スペース",
        "Page Up",
        "Page Down",
        "End",
        "Home",
        "←",
        "↑",
        "→",
        "↓",
        "Select",
        "Print",
        "Execute",
        "PrintScreen",
        "Insert",
        "Delete",
        "Help",
        "0",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "未定義",
        "未定義",
        "未定義",
        "未定義",
        "未定義",
        "未定義",
        "未定義",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z",
        "左Windows",
        "右Windows",
        "アプリケーション",
        "予約済",
        "Sleep",
        "テンキー0",
        "テンキー1",
        "テンキー2",
        "テンキー3",
        "テンキー4",
        "テンキー5",
        "テンキー6",
        "テンキー7",
        "テンキー8",
        "テンキー9",
        "テンキー*",
        "テンキー+",
        "区切り記号",
        "テンキー-",
        "テンキー.",
        "テンキー/",
        "F1",
        "F2",
        "F3",
        "F4",
        "F5",
        "F6",
        "F7",
        "F8",
        "F9",
        "F10",
        "F11",
        "F12",
        "F13",
        "F14",
        "F15",
        "F16",
        "F17",
        "F18",
        "F19",
        "F20",
        "F21",
        "F22",
        "F23",
        "F24",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "NumLock",
        "ScrollLock",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "未割当",
        "左Shift",
        "右Shift",
        "左Ctrl",
        "右Ctrl",
        "左Alt",
        "右Alt",
        "ブラウザー戻る",
        "ブラウザー進む",
        "ブラウザー更新",
        "ブラウザー停止",
        "ブラウザー検索",
        "ブラウザーお気に入り",
        "ブラウザー開始/ホーム",
        "音量ミュート",
        "音量ダウン",
        "音量アップ",
        "次のトラック",
        "前のトラック",
        "メディア停止",
        "メディア再生/一時停止",
        "メール",
        "メディア選択",
        "アプリケーション1",
        "アプリケーション2",
        "予約済",
        "予約済",
        "[:*]",
        "[;+]",
        "[,<]",
        "[-=]",
        "[.>]",
        "[/?]",
        "[@`]",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "予約済",
        "未割当",
        "未割当",
        "未割当",
        "[[{]",
        "[\\|]",
        "[]}]",
        "[^~]",
        "OEM8",
        "予約済",
        "OEM固有",
        "[＼_]",
        "OEM固有",
        "OEM固有",
        "IME PROCESS",
        "OEM固有",
        "仮想キー下位ワード",
        "未割当",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "英数",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "OEM固有",
        "Attn",
        "CrSel",
        "ExSel",
        "Erase EOF",
        "Play",
        "Zoom",
        "予約済",
        "PA1",
        "Clear",
        ""
    };

        private static bool[] KeyMask = new bool[]
        {
        false, // "",
        false, // "左クリック",
        false, // "右クリック",
        false, // "コントロールブレイク",
        false, // "中クリック",
        false, // "マウス第一拡張",
        false, // "マウス第二拡張",
        false, // "未定義",
        true,  // "BackSpace",
        true,  // "Tab",
        false, // "予約済",
        false, // "予約済",
        true,  // "Clear",
        true,  // "Enter",
        false, // "未定義",
        false, // "未定義",
        false, // "Shift",
        false, // "Ctrl",
        false, // "Alt",
        true,  // "Pause",
        true,  // "CapsLock",
        true,  // "IME かな",
        false, // "未定義",
        true,  // "IME Junja",
        true,  // "IME ファイナル",
        true,  // "IME 漢字",
        false, // "未定義",
        true,  // "Esc",
        true,  // "IME 変換",
        true,  // "IME 無変換",
        true,  // "IME 使用可能",
        true,  // "IME モード変更要求",
        true,  // "スペース",
        true,  // "Page Up",
        true,  // "Page Down",
        true,  // "End",
        true,  // "Home",
        true,  // "←",
        true,  // "↑",
        true,  // "→",
        true,  // "↓",
        true,  // "Select",
        true,  // "Print",
        true,  // "Execute",
        true,  // "PrintScreen",
        true,  // "Insert",
        true,  // "Delete",
        true,  // "Help",
        true,  // "0",
        true,  // "1",
        true,  // "2",
        true,  // "3",
        true,  // "4",
        true,  // "5",
        true,  // "6",
        true,  // "7",
        true,  // "8",
        true,  // "9",
        false, // "未定義",
        false, // "未定義",
        false, // "未定義",
        false, // "未定義",
        false, // "未定義",
        false, // "未定義",
        false, // "未定義",
        true,  // "A",
        true,  // "B",
        true,  // "C",
        true,  // "D",
        true,  // "E",
        true,  // "F",
        true,  // "G",
        true,  // "H",
        true,  // "I",
        true,  // "J",
        true,  // "K",
        true,  // "L",
        true,  // "M",
        true,  // "N",
        true,  // "O",
        true,  // "P",
        true,  // "Q",
        true,  // "R",
        true,  // "S",
        true,  // "T",
        true,  // "U",
        true,  // "V",
        true,  // "W",
        true,  // "X",
        true,  // "Y",
        true,  // "Z",
        true,  // "左Windows",
        true,  // "右Windows",
        true,  // "アプリケーション",
        false, // "予約済",
        true,  // "Sleep",
        true,  // "テンキー0",
        true,  // "テンキー1",
        true,  // "テンキー2",
        true,  // "テンキー3",
        true,  // "テンキー4",
        true,  // "テンキー5",
        true,  // "テンキー6",
        true,  // "テンキー7",
        true,  // "テンキー8",
        true,  // "テンキー9",
        true,  // "テンキー*",
        true,  // "テンキー+",
        true,  // "区切り記号",
        true,  // "テンキー-",
        true,  // "テンキー.",
        true,  // "テンキー/",
        true,  // "F1",
        true,  // "F2",
        true,  // "F3",
        true,  // "F4",
        true,  // "F5",
        true,  // "F6",
        true,  // "F7",
        true,  // "F8",
        true,  // "F9",
        true,  // "F10",
        true,  // "F11",
        true,  // "F12",
        true,  // "F13",
        true,  // "F14",
        true,  // "F15",
        true,  // "F16",
        true,  // "F17",
        true,  // "F18",
        true,  // "F19",
        true,  // "F20",
        true,  // "F21",
        true,  // "F22",
        true,  // "F23",
        true,  // "F24",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        true,  // "NumLock",
        true,  // "ScrollLock",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        true,  // "左Shift",
        true,  // "右Shift",
        true,  // "左Ctrl",
        true,  // "右Ctrl",
        true,  // "左Alt",
        true,  // "右Alt",
        false, // "ブラウザー戻る",
        false, // "ブラウザー進む",
        false, // "ブラウザー更新",
        false, // "ブラウザー停止",
        false, // "ブラウザー検索",
        false, // "ブラウザーお気に入り",
        false, // "ブラウザー開始/ホーム",
        false, // "音量ミュート",
        false, // "音量ダウン",
        false, // "音量アップ",
        false, // "次のトラック",
        false, // "前のトラック",
        false, // "メディア停止",
        false, // "メディア再生/一時停止",
        false, // "メール",
        false, // "メディア選択",
        false, // "アプリケーション1",
        false, // "アプリケーション2",
        false, // "予約済",
        false, // "予約済",
        true,  // "[:*]",
        true,  // "[;+]",
        true,  // "[,<]",
        true,  // "[-=]",
        true,  // "[.>]",
        true,  // "[/?]",
        true,  // "[@`]",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "予約済",
        false, // "未割当",
        false, // "未割当",
        false, // "未割当",
        true,  // "[[{]",
        true,  // "[\\|]",
        true,  // "[]}]",
        true,  // "[^~]",
        false, // "OEM8",
        false, // "予約済",
        false, // "OEM固有",
        true,  // "[＼_]",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "IME PROCESS",
        false, // "OEM固有",
        false, // "仮想キー下位ワード",
        false, // "未割当",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        true,  // "英数",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "OEM固有",
        false, // "Attn",
        false, // "CrSel",
        false, // "ExSel",
        false, // "Erase EOF",
        false, // "Play",
        false, // "Zoom",
        false, // "予約済",
        false, // "PA1",
        false, // "Clear"
        false, // ""
        };
    }
}