using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestAgent.GraphicsLib
{
    /// <summary>
    /// 获取颜色和标识符号的默认值
    /// </summary>
    public class DefaultValue
    {
        private static Color[] _colors = new Color[] { Color.Brown, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple, Color.Gray };
        private static SymbolType[] _symbols
            = new SymbolType[]{SymbolType.Square,SymbolType.Diamond,        SymbolType.Triangle,       SymbolType.Circle,
                    SymbolType.XCross,        SymbolType.Plus,        SymbolType.Star,        SymbolType.TriangleDown,
                    SymbolType.HDash,        SymbolType.VDash
            };
        /// <summary>
        /// 获取颜色的默认值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Color GetDefaultColor(int index)
        {
            if (index < 8)
                return _colors[index];
            else
                return _colors[index % 8];
        }

        /// <summary>
        /// 获取符号的默认值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static SymbolType GetDefaultSymbolType(int index)
        {
            if (index < 10)
                return _symbols[index];
            else
                return _symbols[index % 10];
        }
    }
}
