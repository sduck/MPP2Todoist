// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Label.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Label type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json.Linq;

namespace MPP2Todoist.Todoist
{
    /// <summary>
    /// Valid colors for labels.
    /// </summary>
    public enum LabelColor
    {
        /// <summary>
        /// Green - Hex: #019412
        /// </summary>
        Green = 0,

        /// <summary>
        /// Gold - Hex: #a39d01
        /// </summary>
        Gold = 1,

        /// <summary>
        /// Orange - Hex: #e73d02
        /// </summary>
        Orange = 2,

        /// <summary>
        /// Pink - Hex: #e702a4
        /// </summary>
        Pink = 3,

        /// <summary>
        /// Violet - Hex: #9902e7
        /// </summary>
        Violet = 4,

        /// <summary>
        /// Purple - Hex: #1d02e7
        /// </summary>
        Purple = 5,

        /// <summary>
        /// Light blue - Hex: #0082c5
        /// </summary>
        LightBlue = 6,

        /// <summary>
        /// Grey - Hex: #555555
        /// </summary>
        Grey = 7
    }

    /// <summary>
    /// Todoist.com task label.
    /// </summary>
    public class Label
    {
        #region Constants and Fields

        /// <summary>
        /// The color id.
        /// </summary>
        private readonly LabelColor _color;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The JSON data for this label.
        /// </summary>
        private readonly string _jsonData;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class. 
        /// </summary>
        /// <param name="jsonData">
        /// The JSON data for the new label.
        /// </param>
        internal Label(string jsonData)
        {
            var o = JObject.Parse(jsonData);
            _name = (string)o.SelectToken("name");
            _color = (LabelColor)(int)o.SelectToken("color");
            _jsonData = jsonData;
        }

        #region Public Properties

        /// <summary>
        /// Gets the valid color of the label.
        /// </summary>
        public LabelColor Color
        {
            get
            {
                return _color;
            }
        }

        /// <summary>
        /// Gets the name of the label.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the JSON data for the label.
        /// </summary>
        public string JsonData
        {
            get
            {
                return _jsonData;
            }
        }

        #endregion
    }
}